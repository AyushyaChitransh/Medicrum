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
    public partial class SupplierList : System.Web.UI.Page
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
        public static object SupplierLists(string supplierStoreName, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            DAOSupplier accessSupplierdb = new DAOSupplier();
            return accessSupplierdb.SupplierList(supplierStoreName, storeId, jtStartIndex, jtPageSize, jtSorting);
        }

        [WebMethod]
        public static object UpdateSupplier(Supplier record)
        {
            record.lastUpdatedBy = userName;
            record.lastUpdatedTimestamp = DateTime.Now;
            DAOSupplier accessSupplierdb = new DAOSupplier();
            return accessSupplierdb.UpdateSupplier(record);
        }

        [WebMethod]
        public static object DeleteSupplier(int supplierId)
        {
            DAOSupplier accessSupplierdb = new DAOSupplier();
            return accessSupplierdb.DeleteSupplier(supplierId);
        }

        [WebMethod]
        public static void SetSupplierSession(int supplierId)
        {
            HttpContext.Current.Session["supplierId"] = supplierId;
        }
    }
}