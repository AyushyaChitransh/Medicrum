using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.Model
{
    public class User
    {
        public string userName { get; set; }
        public string name { get; set; }
        public int role { get; set; }
        public int storeId { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public Nullable<int> storeStatus { get; set; }
        public Nullable<int> status { get; set; }
        public int deleteStatus { get; set; }
    }
}