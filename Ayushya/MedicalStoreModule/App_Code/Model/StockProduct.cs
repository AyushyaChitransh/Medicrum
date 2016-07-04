using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.Model
{
    public class StockProduct
    {
        public int productId { get; set; }
        public int productModelId { get; set; }
        public int storeId { get; set; }
        public int supplierId { get; set; }
        public Nullable<int> barcode { get; set; }
        public string batchNumber { get; set; }
        public System.DateTime manufactureDate { get; set; }
        public System.DateTime expiryDate { get; set; }
        public int packageQuantity { get; set; }
        public decimal price { get; set; }
        public string manufactureLicenceNumber { get; set; }
        public Nullable<decimal> weight { get; set; }
        public Nullable<decimal> volume { get; set; }
        public int quantity { get; set; }
        public Nullable<decimal> tax { get; set; }
        public Nullable<int> status { get; set; }
        public int inStock { get; set; }
        public int deleteStatus { get; set; }
    }
}