﻿using MedicalStoreModule.App_Code.DAO;
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
    public partial class UserProfile : System.Web.UI.Page
    {
        private static string userName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["storeId"] != null && Session["userName"] != null)
                {
                    userName = Session["userName"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        [WebMethod]
        public static string GetUser()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            DAOUser accessUserDb = new DAOUser();
            return serializer.Serialize(accessUserDb.GetUser(userName)).ToString();
        }
    }
}