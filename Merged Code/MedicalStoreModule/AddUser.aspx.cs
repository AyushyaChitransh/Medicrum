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
    public partial class AddUser : System.Web.UI.Page
    {
        private static int storeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["storeId"] != null && Session["userName"] != null)
                {
                    storeId = int.Parse(Session["storeId"].ToString());
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        [WebMethod]
        public static bool InsertUser(User data)
        {
            data.storeId = storeId;
            data.storeStatus = 1;
            data.status = 1;
            data.deleteStatus = 0;
            DAOUser accessUserdb = new DAOUser();
            return accessUserdb.InsertUser(data);
        }

        [WebMethod]
        public static bool CheckUserName(string userName)
        {
            DAOUser accessUserDb = new DAOUser();
            return accessUserDb.CheckUserName(userName);
        }

        [WebMethod]
        public static bool CheckEmail(string email)
        {
            DAOUser accessUserDb = new DAOUser();
            return accessUserDb.CheckEmail(email);
        }
    }
}