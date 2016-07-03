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
    public partial class ViewProductModel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object ProductModelList(string productName, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            ConnectionManager conn = new ConnectionManager();
            DAOProductModel accessProductModeldb = new DAOProductModel();
            int storeId = 1;
            return accessProductModeldb.ProductModelList(productName, storeId, jtStartIndex, jtPageSize, jtSorting);
        }

        [WebMethod]
        public static object UpdateProductModel(ProductModel record)
        {
            record.lastUpdatedBy = "ravi.jain";
            record.lastUpdatedTimestamp = DateTime.Now;
            DAOProductModel accessProductModeldb = new DAOProductModel();
            return accessProductModeldb.UpdateProductModel(record);
        }

        [WebMethod]
        public static object DeleteProductModel(int productModelId)
        {
            DAOProductModel accessProductModeldb = new DAOProductModel();
            return accessProductModeldb.DeleteProductModel(productModelId);
        }

        [WebMethod]
        public static void SetProductSession(int productModelId)
        {
            HttpContext.Current.Session["productModelId"] = productModelId;
        }
    }
}