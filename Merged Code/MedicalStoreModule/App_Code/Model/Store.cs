using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.Model
{
    public class Store
    {
        public int storeId { get; set; }
        public string storeName { get; set; }
        public string address { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string pincode { get; set; }
        public string currency { get; set; }
        public string licenceNumber { get; set; }
        public string contactPersonName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string mobileNumber { get; set; }
        public string website { get; set; }
        public Nullable<System.DateTime> registrationDate { get; set; }
        public Nullable<int> registrationStatus { get; set; }
        public Nullable<System.DateTime> validUpto { get; set; }
        public Nullable<int> storePlan { get; set; }
        public string storeMode { get; set; }
    }
}