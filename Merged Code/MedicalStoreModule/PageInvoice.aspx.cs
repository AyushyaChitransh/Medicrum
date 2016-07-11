using MedicalStoreModule.App_Code.DAO;
using MedicalStoreModule.App_Code.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        /*[WebMethod]
        public static object GetInvoice(int invoiceId)
        {
            Invoice record = new Invoice();
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            record = accessInvoiceDb.GetInvoice(invoiceId);
            return record;
        }*/

        /*[WebMethod]
        public static object GetProductOptions()
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.GetProductOptions(storeId);
        }*/

        /*[WebMethod]
        public static Customer GetCustomerDetails(int customerId)
        {
            DAOCustomer accessCustomerDb = new DAOCustomer();
            return accessCustomerDb.GetCustomer(customerId);
        }*/

        /*[WebMethod]
        public static List<BillingItems> GetBillingItems(int invoiceId)
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.GetBillingItems(invoiceId);
        }*/

        /*[WebMethod]
        public static bool DeleteInvoiceAndBIll(int invoiceId)
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.DeleteInvoiceAndBill(invoiceId);
        }*/        
    }
}