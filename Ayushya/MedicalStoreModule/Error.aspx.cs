using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalStoreModule
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["storeId"] == null && Session["userName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}