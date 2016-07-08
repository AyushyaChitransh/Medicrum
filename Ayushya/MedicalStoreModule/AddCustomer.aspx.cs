﻿using MedicalStoreModule.App_Code.Model;
using MedicalStoreModule.App_Code.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalStoreModule
{
    public partial class AddCustomer : System.Web.UI.Page
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
        public static bool InsertCustomer(Customer data)
        {
            data.storeId = storeId;
            data.addedBy = userName;
            data.addedTimestamp = DateTime.Now;
            data.lastUpdatedBy = userName;
            data.lastUpdatedTimestamp = DateTime.Now;
            data.status = 1;
            data.deleteStatus = 0;
            DAOCustomer accessCustomerdb = new DAOCustomer();
            return accessCustomerdb.InsertCustomer(data);
        }
    }
}