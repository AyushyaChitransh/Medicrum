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
        public int invoice_number { get; set; }
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
        public decimal? invoice_total_value { get; set; }
        public decimal? invoice_vat_value { get; set; }
        public Invoice_Medicines[] invoice_medicines { get; set; }
        public string invoice_payment_terms { get; set; }
        public string invoice_payment_mode { get; set; }

        public InvoiceJson(Invoice invoice)
        {
            invoice_number = invoice.invoiceNumber;
            invoice_date = invoice.invoiceDate;
            invoice_payment_mode = invoice.paymentMode;
            invoice_payment_terms = invoice.paymentTerms;
            invoice_total_value = invoice.netTotal;
            invoice_vat_value = invoice.taxAmount;
        }
        public InvoiceJson(Invoice invoice, Customer customer)
        {

            invoice_number = invoice.invoiceNumber;
            invoice_date = invoice.invoiceDate;
            invoice_payment_terms = invoice.paymentTerms;
            invoice_customer = customer.customerName;
            invoice_address = customer.address;
            invoice_district = customer.district;
            invoice_state = customer.state;
            invoice_country = customer.country;
            invoice_pincode = customer.pincode;
            invoice_email = customer.email;
            invoice_mobile = customer.mobile;
            invoice_total_value = invoice.netTotal;
            invoice_vat_value = invoice.taxAmount;
        }
    }

    public class Invoice_Medicines
    {
        public string medicine_name { get; set; }
        public string medicine_description { get; set; }
        public decimal medicine_rate { get; set; }
        public int medicine_qty { get; set; }
        public decimal medicine_vat { get; set; }
        public decimal medicine_total { get; set; }
        public Invoice_Medicines(BillingItems bill)
        {
            DAOStockProduct accessProductDb = new DAOStockProduct();
            object product = accessProductDb.GetProduct(bill.productId);
            medicine_name = (product.GetType().GetProperty("productName").GetValue(product, null)).ToString();
            //medicine_description = (product.GetType().GetProperty("description").GetValue(product, null)).ToString();
            medicine_rate = bill.unitPrice;
            medicine_qty = bill.quantity;
            decimal vatTemp = new decimal();
            if (decimal.TryParse((product.GetType().GetProperty("tax").GetValue(product, null)).ToString(), out vatTemp))
            {
                medicine_vat = vatTemp;
            }
            //medicine_total = medicine_rate * medicine_qty + medicine_vat; Am not sure how to calculate it
            medicine_total = bill.price;
        }
    }
}