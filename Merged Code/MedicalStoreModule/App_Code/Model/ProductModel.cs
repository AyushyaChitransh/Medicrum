using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.Model
{
    public class ProductModel
    {
        public int productModelId { get; set; }
        public int storeId { get; set; }
        public string productName { get; set; }
        public string tradeName { get; set; }
        public string company { get; set; }
        public string composition { get; set; }
        public string purpose { get; set; }
        public string category { get; set; }
        public string subCategory { get; set; }
        public string type { get; set; }
        public string dosageInstruction { get; set; }
        public string storageInstruction { get; set; }
        public string schedule { get; set; }
        public string description { get; set; }
        public string otherInformation { get; set; }
        public string indications { get; set; }
        public string warning { get; set; }
        public string addedBy { get; set; }
        public System.DateTime addedTimestamp { get; set; }
        public string lastUpdatedBy { get; set; }
        public System.DateTime lastUpdatedTimestamp { get; set; }
        public Nullable<int> status { get; set; }
        public int deleteStatus { get; set; }
    }
}