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
    public partial class Dashboard : System.Web.UI.Page
    {
        private static int storeId;
        private static string userName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["storeId"] != null && Session["userName"] != null)
                {
                    storeId = int.Parse(Session["storeId"].ToString());
                    userName = Session["userName"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        [WebMethod]
        public static object GetSales()
        {
            DAOUserPrivileges accessUserPrivilegesDB = new DAOUserPrivileges();
            if (accessUserPrivilegesDB.CheckForAdminRole(userName))
            {
                DAODashboard accessInvoiceDb = new DAODashboard();
                return accessInvoiceDb.GetSales(storeId);
            }
            else
            {
                return false;
            }
        }

        public string InvoiceList()
        {
            DAODashboard accessInvoiceDb = new DAODashboard();
            List<object> invoiceList = accessInvoiceDb.InvoiceList(storeId);
            string list = "";
            foreach (object item in invoiceList)
            {
                var invoiceNumber = item.GetType().GetProperty("invoiceNumber").GetValue(item, null);
                var customerName = item.GetType().GetProperty("customerName").GetValue(item, null);
                list += "<tr class='uk-table-middle'><td class='uk-width-3-10 uk-text-nowrap'>Invoice Number: " + invoiceNumber + " | Customer Name: " + customerName + "</td></tr>";
            }
            return list;
        }

        public string OutOfStockList()
        {
            DAODashboard accessStockProductDb = new DAODashboard();
            List<object> invoiceList = accessStockProductDb.ProductEmptyList(storeId);
            string list = "";
            foreach (object item in invoiceList)
            {
                var productName = item.GetType().GetProperty("productName").GetValue(item, null);
                list += "<tr class='uk-table-middle'><td class='uk-width-3-10 uk-text-nowrap'>" + productName + "</td></tr>";
            }
            return list;
        }

        public string EmergencyStockList()
        {
            DAODashboard accessStockProductDb = new DAODashboard();
            List<object> invoiceList = accessStockProductDb.ProductEmergencyList(storeId);
            string list = "";
            foreach (object item in invoiceList)
            {
                var productName = item.GetType().GetProperty("productName").GetValue(item, null);
                list += "<tr class='uk-table-middle'><td class='uk-width-3-10 uk-text-nowrap'>" + productName + "</td></tr>";
            }
            return list;
        }

        [WebMethod]
        public static object GetUserPrivileges()
        {
            DAOUserPrivileges accessUserPrivilegesDB = new DAOUserPrivileges();
            return accessUserPrivilegesDB.GetUserPrivileges(userName);
        }
    }
}