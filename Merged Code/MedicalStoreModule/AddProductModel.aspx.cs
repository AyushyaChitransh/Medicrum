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
    public partial class AddProductModel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool InsertProductModel(ProductModel data)
        {
            data.storeId = 1;
            data.addedBy = "ravi.jain";
            data.addedTimestamp = DateTime.Now;
            data.lastUpdatedBy = "ravi.jain";
            data.lastUpdatedTimestamp = DateTime.Now;
            data.status = 1;
            data.deleteStatus = 0;
            ConnectionManager connectionManager = new ConnectionManager();
            return connectionManager.InsertProductModel(data);
        }
    }
}