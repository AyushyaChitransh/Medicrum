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
            DAOStore accessStoredb = new DAOStore();
            return accessStoredb.CheckStoreId(StoreId);
        }

        [WebMethod]
        public static bool InsertDetails(Store store, User user)
        {
            store.registrationDate = DateTime.Now;
            store.registrationStatus = 1;
            store.storePlan = 0;
            store.storeMode = "trial mode";
            store.validUpto = DateTime.Now.AddDays(14);

            user.name = store.contactPersonName;
            user.role = 1;
            user.status = 1;
            user.storeStatus = 1;
            user.deleteStatus = 0;
            DAOStore accessStoredb = new DAOStore();
            return accessStoredb.InsertStore(store);
        }
    }
}