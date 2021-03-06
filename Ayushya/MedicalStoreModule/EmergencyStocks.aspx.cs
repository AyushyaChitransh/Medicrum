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
    public partial class EmergencyStocks : System.Web.UI.Page
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
                if (privileges.viewProduct != 1)
                {
                    Response.Write("<script>alert('You are not allowed to access this particular page! Contact your store admin for access. You will be redirected to Dashboard'); window.location='Dashboard.aspx';</script>");
                }
            }
        }

        [WebMethod]
        public static object ProductEmergencyList(string productModelId, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            DAOStockProduct accessProductdb = new DAOStockProduct();
            return accessProductdb.ProductEmergencyList(productModelId, storeId, jtStartIndex, jtPageSize, jtSorting);
        }

        [WebMethod]
        public static object GetProductModelOptions()
        {
            DAOStockProduct accessProductdb = new DAOStockProduct();
            return accessProductdb.GetProductModelOptions(storeId);
        }

        [WebMethod]
        public static object GetSupplierOptions()
        {
            DAOStockProduct accessProductdb = new DAOStockProduct();
            return accessProductdb.GetSupplierOptions(storeId);
        }

        [WebMethod]
        public static object UpdateProduct(object record)
        {
            StockProduct product = new StockProduct();
            Dictionary<string, object> values = (Dictionary<string, object>)record;
            object output;
            int intTemp = new int();
            DateTime dateTimeTemp = new DateTime();
            decimal decimalTemp = new decimal();
            if (values.TryGetValue("productId", out output))
            {
                if (int.TryParse(output.ToString(), out intTemp))
                {
                    product.productId = intTemp;
                }
            }
            if (values.TryGetValue("productModelId", out output))
            {
                if (int.TryParse(output.ToString(), out intTemp))
                {
                    product.productModelId = intTemp;
                }
            }
            if (values.TryGetValue("supplierId", out output))
            {
                if (int.TryParse(output.ToString(), out intTemp))
                {
                    product.supplierId = intTemp;
                }
            }
            if (values.TryGetValue("barcode", out output))
            {
                if (int.TryParse(output.ToString(), out intTemp))
                {
                    product.barcode = intTemp;
                }
            }
            if (values.TryGetValue("batchNumber", out output))
            {
                product.batchNumber = output.ToString();
            }
            if (values.TryGetValue("manufactureDate", out output))
            {
                if (DateTime.TryParse(output.ToString(), out dateTimeTemp))
                {
                    product.manufactureDate = dateTimeTemp;
                }
            }
            if (values.TryGetValue("expiryDate", out output))
            {
                if (DateTime.TryParse(output.ToString(), out dateTimeTemp))
                {
                    product.expiryDate = dateTimeTemp;
                }
            }
            if (values.TryGetValue("packageQuantity", out output))
            {
                if (int.TryParse(output.ToString(), out intTemp))
                {
                    product.packageQuantity = intTemp;
                }
            }
            if (values.TryGetValue("price", out output))
            {
                if (decimal.TryParse(output.ToString(), out decimalTemp))
                {
                    product.price = decimalTemp;
                }
            }
            if (values.TryGetValue("manufactureLicenceNumber", out output))
            {
                product.manufactureLicenceNumber = output.ToString();
            }
            if (values.TryGetValue("weight", out output))
            {
                if (decimal.TryParse(output.ToString(), out decimalTemp))
                {
                    product.weight = decimalTemp;
                }
            }
            if (values.TryGetValue("volume", out output))
            {
                if (decimal.TryParse(output.ToString(), out decimalTemp))
                {
                    product.volume = decimalTemp;
                }
            }
            if (values.TryGetValue("quantity", out output))
            {
                if (int.TryParse(output.ToString(), out intTemp))
                {
                    product.quantity = intTemp;
                }
            }
            if (values.TryGetValue("tax", out output))
            {
                if (decimal.TryParse(output.ToString(), out decimalTemp))
                {
                    product.tax = decimalTemp;
                }
            }
            DAOStockProduct accessProductdb = new DAOStockProduct();
            return accessProductdb.UpdateProduct(product);
        }

        [WebMethod]
        public static object DeleteProduct(int productId)
        {
            DAOStockProduct accessProductdb = new DAOStockProduct();
            return accessProductdb.DeleteProduct(productId);
        }
    }
}