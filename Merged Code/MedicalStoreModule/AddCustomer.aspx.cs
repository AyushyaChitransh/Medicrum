using MedicalStoreModule.App_Code.Model;
using ProdectModelModule.App_Code.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalStoreModule
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static bool InsertCustomer(Customer data)
        {
            data.storeId = 1;
            data.addedBy = "ravi.jain";
            data.addedTimestamp = DateTime.Now;
            data.lastUpdatedBy = "ravi.jain";
            data.lastUpdatedTimestamp = DateTime.Now;
            data.status = 1;
            data.deleteStatus = 0;
            DAOCustomer accessCustomerdb = new DAOCustomer();
            return accessCustomerdb.InsertCustomer(data);
        }
    }
}