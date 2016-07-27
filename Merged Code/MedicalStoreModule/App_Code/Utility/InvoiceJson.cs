using MedicalStoreModule.App_Code.DAO;
using MedicalStoreModule.App_Code.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.Utility
{
    public class InvoiceJson
    {
        public int invoice_id { get; set; }
        public int invoice_number { get; set; }
        public string invoice_type { get; set; }
        public DateTime invoice_date { get; set; }
        public DateTime invoice_due_date { get; set; }
        public string invoice_customer { get; set; }
        public string invoice_address { get; set; }
        public string invoice_district { get; set; }
        public string invoice_state { get; set; }
        public string invoice_country { get; set; }
        public string invoice_pincode { get; set; }
        public string invoice_email { get; set; }
        public string invoice_mobile { get; set; }
        public string invoice_store_name { get; set; }
        public string invoice_store_address { get; set; }
        public string invoice_store_district { get; set; }
        public string invoice_store_state { get; set; }
        public string invoice_store_country { get; set; }
        public string invoice_store_pincode { get; set; }
        public string invoice_store_email { get; set; }
        public string invoice_store_mobile { get; set; }
        public decimal? invoice_total_value { get; set; }
        public decimal? invoice_vat_value { get; set; }
        public decimal invoice_discount_amount { get; set; }
        public decimal? invoice_payable_amount { get; set; }
        public Invoice_Medicines[] invoice_medicines { get; set; }
        public string invoice_payment_terms { get; set; }
        public string invoice_payment_mode { get; set; }
    }

    public class Invoice_Medicines
    {
        public string medicine_name { get; set; }
        public decimal medicine_rate { get; set; }
        public int medicine_qty { get; set; }
        public decimal medicine_total { get; set; }
        public Invoice_Medicines(BillingItems bill)
        {
            DAOStockProduct accessProductDb = new DAOStockProduct();
            object product = accessProductDb.GetProduct(bill.productId);
            medicine_name = (product.GetType().GetProperty("productName").GetValue(product, null)).ToString();
            medicine_rate = bill.unitPrice;
            medicine_qty = bill.quantity;
            medicine_total = medicine_rate * medicine_qty;
        }
    }
}