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
    public partial class AddSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool InsertSupplier(Supplier data)
        {
            data.storeId = 1;
            data.addedBy = "ravi.jain";
            data.addedTimestamp = DateTime.Now;
            data.lastUpdatedBy = "ravi.jain";
            data.lastUpdatedTimestamp = DateTime.Now;
            data.status = 1;
            data.deleteStatus = 0;
            DAOSupplier accessSupplierdb = new DAOSupplier();
            return accessSupplierdb.InsertSupplier(data);
        }
    }
}