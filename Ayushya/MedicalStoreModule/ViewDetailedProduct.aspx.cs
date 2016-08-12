using MedicalStoreModule.App_Code.DAO;
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
    public partial class ViewDetailedProduct : System.Web.UI.Page
    {
        private static int productId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["productId"] == null || !int.TryParse(Session["productId"].ToString(), out productId))
            {
                Response.Redirect("ProductList.aspx");
            }
            Session["productId"] = "";
        }

        [WebMethod]
        public static string GetProduct()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            DAOStockProduct accessProductdb = new DAOStockProduct();
            return serializer.Serialize(accessProductdb.GetProduct(productId)).ToString();
        }
    }
}