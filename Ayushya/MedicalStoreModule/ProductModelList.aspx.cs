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
    public partial class ProductModelList : System.Web.UI.Page
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
                DAOUserPrivileges accessUserPrivilegesDB = new DAOUserPrivileges();
                UserPrivileges privileges = new UserPrivileges();
                privileges = accessUserPrivilegesDB.GetUserPrivileges(userName);
                if (privileges.viewProductModel != 1)
                {
                    Response.Write("<script>alert('You are not allowed to access this particular page! Contact your store admin for access. You will be redirected to Dashboard'); window.location='Dashboard.aspx';</script>");
                }
            }
        }

        [WebMethod]
        public static object ProductModelLists(string productName, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            DAOProductModel accessProductModeldb = new DAOProductModel();
            return accessProductModeldb.ProductModelList(productName, storeId, jtStartIndex, jtPageSize, jtSorting);
        }

        [WebMethod]
        public static object UpdateProductModel(ProductModel record)
        {
            record.lastUpdatedBy = userName;
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
        public static void SetProductModelSession(int productModelId)
        {
            HttpContext.Current.Session["productModelId"] = productModelId;
        }
    }
}