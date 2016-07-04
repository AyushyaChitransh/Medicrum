using MedicalStoreModule.App_Code.DAO;
using System;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace MedicalStoreModule
{
    public partial class ViewDetailedProduct : System.Web.UI.Page
    {
        private static int productId = 9;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["productId"] == null || !int.TryParse(Session["productId"].ToString(), out productId))
            //{
            //    Response.Redirect("Error.aspx");
            //}
            //Session["productId"] = "";
        }
        [WebMethod]
        public static string GetProduct()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            DAOStockProduct accessProductdb = new DAOStockProduct();
            string resultProduct = serializer.Serialize(accessProductdb.GetProduct(productId)).ToString();
            return resultProduct;
        }
    }
}