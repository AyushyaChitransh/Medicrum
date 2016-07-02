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
            ConnectionManager connectionManager = new ConnectionManager();
            return connectionManager.InsertProduct(data);
        }

        [WebMethod]
        public static List<KeyValuePair<int, string>> GetProductModelForProduct()
        {
            int storeId = 1;
            ConnectionManager connectionManager = new ConnectionManager();
            return connectionManager.GetProductModelForProduct(storeId);
        }

        [WebMethod]
        public static List<KeyValuePair<int, string>> GetSupplierForProduct()
        {
            int storeId = 1;
            ConnectionManager connectionManager = new ConnectionManager();
            return connectionManager.GetSupplierForProduct(storeId);
        }
    }
}