//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Swift.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountM
    {
        public decimal UID { get; set; }
        public decimal BranchId { get; set; }
        public int AccountTypeID { get; set; }
        public decimal AccountM_UID { get; set; }
        public bool MainHead { get; set; }
        public bool IsFixed { get; set; }
        public string AccountName { get; set; }
        public string ShortName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public int AreaID { get; set; }
        public decimal Debit_CreditLimit { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string email { get; set; }
        public string TNGSTNO { get; set; }
        public string TNGSTDate { get; set; }
        public string CSTNO { get; set; }
        public string CSTDate { get; set; }
        public string DutyType { get; set; }
        public decimal DutyPer { get; set; }
        public int DutyCalcMethod { get; set; }
        public int PrimaryID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string AddlSpecification1 { get; set; }
        public string AddlSpecification2 { get; set; }
        public string AddlSpecification3 { get; set; }
        public string AddlSpecification4 { get; set; }
        public decimal CostPerHour { get; set; }
        public decimal MaxUtilizedHour { get; set; }
        public bool Approved { get; set; }
        public string ExciseEccNo { get; set; }
        public string ExciseZone { get; set; }
        public string ExciseRange { get; set; }
        public string ExciseWareHouse { get; set; }
        public bool IsGroup { get; set; }
        public int HLevel { get; set; }
        public int BSPLTypeM_UID { get; set; }
        public int Debit_CreditDays { get; set; }
        public decimal Zone_UID { get; set; }
        public decimal Region_UID { get; set; }
        public decimal Area_UID { get; set; }
        public decimal ResponsibleEmployee_UID { get; set; }
        public int BranchCode { get; set; }
        public decimal CurrencyId { get; set; }
        public decimal CurrencyRate { get; set; }
        public string Pincode { get; set; }
        public decimal GroupId { get; set; }
        public string AccountCode { get; set; }
        public string LongAccountName { get; set; }
        public decimal TaxTypeId { get; set; }
        public string PANNo { get; set; }
        public bool IsCreditDaysApplicable { get; set; }
        public decimal TDSPer { get; set; }
        public decimal TDSSurPer { get; set; }
        public decimal PriceListM_UID { get; set; }
    }
}
