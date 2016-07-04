using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.Model
{
    public class BillingItems
    {
        public int billId { get; set; }
        public int invoiceId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal price { get; set; }
        public int status { get; set; }
        public int deleteStatus { get; set; }
    }
}