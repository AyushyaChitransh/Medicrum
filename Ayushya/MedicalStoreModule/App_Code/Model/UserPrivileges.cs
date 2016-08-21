using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.Model
{
    public class UserPrivileges
    {
        public int addProductModel { get; set; }
        public int viewProductModel { get; set; }
        public int addProduct { get; set; }
        public int viewProduct { get; set; }
        public int addSupplier { get; set; }
        public int viewSupplier { get; set; }
        public int invoice { get; set; }
        public int addCustomer { get; set; }
        public int viewCustomer { get; set; }
    }
}