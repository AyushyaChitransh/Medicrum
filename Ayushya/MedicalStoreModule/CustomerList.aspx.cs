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
    public partial class CustomerList : System.Web.UI.Page
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
                UserPrivileges privileges = new UserPrivileges();
                privileges = accessUserPrivilegesDB.GetUserPrivileges(userName);
                if (privileges.viewCustomer != 1)
                {
                    Response.Write("<script>alert('You are not allowed to access this particular page! Contact your store admin for access. You will be redirected to Dashboard'); window.location='Dashboard.aspx';</script>");
                }
            }
        }

        [WebMethod]
        public static object CustomerLists(string customerName, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            DAOCustomer accessCustomerDb = new DAOCustomer();
            return accessCustomerDb.CustomerList(customerName, storeId, jtStartIndex, jtPageSize, jtSorting);
        }

        [WebMethod]
        public static object UpdateCustomer(Customer record)
        {
            DAOCustomer accessCustomerDb = new DAOCustomer();
            record.lastUpdatedBy = userName;
            record.lastUpdatedTimestamp = DateTime.Now;
            return accessCustomerDb.UpdateCustomer(record);
        }

        [WebMethod]
        public static object DeleteCustomer(int customerId)
        {
            DAOCustomer accessCustomerDb = new DAOCustomer();
            return accessCustomerDb.DeleteCustomer(customerId);
        }

        [WebMethod]
        public static void SetCustomerSession(int customerId)
        {
            HttpContext.Current.Session["customerId"] = customerId;
        }
    }
}