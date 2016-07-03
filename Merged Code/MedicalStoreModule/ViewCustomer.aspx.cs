using MedicalStoreModule.App_Code.Model;
using MedicalStoreModule.App_Code.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalStoreModule
{
    public partial class ViewCustomer : System.Web.UI.Page
    {
        private static DAOCustomer accessCustomerDb = new DAOCustomer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object CustomerList(string customerName, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int storeId = 1;
            return accessCustomerDb.CustomerList(customerName, storeId, jtStartIndex, jtPageSize, jtSorting);
        }

        [WebMethod]
        public static object UpdateCustomer(Customer record)
        {
            record.lastUpdatedBy = "ravi.jain";
            record.lastUpdatedTimestamp = DateTime.Now;
            return accessCustomerDb.UpdateCustomer(record);
        }

        [WebMethod]
        public static object DeleteCustomer(int customerId)
        {
            return accessCustomerDb.DeleteCustomer(customerId);
        }

        [WebMethod]
        public static void SetCustomerSession(int customerId)
        {
            HttpContext.Current.Session["customerId"] = customerId;
        }
    }
}