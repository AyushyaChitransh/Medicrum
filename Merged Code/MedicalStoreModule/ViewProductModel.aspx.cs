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
    public partial class ViewProductModel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object ProductList(string productName, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            ConnectionManager conn = new ConnectionManager();
            int storeId = 1;
            return conn.ProductModelList(productName, storeId, jtStartIndex, jtPageSize, jtSorting);
        }

        [WebMethod]
        public static object UpdateProduct(ProductModel record)
        {
            record.lastUpdatedBy = "ravi.jain";
            record.lastUpdatedTimestamp = DateTime.Now;
            ConnectionManager conn = new ConnectionManager();
            return conn.UpdateProductModel(record);
        }

        [WebMethod]
        public static object DeleteProduct(int productModelId)
        {
            ConnectionManager conn = new ConnectionManager();
            return conn.DeleteProductModel(productModelId);
        }

        [WebMethod]
        public static void SetProductSession(int productModelId)
        {
            HttpContext.Current.Session["productModelId"] = productModelId;
        }
    }
}