using MedicalStoreModule.App_Code.DAO;
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
    public partial class ViewDetailedUser : System.Web.UI.Page
    {
        private static string userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("UserList.aspx");
            }
            else
            {
                userId = Session["userId"].ToString();
                Session["userId"] = "";
            }
        }
        [WebMethod]
        public static string GetUser()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            DAOUser accessUserDb = new DAOUser();
            return serializer.Serialize(accessUserDb.GetUser(userId)).ToString();
        }
    }
}