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
                if (privileges.addProductModel != 1)
                {
                    Response.Write("<script>alert('You are not allowed to access this particular page! Contact your store admin for access. You will be redirected to Dashboard'); window.location='Dashboard.aspx';</script>");
                }
            }
        }

        [WebMethod]
        public static bool InsertProductModel(ProductModel data)
        {
            data.storeId = storeId;
            data.addedBy = userName;
            data.addedTimestamp = DateTime.Now;
            data.lastUpdatedBy = userName;
            data.lastUpdatedTimestamp = DateTime.Now;
            data.status = 1;
            data.deleteStatus = 0;
            DAOProductModel accessProductModeldb = new DAOProductModel();
            return accessProductModeldb.InsertProductModel(data);
        }

        [WebMethod]
        public static object GetCompanyName()
        {
            DAOProductModel accessProductModeldb = new DAOProductModel();
            return accessProductModeldb.GetCompanyName(storeId);
        }
    }
}