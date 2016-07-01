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
    public partial class ViewSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object SupplierList(string contactPersonName, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int storeId = 1;
            ConnectionManager conn = new ConnectionManager();
            return conn.SupplierList(contactPersonName, storeId, jtStartIndex, jtPageSize, jtSorting);
        }

        [WebMethod]
        public static object UpdateSupplier(Supplier record)
        {
            record.lastUpdatedBy = "ravi.jain";
            record.lastUpdatedTimestamp = DateTime.Now;
            ConnectionManager conn = new ConnectionManager();
            return conn.UpdateSupplier(record);
        }

        [WebMethod]
        public static object DeleteSupplier(int supplierId)
        {
            ConnectionManager conn = new ConnectionManager();
            return conn.DeleteSupplier(supplierId);
        }

        [WebMethod]
        public static void SetSupplierSession(int supplierId)
        {
            HttpContext.Current.Session["supplierId"] = supplierId;
        }
    }
}