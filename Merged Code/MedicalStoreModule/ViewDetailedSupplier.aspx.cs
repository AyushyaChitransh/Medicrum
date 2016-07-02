using MedicalStoreModule.App_Code.DAO;
using MedicalStoreModule.App_Code.Model;
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
    public partial class ViewDetailedSupplier : System.Web.UI.Page
    {
        private static int supplierId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supplierId"] == null || !int.TryParse(Session["supplierId"].ToString(), out supplierId))
            {
                Response.Redirect("Error.aspx");
            }
            Session["supplierId"] = "";
        }

        [WebMethod]
        public static string GetSupplier()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            DAOSupplier accessSupplierdb = new DAOSupplier();
            return serializer.Serialize(accessSupplierdb.GetSupplier(supplierId)).ToString();
        }
    }
}