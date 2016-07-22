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
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Visited page without link or without session
                if (Request.QueryString["q"] == null && Session["userName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                DAOUser accessUserDb = new DAOUser();
                User user = new User();
                // if reset is requested, then generate session and validate login details
                if (accessUserDb.CheckUpdateRequest(Request.QueryString["q"], out user))
                {
                    Session["storeId"] = user.storeId;
                    Session["userName"] = user.userName;
                }
                else
                {
                    Response.Write(@"<script>if(window.confirm('Link does not exist!')){window.location.href='Login.aspx';}</script>");
                    //Response.Redirect("Login.aspx");
                }
                // else if there is no update request and user wants to change password then use existing session
            }
        }
        [WebMethod]
        public static bool UpdatePassword(string password)
        {
            DAOUser accessUserDb = new DAOUser();
            return accessUserDb.UpdatePassword(password, HttpContext.Current.Session["userName"].ToString());
        }
    }
}