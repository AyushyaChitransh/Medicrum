using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.Model
{
    public class Invoice
    {
        public int invoiceId { get; set; }
        public int invoiceNumber { get; set; }
        public int storeId { get; set; }
        public int customerId { get; set; }
        public System.DateTime invoiceDate { get; set; }
        public string invoiceType { get; set; }
        public string paymentTerms { get; set; }
        public string paymentMode { get; set; }
        public Nullable<decimal> totalAmount { get; set; }
        public Nullable<decimal> taxAmount { get; set; }
        public string discountType { get; set; }
        public Nullable<decimal> discountAmount { get; set; }
        public string couponCode { get; set; }
        public Nullable<decimal> netTotal { get; set; }
        public Nullable<decimal> amountPaid { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> deleteStatus { get; set; }
    }
}