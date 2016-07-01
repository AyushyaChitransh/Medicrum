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
    public partial class ViewDetailedProductModel : System.Web.UI.Page
    {
        private static int productModelId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["productModelId"] == null || !int.TryParse(Session["productModelId"].ToString(), out productModelId))
            {
                Response.Redirect("Error.aspx");
            }
            Session["productModelId"] = "";
        }

        [WebMethod]
        public static string GetProduct()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ConnectionManager conn = new ConnectionManager();
            return serializer.Serialize(conn.GetProduct(productModelId)).ToString();
        }
    }
}