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
    public partial class UserList : System.Web.UI.Page
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
        public static object UserLists(string userName, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            DAOUser accessUserDb = new DAOUser();
            return accessUserDb.UserList(userName, storeId, jtStartIndex, jtPageSize, jtSorting);
        }

        [WebMethod]
        public static object UpdateUser(User record)
        {
            DAOUser accessUserDb = new DAOUser();
            return accessUserDb.UpdateUser(record);
        }

        [WebMethod]
        public static object DeleteUser(string userName)
        {
            DAOUser accessUserDb = new DAOUser();
            return accessUserDb.DeleteUser(userName);
        }

        [WebMethod]
        public static void SetUserSession(string userName)
        {
            HttpContext.Current.Session["userId"] = userName;
        }
    }
}