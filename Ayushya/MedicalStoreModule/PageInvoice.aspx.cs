using MedicalStoreModule.App_Code.DAO;
using MedicalStoreModule.App_Code.Model;
using MedicalStoreModule.App_Code.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalStoreModule
{
    public partial class PageInvoice : System.Web.UI.Page
    {
        private static int storeId = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Session["storeId"] != null && Session["userName"] != null)
            //    {
            //        storeId = int.Parse(Session["storeId"].ToString());
            //    }
            //    else
            //    {
            //        Response.Redirect("Login.aspx");
            //    }
            //}
        }

        [WebMethod]
        public static bool InsertInvoiceAndBillingItems(string couponCode, int customerId, string discountType, int invoiceNumber, string invoiceType, string paymentMode, string paymentTerms, List<BillingItems> billingItems)
        {
            billingItems.RemoveAt(0);
            Invoice invoice = new Invoice();
            invoice.invoiceNumber = invoiceNumber;
            invoice.storeId = storeId;
            invoice.customerId = customerId;
            invoice.invoiceDate = DateTime.Now;
            invoice.invoiceType = invoiceType;
            invoice.paymentTerms = paymentTerms;
            invoice.paymentMode = paymentMode;
            invoice.discountType = discountType;
            invoice.couponCode = couponCode;

            //hardcoded values
            invoice.totalAmount = 1;
            invoice.taxAmount = 1;
            invoice.discountAmount = 1;

            invoice.netTotal = invoice.totalAmount + invoice.taxAmount;
            invoice.amountPaid = invoice.netTotal;

            invoice.status = 1;
            invoice.deleteStatus = 0;

            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.InsertInvoice(invoice, billingItems);
        }

        [WebMethod]
        public static object GetProductOptions()
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.GetProductOptions(storeId);
        }

        [WebMethod]
        public static object GetCustomerOptions()
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.GetCustomerOptions(storeId);
        }

        public string InvoiceSidebarList(string searchText)
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            List<object> invoiceList = accessInvoiceDb.GetInvoiceList(searchText, storeId);
            string sidebarList = "";
            foreach (object item in invoiceList)
            {
                var invoiceId = item.GetType().GetProperty("invoiceId").GetValue(item, null);
                var invoiceNumber = item.GetType().GetProperty("invoiceNumber").GetValue(item, null);
                var invoiceDate = item.GetType().GetProperty("invoiceDate").GetValue(item, null);
                var customerName = item.GetType().GetProperty("customerName").GetValue(item, null);
                sidebarList += "<li><a href='#' class='md-list-content' data-invoice-id=" + invoiceId + "/>";
                sidebarList += "<span class='md-list-heading uk-text-truncate'>Invoice " + invoiceNumber + "<span class='uk-text-small uk-text-muted'> " + invoiceDate + "</span></span>";
                sidebarList += "<span class='uk-text-small uk-text-muted'>Customer " + customerName + "</span>";
            }
            return sidebarList;
        }

        [WebMethod]
        public static object GetInvoice(int invoiceId)
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            DAOCustomer accessCustomerDb = new DAOCustomer();
            Invoice invoice = accessInvoiceDb.GetInvoice(invoiceId);
            Customer customer = accessCustomerDb.GetCustomer(invoice.customerId);
            List<BillingItems> billingItems = accessInvoiceDb.GetBillingItems(invoice.invoiceId);
            InvoiceJson invoiceJson = new InvoiceJson(invoice, customer);
            Invoice_Medicines[] invoiceMedicine = new Invoice_Medicines[billingItems.Count];
            int i = 0;
            foreach (BillingItems item in billingItems)
            {
                Invoice_Medicines med = new Invoice_Medicines(item);
                invoiceMedicine[i++] = med;
            }
            invoiceJson.invoice_medicines = invoiceMedicine;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string invoiceJsonData = serializer.Serialize(invoiceJson);
            return invoiceJsonData;
        }
    }
}