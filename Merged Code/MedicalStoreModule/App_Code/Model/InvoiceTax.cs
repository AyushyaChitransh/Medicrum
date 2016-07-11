using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.Model
{
    public class InvoiceTax
    {
        public int taxId { get; set; }
        public Nullable<int> invoiceId { get; set; }
        public string taxType { get; set; }
        public Nullable<decimal> taxAmount { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> deleteStatus { get; set; }
    }
}