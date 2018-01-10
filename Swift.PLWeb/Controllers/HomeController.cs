using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Swift.Common;
using Swift.DAL;
using Swift.PLWeb.Models;

namespace Swift.PLWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Customer()
        {
            return View();
        }

        public JsonResult CustomerList()
        {
            var db = new DemoEntities();
            var lst = db.ViewCustomerDetails.Select(x => new { x.UID, x.AccountName, x.AccountCode,x.Address4,x.Address5,x.Category,x.GSTIN,x.PANNo });
            var r = Json(lst,JsonRequestBehavior.AllowGet);
            r.MaxJsonLength = int.MaxValue;
            return r;
        }

        public JsonResult CustomerProductList(decimal UID)
        {
            var db = new DemoEntities();
            var lst = db.SP_CustomerwiseProductList(UID).ToList();
            var r = Json(lst, JsonRequestBehavior.AllowGet);
            r.MaxJsonLength = int.MaxValue;
            return r;
        }

        public JsonResult CustomerStatusList(decimal UID,DateTime DateFrom, DateTime DateTo)
        {
            var db = new DemoEntities();
            var lst = db.SP_CustomerwiseStatusList(UID).ToList().Where(x=> x.DocumentDate>=DateFrom && x.DocumentDate<=DateTo).ToList();
            var r = Json(lst, JsonRequestBehavior.AllowGet);
            r.MaxJsonLength = int.MaxValue;
            return r;
        }

        public JsonResult SaveTrans(DateTime OrderDate,decimal CustomerUID, List<COItem> ItemList, List<COItemSchedule> ItemQtyList)
        {

            var r = Json(new { IsSaved = false, ErrMsg = "Not Saved" }, JsonRequestBehavior.AllowGet);
            r.MaxJsonLength = int.MaxValue;

            var db = new DemoEntities();
            var ProductList = db.SP_CustomerwiseProductList(CustomerUID).ToList();

            var trSLNo = db.TransactionSlNos.Where(x => x.BranchId == AppLib.BranchId && x.TableName == "Transactions").FirstOrDefault();
            var trlSLNo = db.TransactionSlNos.Where(x => x.BranchId == AppLib.BranchId && x.TableName == "TransactionsList").FirstOrDefault();
            var trldSLNo = db.TransactionSlNos.Where(x => x.BranchId == AppLib.BranchId && x.TableName == "TransactionsListDely").FirstOrDefault();

            var docNo = db.DocumentTypeMLists.Where(x => x.BranchId == AppLib.BranchId && x.Yr == AppLib.FinYear && x.DocumentTypeId == (int) AppLib.DocumdentType.CustomerOrder).FirstOrDefault();
            var status = db.StatusMs.Where(x => x.Status == "Open").FirstOrDefault();
            if (docNo ==null)
            {
                docNo = new DocumentTypeMList() {
                    BranchId=AppLib.BranchId,
                    Yr=AppLib.FinYear                    
                };
                db.DocumentTypeMLists.Add(docNo);
            }

            try
            {
                trSLNo.LastID += 1;
                docNo.LastId += 1;
                docNo.LastUpdateDate = DateTime.Now;
                Transaction tr = new Transaction()
                {
                    UID = trSLNo.LastID,
                    BranchId = AppLib.BranchId,
                    FinYear = AppLib.FinYear,
                    DocumentTypeID = (int)AppLib.DocumdentType.CustomerOrder,
                    DocumentNo = docNo.LastId,
                    LongDocumentNo = string.Format("CO{0}/{1:D4}", AppLib.FinYear % 100, docNo.LastId),
                    DocumentDate = OrderDate,
                    PreparedDate = OrderDate,
                    AccountM_UID = CustomerUID,
                    RefDoc = "",
                    AddAmount = 0,
                    PackingCharge = 0,
                    Discount = 0,
                    SpecialDiscount = 0,
                    ED = 0,
                    EDRoundOff = 0,
                    EDCess = 0,
                    OtherSalesTax = 0,
                    LocalSalesTax = 0,
                    Surcharge = 0,
                    ServiceTax = 0,
                    ServiceTaxCess = 0,
                    OtherDiscount = 0,
                    GrossValue = 0,
                    TotalValue = 0,
                    StatusM_UID = status.UID,
                    RefTransactions_UID = 0,
                    TotalValueRoundOff = 0,
                    AmendmentNo = 0,
                    AmendmentDate = DateTime.Now,
                    PrintCount = 0,
                    AmendmentReason = "",
                    DespatchToId = 0,
                    DealerId = 0,
                    RegionId = 0,
                    ZoneId = 0,
                    AreaId = 0,
                    InchargeId = 0,
                    StatutoryDocM_UID = 0,
                    ViewType = 0,
                    CurrencyId = 0,
                    CurrencyConversionRate = 0,
                    RefDocDate = DateTime.Now,
                    RefDoc1 = "",
                    StatusReason = "",
                    HECess = 0,
                    ClosedGrossValue = 0,
                    IsEDModified = false,
                    IsEDCessModified = false,
                    IsLocalSalesTaxModified = false,
                    IsTotalValueRoundOffModified = false,
                    IsHECessModified = false,
                    TransactionsGate_UID = 0,
                    ServiceTaxHECess = 0
                };
                foreach (var item in ItemList)
                {
                    trlSLNo.LastID += 1;
                    var qty = ItemQtyList.Where(x => x.ItemUID == item.UID).Sum(x => x.Qty);
                    var Product = ProductList.Where(x => x.UID == item.UID).FirstOrDefault();

                    decimal Price = Product.Price.Value;
                    decimal Amount = Price * qty;

                    decimal DisPer = Product.DiscountPer;
                    decimal DisAmt = Amount * DisPer / 100;

                    decimal ItemAmount = Amount - DisAmt;

                    decimal CGSTPer = Product.CGSTPer ?? 0;
                    decimal CGSTAmt = ItemAmount * CGSTPer / 100;

                    decimal SGSTPer = Product.SGSTPer ?? 0;
                    decimal SGSTAmt = ItemAmount * SGSTPer / 100;

                    decimal IGSTPer = Product.IGSTPer ?? 0;
                    decimal IGSTAmt = ItemAmount * IGSTPer / 100;

                    decimal ToalAmount = ItemAmount + CGSTAmt + SGSTAmt + IGSTAmt;

                    TransactionsList trl = new TransactionsList()
                    {
                        UID = trlSLNo.LastID,
                        ItemsM_UID = item.UID,
                        Qty = qty,
                        Price = Product.Price.Value,
                        BasicValue = Amount,
                        AddPer = 0,
                        AddAmount = 0,
                        BasicDiscountPer = DisPer,
                        BasicDiscountAmount = DisAmt,
                        PackingPer = 0,
                        PackingAmount = 0,
                        ExciseDutyPer = IGSTPer,
                        ExciseDutyAmount = IGSTAmt,
                        CessPer = 0,
                        CessAmount = 0,
                        LocalSalesTaxPer = CGSTPer + SGSTPer,
                        LocalSalesTaxAmount = CGSTAmt + SGSTAmt,
                        SurchargePer = 0,
                        SurchargeAmount = 0,
                        OtherSalesTaxPer = IGSTPer,
                        OtherSalesTaxAmount = IGSTAmt,
                        ServiceTaxPer = 0,
                        ServiceTaxAmount = 0,
                        ServiceTaxCessPer = 0,
                        ServiceTaxCessAmount = 0,
                        TotalValue = ToalAmount,
                        SalesVolumeDiscount = ItemAmount,
                        Commission = 0,
                        SpecialDiscount = 0,
                        StatusM_UID = status.UID,
                        AddlDetails = "",
                        UOM_UID = Product.UOM_UID,
                        RefTransactionsList_UID = 0,
                        BalanceQty = qty,
                        QtyDC = 0,
                        QtyReceived = 0,
                        QtyRejected = 0,
                        QtyReworked = 0,
                        Weight = 0,
                        ExciseGroupM_UID = 765,
                        ItemsM_Tolerance = 0,
                        CategoryM_UID = Product.Category_UID,
                        Sales_AccountM_UID = Product.Sales_AccountM_UID,
                        Stock_AccountM_UID = Product.Stock_AccountM_UID,
                        Consumption_AccountM_UID = Product.Consumption_AccountM_UID,
                        WIP_AccountM_UID = Product.WIP_AccountM_UID,
                        ConversionUOM_UID = Product.ConversionUOM_UID,
                        ConversionUOM_Qty = Product.ConversionUOM_Qty,
                        ConversionUOM_Rate = Product.ConversionUOM_Rate,
                        BatchNo = "",
                        CommissionM_UID = 0,
                        CommissionPer = 0,
                        PartyMItemsMPrice_UID = 0,
                        ParentTransactionsList_UID = 0,
                        RefDocumentTypeId = 0,
                        IsEDIncluded = false,
                        HECessPer = 0,
                        HECessAmount = 0,
                        IsVATApplicable = false,
                        IsEDApplicable = false,
                        StockValue = 0,
                        EDID = 0,
                        CessID = 0,
                        HECessID = 0,
                        VATID = 0,
                        CSTID = 0,
                        BalanceRejectedQty = 0,
                        VATCategoryID = 0,
                        TransactionsListSent_UID = 0,
                        InspectionUID = 0,
                        ServiceTaxID = 0,
                        IsRateCalForRecQty = false,
                        IsAlternateBOM = false,
                        GRN_AccountM_UID = Product.GRN_AccountM_UID

                    };

                    foreach (var trld in ItemQtyList.Where(x => x.ItemUID == item.UID).ToList())
                    {
                        trldSLNo.LastID += 1;
                        trl.TransactionsListDelies.Add(new TransactionsListDely()
                        {
                            UID = trldSLNo.LastID,
                            DeliveryDate = trld.DeliveryDate,
                            BalanceJobCardQty = 0,
                            ProductionQty = 0,
                            DespatchedQty = 0,
                            OrderedQty = trld.Qty,
                            ReceivedQty = 0,
                            StatusM_UID = status.UID,
                            PackingDate = trld.ScheduledDate,
                        });
                    }

                    tr.TransactionsLists.Add(trl);
                }

                tr.Discount = tr.TransactionsLists.Sum(x => x.BasicDiscountAmount);                
                tr.TotalValue = tr.TransactionsLists.Sum(x => x.TotalValue);

                db.Transactions.Add(tr);
                db.SaveChanges();
                
                r = Json(new { IsSaved = true, UID = tr.UID, OrderNo = tr.LongDocumentNo, ErrMsg = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                AppLib.WriteLog(ex);
            }

            return r;
        }
        
        public ActionResult CustomerOrder(decimal UID)
        {
            var db = new DemoEntities();            
            var cust = db.ViewCustomerDetails.Where(x => x.UID == UID).FirstOrDefault();
            return View(cust);
        }

        public ActionResult CustomerStatus(decimal UID)
        {
            var db = new DemoEntities();
            var cust = db.ViewCustomerDetails.Where(x => x.UID == UID).FirstOrDefault();
            return View(cust);
        }

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult EmpLogin(string EmpName, string Password)
        {            
            try
            {
                AppLib.WriteLog("Login_Start");

                var db = new DemoEntities();
                var qry = from am in db.AccountMs
                          join amp in db.AccountMPasswords on am.UID equals amp.AccountM_UID
                          where am.AccountTypeID==800 && am.AccountName==EmpName && amp.Password==Password
                          select new { am.UID, am.AccountCode};

                var d = qry.FirstOrDefault();
                if (d == null)
                {
                    var r = Json(new { IsLogin = false, ErrMsg = "Invalid User" }, JsonRequestBehavior.AllowGet);
                    AppLib.WriteLog("Login_Failed");
                    return r;
                }
                else
                {
                    var r = Json(new { IsLogin = true,EmpCode=d.AccountCode, ErrMsg = "" }, JsonRequestBehavior.AllowGet);
                    AppLib.WriteLog("Login_End");
                    return r;
                }                
            }
            catch(Exception ex)
            {
                AppLib.WriteLog(ex);
                var r = Json(new { IsLogin = false, ErrMsg = "Invalid User" }, JsonRequestBehavior.AllowGet);
                return r;
            }            
        }

    }
}