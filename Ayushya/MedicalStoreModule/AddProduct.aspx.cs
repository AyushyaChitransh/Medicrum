using MedicalStoreModule.App_Code.DAO;
using MedicalStoreModule.App_Code.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalStoreModule
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool InsertProduct(StockProduct data)
        {
            data.storeId = 1;
            data.status = 1;
            data.inStock = 1;
            data.deleteStatus = 0;
            DAOStockProduct accessStockProductdb = new DAOStockProduct();
            return accessStockProductdb.InsertProduct(data);
        }

        [WebMethod]
        public static object GetProductModelOptions()
        {
            int storeId = 1;
            DAOStockProduct accessStockProductdb = new DAOStockProduct();
            return accessStockProductdb.GetProductModelOptions(storeId);
        }

        [WebMethod]
        public static object GetSupplierOptions()
        {
            int storeId = 1;
            DAOStockProduct accessStockProductdb = new DAOStockProduct();
            return accessStockProductdb.GetSupplierOptions(storeId);
        }
    }
}