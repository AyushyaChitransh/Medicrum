﻿using MedicalStoreModule.App_Code.DAO;
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
        public static object UserList(string userName, int jtStartIndex, int jtPageSize, string jtSorting)
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
            //UserName is being used as UserId for session
            HttpContext.Current.Session["userId"] = userName;
        }
    }
}