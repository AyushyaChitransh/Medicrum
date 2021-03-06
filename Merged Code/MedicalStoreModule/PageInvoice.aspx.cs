﻿using MedicalStoreModule.App_Code.DAO;
using MedicalStoreModule.App_Code.Model;
using MedicalStoreModule.App_Code.Utility;
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
    public partial class PageInvoice : System.Web.UI.Page
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
                if (privileges.invoice != 1)
                {
                    Response.Write("<script>alert('You are not allowed to access this particular page! Contact your store admin for access. You will be redirected to Dashboard'); window.location='Dashboard.aspx';</script>");
                }
            }
        }

        [WebMethod]
        public static object InsertInvoice(string couponCode, int customerId, string discountType, int invoiceNumber, string invoiceType, string paymentMode, string paymentTerms, List<BillingItems> billingItems, string tax, string discount)
        {
            billingItems.RemoveAt(0);
            Invoice invoice = new Invoice();
            invoice.invoiceNumber = invoiceNumber;
            invoice.storeId = storeId;
            invoice.customerId = customerId;
            invoice.invoiceDate = DateTime.Now;
            invoice.invoiceType = invoiceType;
            invoice.paymentTerms = paymentTerms;
            invoice.paymentMode = paymentMode;
            invoice.discountType = discountType;
            invoice.couponCode = couponCode;
            // calculate total amount
            invoice.totalAmount = 0;
            foreach (BillingItems item in billingItems)
            {
                invoice.totalAmount += item.price;
            }
            decimal temp = new decimal();
            //calculate tax amount
            if (decimal.TryParse(tax, out temp))
            {
                invoice.taxAmount = invoice.totalAmount * (temp / 100);
            }
            else
            {
                invoice.taxAmount = 0;
            }
            //calculate discount amount
            if (decimal.TryParse(discount, out temp))
            {
                invoice.discountAmount = invoice.totalAmount * (temp / 100);
            }
            else
            {
                invoice.discountAmount = 0;
            }
            //calculate net total
            invoice.netTotal = invoice.totalAmount + invoice.taxAmount - invoice.discountAmount;
            invoice.amountPaid = invoice.netTotal;
            invoice.status = 1;
            invoice.deleteStatus = 0;

            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.InsertInvoice(invoice, billingItems, tax);
        }

        [WebMethod]
        public static object GetInvoiceNumber()
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.GetInvoiceNumber(storeId);
        }

        [WebMethod]
        public static object GetProductOptions()
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.GetProductOptions(storeId);
        }

        [WebMethod]
        public static object GetCustomerOptions()
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.GetCustomerOptions(storeId);
        }

        [WebMethod]
        public static object GetProductPrice(int productId)
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.GetProductPrice(productId);
        }

        public string InvoiceSidebarList()
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            List<object> invoiceList = accessInvoiceDb.GetInvoiceList("", storeId);
            string sidebarList = "";
            foreach (object item in invoiceList)
            {
                var invoiceId = item.GetType().GetProperty("invoiceId").GetValue(item, null);
                var invoiceNumber = item.GetType().GetProperty("invoiceNumber").GetValue(item, null);
                var invoiceDate = item.GetType().GetProperty("invoiceDate").GetValue(item, null);
                var customerName = item.GetType().GetProperty("customerName").GetValue(item, null);
                sidebarList += "<li><a href='#' class='md-list-content' data-invoice-id=" + invoiceId + "/>";
                sidebarList += "<span class='md-list-heading uk-text-truncate'>Invoice " + invoiceNumber + "<span class='uk-text-small uk-text-muted'> " + invoiceDate + "</span></span>";
                sidebarList += "<span class='uk-text-small uk-text-muted'>Customer " + customerName + "</span>";
            }
            return sidebarList;
        }

        [WebMethod]
        public static object InvoiceSideBar(string searchText)
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            List<object> invoiceList = accessInvoiceDb.GetInvoiceList(searchText, storeId);
            string sidebarList = "";
            foreach (object item in invoiceList)
            {
                var invoiceId = item.GetType().GetProperty("invoiceId").GetValue(item, null);
                var invoiceNumber = item.GetType().GetProperty("invoiceNumber").GetValue(item, null);
                var invoiceDate = item.GetType().GetProperty("invoiceDate").GetValue(item, null);
                var customerName = item.GetType().GetProperty("customerName").GetValue(item, null);
                sidebarList += "<li><a href='#' class='md-list-content' data-invoice-id=" + invoiceId + "/>";
                sidebarList += "<span class='md-list-heading uk-text-truncate'>Invoice " + invoiceNumber + "<span class='uk-text-small uk-text-muted'> " + invoiceDate + "</span></span>";
                sidebarList += "<span class='uk-text-small uk-text-muted'>Customer " + customerName + "</span>";
            }
            return sidebarList;
        }

        [WebMethod]
        public static object GetInvoice(int invoiceId)
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(accessInvoiceDb.GetInvoiceJson(invoiceId));
        }

        [WebMethod]
        public static object DeleteInvoice(int invoiceId)
        {
            DAOInvoice accessInvoiceDb = new DAOInvoice();
            return accessInvoiceDb.DeleteInvoice(invoiceId);
        }
    }
}