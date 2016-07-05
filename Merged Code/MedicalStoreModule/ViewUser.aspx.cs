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
    public partial class ViewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object UserList(string userName, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int storeId = 1;
            DAOUser accessUserDb = new DAOUser();
            return accessUserDb.UserList(userName, storeId, jtStartIndex, jtPageSize, jtSorting);
        }

        [WebMethod]
        public static object UpdateUser(User record)
        {
            record.storeId = 1;
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