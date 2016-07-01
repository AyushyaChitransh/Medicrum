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
    public partial class AddStore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool CheckStoreId(int StoreId)
        {
            ConnectionManager conn = new ConnectionManager();
            return conn.CheckStoreId(StoreId);
        }

        [WebMethod]
        public static bool InsertStore(Store data)
        {
            data.registrationDate = DateTime.Now;
            data.registrationStatus = 1;
            data.storePlan = 0;
            data.storeMode = "trial mode";
            data.validUpto = DateTime.Now.AddDays(14);
            ConnectionManager conn = new ConnectionManager();
            return conn.InsertStore(data);
        }
    }
}