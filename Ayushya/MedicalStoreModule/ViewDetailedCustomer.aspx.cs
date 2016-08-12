using MedicalStoreModule.App_Code.DAO;
using MedicalStoreModule.App_Code.Model;
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
    public partial class ViewDetailedCustomer : System.Web.UI.Page
    {
        private static int customerId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customerId"] == null || !int.TryParse(Session["customerId"].ToString(), out customerId))
            {
                Response.Redirect("CustomerList.aspx");
            }
            Session["customerId"] = "";
        }
        [WebMethod]
        public static string GetCustomer()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            DAOCustomer accessCustomerDb = new DAOCustomer();
            return serializer.Serialize(accessCustomerDb.GetCustomer(customerId)).ToString();
        }
    }
}