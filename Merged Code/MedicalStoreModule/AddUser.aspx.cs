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
                DAOUserPrivileges accessUserPrivilegesDB = new DAOUserPrivileges();
                if (!accessUserPrivilegesDB.CheckForAdminRole(userName))
                {
                    Response.Write("<script>alert('Only Store admin can access this page! You will be redirected to Dashboard'); window.location='Dashboard.aspx'</script>");
                }
            }
        }

        [WebMethod]
        public static bool InsertUser(User data, UserPrivileges userPrivileges)
        {
            data.storeId = storeId;
            data.storeStatus = 1;
            data.status = 1;
            data.deleteStatus = 0;
            DAOUser accessUserdb = new DAOUser();
            return accessUserdb.InsertUser(data,userPrivileges);
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