using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.Model
{
    public class Supplier
    {
        public int supplierId { get; set; }
        public int storeId { get; set; }
        public string supplierStoreName { get; set; }
        public string address { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string pincode { get; set; }
        public string licenceNumber { get; set; }
        public string contactPersonName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string mobile { get; set; }
        public string website { get; set; }
        public string addedBy { get; set; }
        public System.DateTime addedTimestamp { get; set; }
        public string lastUpdatedBy { get; set; }
        public System.DateTime lastUpdatedTimestamp { get; set; }
        public int? status { get; set; }
        public int deleteStatus { get; set; }
    }
}