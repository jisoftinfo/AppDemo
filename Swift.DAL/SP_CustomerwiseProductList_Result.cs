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
    
    public partial class SP_CustomerwiseProductList_Result
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string DrawingNo { get; set; }
        public string DrawingRevisionNo { get; set; }
        public string Category { get; set; }
        public string UOM { get; set; }
        public decimal CGSTUID { get; set; }
        public decimal SGSTUID { get; set; }
        public decimal IGSTUID { get; set; }
        public Nullable<decimal> CGSTPer { get; set; }
        public Nullable<decimal> SGSTPer { get; set; }
        public Nullable<decimal> IGSTPer { get; set; }
        public decimal DiscountPer { get; set; }
        public decimal UID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public decimal UOM_UID { get; set; }
        public decimal Category_UID { get; set; }
        public decimal Sales_AccountM_UID { get; set; }
        public decimal Stock_AccountM_UID { get; set; }
        public decimal Consumption_AccountM_UID { get; set; }
        public decimal WIP_AccountM_UID { get; set; }
        public int ConversionUOM_UID { get; set; }
        public int ConversionUOM_Rate { get; set; }
        public int ConversionUOM_Qty { get; set; }
        public Nullable<decimal> GRN_AccountM_UID { get; set; }
    }
}
