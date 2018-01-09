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
    
    public partial class Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction()
        {
            this.TransactionsLists = new HashSet<TransactionsList>();
        }
    
        public decimal UID { get; set; }
        public decimal BranchId { get; set; }
        public int FinYear { get; set; }
        public int DocumentTypeID { get; set; }
        public int DocumentNo { get; set; }
        public System.DateTime DocumentDate { get; set; }
        public System.DateTime PreparedDate { get; set; }
        public decimal AccountM_UID { get; set; }
        public string AddlNotes { get; set; }
        public string RefDoc { get; set; }
        public decimal AddAmount { get; set; }
        public decimal PackingCharge { get; set; }
        public decimal Discount { get; set; }
        public decimal SpecialDiscount { get; set; }
        public decimal ED { get; set; }
        public decimal EDRoundOff { get; set; }
        public decimal EDCess { get; set; }
        public decimal OtherSalesTax { get; set; }
        public decimal LocalSalesTax { get; set; }
        public decimal Surcharge { get; set; }
        public decimal ServiceTax { get; set; }
        public decimal ServiceTaxCess { get; set; }
        public decimal OtherDiscount { get; set; }
        public decimal GrossValue { get; set; }
        public decimal TotalValue { get; set; }
        public int StatusM_UID { get; set; }
        public decimal RefTransactions_UID { get; set; }
        public decimal TotalValueRoundOff { get; set; }
        public int AmendmentNo { get; set; }
        public System.DateTime AmendmentDate { get; set; }
        public int PrintCount { get; set; }
        public string AmendmentReason { get; set; }
        public decimal DespatchToId { get; set; }
        public decimal DealerId { get; set; }
        public decimal RegionId { get; set; }
        public decimal ZoneId { get; set; }
        public decimal AreaId { get; set; }
        public decimal InchargeId { get; set; }
        public decimal StatutoryDocM_UID { get; set; }
        public int ViewType { get; set; }
        public decimal CurrencyId { get; set; }
        public decimal CurrencyConversionRate { get; set; }
        public Nullable<System.DateTime> RefDocDate { get; set; }
        public string LongDocumentNo { get; set; }
        public string RefDoc1 { get; set; }
        public Nullable<System.DateTime> RefDocDate1 { get; set; }
        public string StatusReason { get; set; }
        public Nullable<System.DateTime> DespatchDate { get; set; }
        public decimal HECess { get; set; }
        public decimal ClosedGrossValue { get; set; }
        public bool IsEDModified { get; set; }
        public bool IsEDCessModified { get; set; }
        public bool IsOtherSalesTaxModified { get; set; }
        public bool IsLocalSalesTaxModified { get; set; }
        public bool IsTotalValueRoundOffModified { get; set; }
        public bool IsHECessModified { get; set; }
        public decimal TransactionsGate_UID { get; set; }
        public decimal ServiceTaxHECess { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionsList> TransactionsLists { get; set; }
    }
}