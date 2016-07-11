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
        static DAOInvoice accessInvoiceDb = new DAOInvoice();
        private static int storeId=1;

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
        public static object GetInvoice(int invoiceId)
        {
            Invoice record = new Invoice();
            record = accessInvoiceDb.GetInvoice(invoiceId);
            return record;
        }
        [WebMethod]
        public static object GetProductOptions()
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.GetProductOptions(storeId);
        }
        [WebMethod]
        public static Customer GetCustomerDetails(int customerId)
        {
            DAOCustomer accessCustomerDb = new DAOCustomer();
            return accessCustomerDb.GetCustomer(customerId);
        }
        [WebMethod]
        public static List<BillingItems> GetBillingItems(int invoiceId)
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.GetBillingItems(invoiceId);
        }
    }
}