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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static bool VerifyCredentials(string email, string password)
        {
            DAOLogin accessLogindb = new DAOLogin();
            User user = accessLogindb.VerifyUser(email, password);
            if(user.storeId != 0 && user.userName != null)
            {
                HttpContext.Current.Session["storeId"] = user.storeId;
                HttpContext.Current.Session["userName"] = user.userName;
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public static void Logout()
        {
            HttpContext.Current.Session["storeId"] = null;
            HttpContext.Current.Session["userName"] = null;
        }
    }
}