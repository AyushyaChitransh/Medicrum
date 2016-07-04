using MedicalStoreModule.App_Code.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.DAO
{
    public class DAOProductModel
    {
        ConnectionManager cm = new ConnectionManager();

        public bool InsertProductModel(ProductModel productModel)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    string parameters = "store_id, product_name, trade_name, company, category, type, added_by, added_timestamp, last_updated_by, last_updated_timestamp, delete_status";
                    string values = "@store_id, @product_name, @trade_name, @company, @category, @type, @added_by, @added_timestamp, @last_updated_by, @last_updated_timestamp, @delete_status";
                    cm.AddIfNotNull(productModel.composition, "composition", ref parameters, ref values);
                    cm.AddIfNotNull(productModel.purpose, "purpose", ref parameters, ref values);
                    cm.AddIfNotNull(productModel.subCategory, "sub_category", ref parameters, ref values);
                    cm.AddIfNotNull(productModel.dosageInstruction, "dosage_instruction", ref parameters, ref values);
                    cm.AddIfNotNull(productModel.storageInstruction, "storage_instruction", ref parameters, ref values);
                    cm.AddIfNotNull(productModel.schedule, "schedule", ref parameters, ref values);
                    cm.AddIfNotNull(productModel.description, "description", ref parameters, ref values);
                    cm.AddIfNotNull(productModel.otherInformation, "other_information", ref parameters, ref values);
                    cm.AddIfNotNull(productModel.indications, "indications", ref parameters, ref values);
                    cm.AddIfNotNull(productModel.warning, "warning", ref parameters, ref values);
                    cm.AddIfNotNull(productModel.status.ToString(), "status", ref parameters, ref values);
                    cmd.CommandText = "INSERT INTO product_model (" + parameters + ") VALUES (" + values + ")";
                    cmd.Parameters.AddWithValue("@store_id", productModel.storeId);
                    cmd.Parameters.AddWithValue("@product_name", productModel.productName);
                    cmd.Parameters.AddWithValue("@trade_name", productModel.tradeName);
                    cmd.Parameters.AddWithValue("@company", productModel.company);
                    cmd.Parameters.AddWithValue("@category", productModel.category);
                    cmd.Parameters.AddWithValue("@type", productModel.type);
                    cmd.Parameters.AddWithValue("@added_by", productModel.addedBy);
                    cmd.Parameters.AddWithValue("@added_timestamp", productModel.addedTimestamp);
                    cmd.Parameters.AddWithValue("@last_updated_by", productModel.lastUpdatedBy);
                    cmd.Parameters.AddWithValue("@last_updated_timestamp", productModel.lastUpdatedTimestamp);
                    cmd.Parameters.AddWithValue("@delete_status", productModel.deleteStatus);
                    if (productModel.composition != null)
                    {
                        cmd.Parameters.AddWithValue("@composition", productModel.composition);
                    }
                    if (productModel.purpose != null)
                    {
                        cmd.Parameters.AddWithValue("@purpose", productModel.purpose);
                    }
                    if (productModel.subCategory != null)
                    {
                        cmd.Parameters.AddWithValue("@sub_category", productModel.subCategory);
                    }
                    if (productModel.dosageInstruction != null)
                    {
                        cmd.Parameters.AddWithValue("@dosage_instruction", productModel.dosageInstruction);
                    }
                    if (productModel.storageInstruction != null)
                    {
                        cmd.Parameters.AddWithValue("@storage_instruction", productModel.storageInstruction);
                    }
                    if (productModel.schedule != null)
                    {
                        cmd.Parameters.AddWithValue("@schedule", productModel.schedule);
                    }
                    if (productModel.description != null)
                    {
                        cmd.Parameters.AddWithValue("@description", productModel.description);
                    }
                    if (productModel.otherInformation != null)
                    {
                        cmd.Parameters.AddWithValue("@other_information", productModel.otherInformation);
                    }
                    if (productModel.indications != null)
                    {
                        cmd.Parameters.AddWithValue("@indications", productModel.indications);
                    }
                    if (productModel.warning != null)
                    {
                        cmd.Parameters.AddWithValue("@warning", productModel.warning);
                    }
                    if (productModel.status != null)
                    {
                        cmd.Parameters.AddWithValue("@status", productModel.status);
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

        public object ProductModelList(string productName, int storeId, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                int productModelCount = 0;
                List<ProductModel> listProductModels = new List<ProductModel>();
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
                        ProductModel productModel = new ProductModel();
                        productModel.productModelId = int.Parse(dataReader["product_model_id"].ToString());
                        productModel.productName = dataReader["product_name"].ToString();
                        productModel.tradeName = dataReader["trade_name"].ToString();
                        productModel.company = dataReader["company"].ToString();
                        productModel.composition = dataReader["composition"].ToString();
                        productModel.purpose = dataReader["purpose"].ToString();
                        productModel.category = dataReader["category"].ToString();
                        productModel.subCategory = dataReader["sub_category"].ToString();
                        productModel.type = dataReader["type"].ToString();
                        productModel.dosageInstruction = dataReader["dosage_instruction"].ToString();
                        productModel.storageInstruction = dataReader["storage_instruction"].ToString();
                        productModel.schedule = dataReader["schedule"].ToString();
                        productModel.description = dataReader["description"].ToString();
                        productModel.otherInformation = dataReader["other_information"].ToString();
                        productModel.indications = dataReader["indications"].ToString();
                        productModel.warning = dataReader["warning"].ToString();
                        listProductModels.Add(productModel);
                    }
                    cm.CloseConnection();
                }
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM product_model WHERE delete_status=@delete_status AND store_id=@store_id AND product_name like @searchText";
                    cmd.Parameters.AddWithValue("@searchText", productName + "%");
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    productModelCount = int.Parse(cmd.ExecuteScalar().ToString());
                    cm.CloseConnection();
                }
                return new { Result = "OK", Records = listProductModels, TotalRecordCount = productModelCount };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public object UpdateProductModel(ProductModel productModel)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE product_model SET product_name=@product_name, trade_name=@trade_name, company=@company, 
                                        composition=@composition, purpose=@purpose, category=@category, sub_category=@sub_category, 
                                        type=@type, dosage_instruction=@dosage_instruction, storage_instruction=@storage_instruction, 
                                        schedule=@schedule, description=@description, other_information=@other_information, 
                                        indications=@indications, warning=@warning, last_updated_by=@last_updated_by, 
                                        last_updated_timestamp=@last_updated_timestamp WHERE product_model_id=@product_model_id";
                    cmd.Parameters.AddWithValue("@product_model_id", productModel.productModelId);
                    cmd.Parameters.AddWithValue("@product_name", productModel.productName);
                    cmd.Parameters.AddWithValue("@trade_name", productModel.tradeName);
                    cmd.Parameters.AddWithValue("@company", productModel.company);
                    cmd.Parameters.AddWithValue("@composition", productModel.composition);
                    cmd.Parameters.AddWithValue("@purpose", productModel.purpose);
                    cmd.Parameters.AddWithValue("@category", productModel.category);
                    cmd.Parameters.AddWithValue("@sub_category", productModel.subCategory);
                    cmd.Parameters.AddWithValue("@type", productModel.type);
                    cmd.Parameters.AddWithValue("@dosage_instruction", productModel.dosageInstruction);
                    cmd.Parameters.AddWithValue("@storage_instruction", productModel.storageInstruction);
                    cmd.Parameters.AddWithValue("@schedule", productModel.schedule);
                    cmd.Parameters.AddWithValue("@description", productModel.description);
                    cmd.Parameters.AddWithValue("@other_information", productModel.otherInformation);
                    cmd.Parameters.AddWithValue("@indications", productModel.indications);
                    cmd.Parameters.AddWithValue("@warning", productModel.warning);
                    cmd.Parameters.AddWithValue("@last_updated_by", productModel.lastUpdatedBy);
                    cmd.Parameters.AddWithValue("@last_updated_timestamp", productModel.lastUpdatedTimestamp);
                    cmd.Connection = cm.connection;
                    cmd.ExecuteNonQuery();
                    cm.CloseConnection();
                }
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public object DeleteProductModel(int productModelId)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE product_model SET status=@status, delete_status=@delete_status
                                        WHERE product_model_id=@product_model_id";
                    cmd.Parameters.AddWithValue("@product_model_id", productModelId);
                    cmd.Parameters.AddWithValue("@status", 0);
                    cmd.Parameters.AddWithValue("@delete_status", 1);
                    cmd.Connection = cm.connection;
                    cmd.ExecuteNonQuery();
                    cm.CloseConnection();
                }
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public ProductModel GetProductModel(int productModelId)
        {
            ProductModel productModel = new ProductModel();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT p.product_name, p.trade_name, p.company, p.composition, p.purpose, p.category, p.sub_category, 
                                    p.type, p.dosage_instruction, p.storage_instruction, p.schedule, p.description, p.other_information, 
                                    p.indications, p.warning, p.added_timestamp, p.last_updated_timestamp, 
                                    u1.name as added_by, u2.name as last_updated_by FROM product_model p 
                                    JOIN user u1 ON p.added_by = u1.user_name 
                                    JOIN user u2 ON p.last_updated_by = u2.user_name
                                    WHERE product_model_id=@product_model_id";
                    cmd.Parameters.AddWithValue("@product_model_id", productModelId);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        productModel.productName = dataReader["product_name"].ToString();
                        productModel.tradeName = dataReader["trade_name"].ToString();
                        productModel.company = dataReader["company"].ToString();
                        productModel.composition = dataReader["composition"].ToString();
                        productModel.purpose = dataReader["purpose"].ToString();
                        productModel.category = dataReader["category"].ToString();
                        productModel.subCategory = dataReader["sub_category"].ToString();
                        productModel.type = dataReader["type"].ToString();
                        productModel.dosageInstruction = dataReader["dosage_instruction"].ToString();
                        productModel.storageInstruction = dataReader["storage_instruction"].ToString();
                        productModel.schedule = dataReader["schedule"].ToString();
                        productModel.description = dataReader["description"].ToString();
                        productModel.otherInformation = dataReader["other_information"].ToString();
                        productModel.indications = dataReader["indications"].ToString();
                        productModel.warning = dataReader["warning"].ToString();
                        productModel.addedBy = dataReader["added_by"].ToString();
                        productModel.addedTimestamp = DateTime.Parse(dataReader["added_timestamp"].ToString());
                        productModel.lastUpdatedBy = dataReader["last_updated_by"].ToString();
                        productModel.lastUpdatedTimestamp = DateTime.Parse(dataReader["last_updated_timestamp"].ToString());
                    }
                    cm.CloseConnection();
                }
                return productModel;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return productModel;
            }
        }
    }
}