using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.Model
{
    public class Customer
    {
        public int customerId { get; set; }
        public int storeId { get; set; }
        public string customerName { get; set; }
        public string companyName { get; set; }
        public string address { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string pincode { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> dateOfBirth { get; set; }
        public Nullable<int> height { get; set; }
        public Nullable<decimal> weight { get; set; }
        public string bloodGroup { get; set; }
        public string addedBy { get; set; }
        public System.DateTime addedTimestamp { get; set; }
        public string lastUpdatedBy { get; set; }
        public System.DateTime lastUpdatedTimestamp { get; set; }
        public Nullable<int> status { get; set; }
        public int deleteStatus { get; set; }
    }
}