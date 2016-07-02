using MedicalStoreModule.App_Code.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.DAO
{
    public class DAOStockProduct
    {
        ConnectionManager cm = new ConnectionManager();
        public bool InsertProduct(StockProduct stockProduct)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    string parameters = "product_model_id, store_id, supplier_id, batch_number, manufacture_date, expiry_date, package_quantity, price, quantity, in_stock, delete_status";
                    string values = "@product_model_id, @store_id, @supplier_id, @batch_number, @manufacture_date, @expiry_date, @package_quantity, @price, @quantity, @in_stock, @delete_status";
                    cm.AddIfNotNull(stockProduct.barcode.ToString(), "barcode", ref parameters, ref values);
                    cm.AddIfNotNull(stockProduct.manufactureLicenceNumber, "manufacture_licence_number", ref parameters, ref values);
                    cm.AddIfNotNull(stockProduct.weight.ToString(), "weight", ref parameters, ref values);
                    cm.AddIfNotNull(stockProduct.volume.ToString(), "volume", ref parameters, ref values);
                    cm.AddIfNotNull(stockProduct.tax.ToString(), "tax", ref parameters, ref values);
                    cm.AddIfNotNull(stockProduct.status.ToString(), "status", ref parameters, ref values);
                    cmd.CommandText = "INSERT INTO stock_product (" + parameters + ") VALUES (" + values + ")";
                    cmd.Parameters.AddWithValue("@product_model_id", stockProduct.productModelId);
                    cmd.Parameters.AddWithValue("@store_id", stockProduct.storeId);
                    cmd.Parameters.AddWithValue("@supplier_id", stockProduct.supplierId);
                    cmd.Parameters.AddWithValue("@batch_number", stockProduct.batchNumber);
                    cmd.Parameters.AddWithValue("@manufacture_date", stockProduct.manufactureDate);
                    cmd.Parameters.AddWithValue("@expiry_date", stockProduct.expiryDate);
                    cmd.Parameters.AddWithValue("@package_quantity", stockProduct.packageQuantity);
                    cmd.Parameters.AddWithValue("@price", stockProduct.price);
                    cmd.Parameters.AddWithValue("@quantity", stockProduct.quantity);
                    cmd.Parameters.AddWithValue("@in_stock", stockProduct.inStock);
                    cmd.Parameters.AddWithValue("@delete_status", stockProduct.deleteStatus);
                    if (stockProduct.barcode != null)
                    {
                        cmd.Parameters.AddWithValue("@barcode", stockProduct.barcode);
                    }
                    if (stockProduct.manufactureLicenceNumber != null)
                    {
                        cmd.Parameters.AddWithValue("@manufacture_licence_number", stockProduct.manufactureLicenceNumber);
                    }
                    if (stockProduct.weight != null)
                    {
                        cmd.Parameters.AddWithValue("@weight", stockProduct.weight);
                    }
                    if (stockProduct.volume != null)
                    {
                        cmd.Parameters.AddWithValue("@volume", stockProduct.volume);
                    }
                    if (stockProduct.tax != null)
                    {
                        cmd.Parameters.AddWithValue("@tax", stockProduct.tax);
                    }
                    if (stockProduct.status != null)
                    {
                        cmd.Parameters.AddWithValue("@status", stockProduct.status);
                    }
                    cmd.Connection = cm.connection;
                    cmd.ExecuteNonQuery();
                    cm.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return false;
            }
        }

        //these are just the body of view module of stock product after updating remove this comment
        public object ProductList(string productName, int storeId, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                int productCount = 0;
                List<StockProduct> listProductModels = new List<StockProduct>();
                string[] sortOrder = jtSorting.Split(' ');
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT * FROM product_model 
                                        WHERE delete_status=@delete_status AND store_id=@store_id AND product_name LIKE @searchText 
                                        ORDER BY product_name " + sortOrder[1] + " LIMIT @jtStartIndex,@jtPageSize";
                    cmd.Parameters.AddWithValue("@searchText", productName + '%');
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Parameters.AddWithValue("@jtStartIndex", jtStartIndex);
                    cmd.Parameters.AddWithValue("@jtPageSize", jtPageSize);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        //StockProduct productModel = new StockProduct();
                        //productModel.productModelId = int.Parse(dataReader["product_model_id"].ToString());
                        //productModel.productName = dataReader["product_name"].ToString();
                        //productModel.tradeName = dataReader["trade_name"].ToString();
                        //productModel.company = dataReader["company"].ToString();
                        //productModel.composition = dataReader["composition"].ToString();
                        //productModel.purpose = dataReader["purpose"].ToString();
                        //productModel.category = dataReader["category"].ToString();
                        //productModel.subCategory = dataReader["sub_category"].ToString();
                        //productModel.type = dataReader["type"].ToString();
                        //productModel.dosageInstruction = dataReader["dosage_instruction"].ToString();
                        //productModel.storageInstruction = dataReader["storage_instruction"].ToString();
                        //productModel.schedule = dataReader["schedule"].ToString();
                        //productModel.description = dataReader["description"].ToString();
                        //productModel.otherInformation = dataReader["other_information"].ToString();
                        //productModel.indications = dataReader["indications"].ToString();
                        //productModel.warning = dataReader["warning"].ToString();
                        //listProductModels.Add(productModel);
                    }
                    cm.CloseConnection();
                }
                if (cm.OpenConnection() == true)
                {
                    //MySqlCommand cmd = new MySqlCommand();
                    //cmd.CommandText = "SELECT COUNT(*) FROM product_model WHERE delete_status=@delete_status AND product_name like @searchText";
                    //cmd.Parameters.AddWithValue("@searchText", productName + "%");
                    //cmd.Parameters.AddWithValue("@delete_status", 0);
                    //cmd.Connection = cm.connection;
                    //productCount = int.Parse(cmd.ExecuteScalar().ToString());
                    //cm.CloseConnection();
                }
                return new { Result = "OK", Records = listProductModels, TotalRecordCount = productCount };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public object UpdateProduct(StockProduct stockProduct)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    //                    MySqlCommand cmd = new MySqlCommand();
                    //                    cmd.CommandText = @"UPDATE product_model SET product_name=@product_name, trade_name=@trade_name, company=@company, 
                    //                                        composition=@composition, purpose=@purpose, category=@category, sub_category=@sub_category, 
                    //                                        type=@type, dosage_instruction=@dosage_instruction, storage_instruction=@storage_instruction, 
                    //                                        schedule=@schedule, description=@description, other_information=@other_information, 
                    //                                        indications=@indications, warning=@warning, last_updated_by=@last_updated_by, 
                    //                                        last_updated_timestamp=@last_updated_timestamp WHERE product_model_id=@product_model_id";
                    //                    cmd.Parameters.AddWithValue("@product_model_id", productModel.productModelId);
                    //                    cmd.Parameters.AddWithValue("@product_name", productModel.productName);
                    //                    cmd.Parameters.AddWithValue("@trade_name", productModel.tradeName);
                    //                    cmd.Parameters.AddWithValue("@company", productModel.company);
                    //                    cmd.Parameters.AddWithValue("@composition", productModel.composition);
                    //                    cmd.Parameters.AddWithValue("@purpose", productModel.purpose);
                    //                    cmd.Parameters.AddWithValue("@category", productModel.category);
                    //                    cmd.Parameters.AddWithValue("@sub_category", productModel.subCategory);
                    //                    cmd.Parameters.AddWithValue("@type", productModel.type);
                    //                    cmd.Parameters.AddWithValue("@dosage_instruction", productModel.dosageInstruction);
                    //                    cmd.Parameters.AddWithValue("@storage_instruction", productModel.storageInstruction);
                    //                    cmd.Parameters.AddWithValue("@schedule", productModel.schedule);
                    //                    cmd.Parameters.AddWithValue("@description", productModel.description);
                    //                    cmd.Parameters.AddWithValue("@other_information", productModel.otherInformation);
                    //                    cmd.Parameters.AddWithValue("@indications", productModel.indications);
                    //                    cmd.Parameters.AddWithValue("@warning", productModel.warning);
                    //                    cmd.Parameters.AddWithValue("@last_updated_by", productModel.lastUpdatedBy);
                    //                    cmd.Parameters.AddWithValue("@last_updated_timestamp", productModel.lastUpdatedTimestamp);
                    //                    cmd.Connection = connection;
                    //                    cmd.ExecuteNonQuery();
                    //                    this.CloseConnection();
                }
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public object DeleteProduct(int productId)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    //                    MySqlCommand cmd = new MySqlCommand();
                    //                    cmd.CommandText = @"UPDATE product_model SET status=@status, delete_status=@delete_status
                    //                                        WHERE product_model_id=@product_model_id";
                    //                    cmd.Parameters.AddWithValue("@product_model_id", productModelId);
                    //                    cmd.Parameters.AddWithValue("@status", 0);
                    //                    cmd.Parameters.AddWithValue("@delete_status", 1);
                    //                    cmd.Connection = connection;
                    //                    cmd.ExecuteNonQuery();
                    //                    this.CloseConnection();
                }
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public StockProduct GetProduct(int productId)
        {
            StockProduct stockProduct = new StockProduct();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    //                MySqlCommand cmd = new MySqlCommand();
                    //                cmd.CommandText = @"SELECT p.product_name, p.trade_name, p.company, p.composition, p.purpose, p.category, p.sub_category, 
                    //                                    p.type, p.dosage_instruction, p.storage_instruction, p.schedule, p.description, p.other_information, 
                    //                                    p.indications, p.warning, p.added_timestamp, p.last_updated_timestamp, 
                    //                                    u1.name as added_by, u2.name as last_updated_by FROM product_model p 
                    //                                    JOIN user u1 ON p.added_by = u1.user_name 
                    //                                    JOIN user u2 ON p.last_updated_by = u2.user_name
                    //                                    WHERE product_model_id=@product_model_id";
                    //                cmd.Parameters.AddWithValue("@product_model_id", productModelId);
                    //                cmd.Connection = connection;
                    //                MySqlDataReader dataReader = cmd.ExecuteReader();
                    //                while (dataReader.Read())
                    //                {
                    //                    productModel.productName = dataReader["product_name"].ToString();
                    //                    productModel.tradeName = dataReader["trade_name"].ToString();
                    //                    productModel.company = dataReader["company"].ToString();
                    //                    productModel.composition = dataReader["composition"].ToString();
                    //                    productModel.purpose = dataReader["purpose"].ToString();
                    //                    productModel.category = dataReader["category"].ToString();
                    //                    productModel.subCategory = dataReader["sub_category"].ToString();
                    //                    productModel.type = dataReader["type"].ToString();
                    //                    productModel.dosageInstruction = dataReader["dosage_instruction"].ToString();
                    //                    productModel.storageInstruction = dataReader["storage_instruction"].ToString();
                    //                    productModel.schedule = dataReader["schedule"].ToString();
                    //                    productModel.description = dataReader["description"].ToString();
                    //                    productModel.otherInformation = dataReader["other_information"].ToString();
                    //                    productModel.indications = dataReader["indications"].ToString();
                    //                    productModel.warning = dataReader["warning"].ToString();
                    //                    productModel.addedBy = dataReader["added_by"].ToString();
                    //                    productModel.addedTimestamp = DateTime.Parse(dataReader["added_timestamp"].ToString());
                    //                    productModel.lastUpdatedBy = dataReader["last_updated_by"].ToString();
                    //                    productModel.lastUpdatedTimestamp = DateTime.Parse(dataReader["last_updated_timestamp"].ToString());
                    //                }
                    //                this.CloseConnection();
                }
                return stockProduct;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return stockProduct;
            }
        }

        public List<KeyValuePair<int, string>> GetProductModelForProduct(int storeId)
        {
            List<KeyValuePair<int, string>> kvpList = new List<KeyValuePair<int, string>>();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT *
                                    FROM  product_model 
                                    WHERE delete_status=@delete_status AND store_id=@store_id";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        kvpList.Add(new KeyValuePair<int, string>(int.Parse(dataReader["product_model_id"].ToString()), dataReader["product_name"].ToString()));
                    }
                    cm.CloseConnection();
                }
                return kvpList;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return kvpList;
            }
        }

        public List<KeyValuePair<int, string>> GetSupplierForProduct(int storeId)
        {
            List<KeyValuePair<int, string>> kvpList = new List<KeyValuePair<int, string>>();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT *
                                    FROM supplier 
                                    WHERE delete_status=@delete_status AND store_id=@store_id";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        kvpList.Add(new KeyValuePair<int, string>(int.Parse(dataReader["supplier_id"].ToString()), dataReader["supplier_store_name"].ToString()));
                    }
                    cm.CloseConnection();
                }
                return kvpList;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return kvpList;
            }
        }
    }
}