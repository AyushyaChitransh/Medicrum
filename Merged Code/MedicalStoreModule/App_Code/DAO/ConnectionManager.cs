using MedicalStoreModule.App_Code.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.DAO
{
    public class ConnectionManager
    {
        public MySqlConnection connection;

        #region DAO
        public ConnectionManager()
        {
            string MyConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string devConn = "Database=hungasty_medicrum_dev;Data Source=localhost;User Id=root;Password=root";
            connection = new MySqlConnection(MyConn);
            if (!this.OpenConnection())
            {
                this.connection = new MySqlConnection(devConn);
            }
            else
            {
                this.CloseConnection();
            }
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                int errorNumber = ex.Number;
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                int errorNumber = ex.Number;
                return false;
            }
        }

        #endregion DAO

        #region Utility
        private void AddIfNotNull(string parameterValue, string parameterName, ref string parameterList, ref string parameterValues)
        {
            if (!string.IsNullOrEmpty(parameterValue))
            {
                parameterList += ", " + parameterName;
                parameterValues += ", @" + parameterName;
            }
        }

        #endregion Utility

        #region Store Module
        public bool CheckStoreId(int storeId)
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM store WHERE store_id=@store_id";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Connection = connection;
                    int count = int.Parse(cmd.ExecuteScalar().ToString());
                    this.CloseConnection();
                    if (count == 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertStore(Store store)
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    string parameters = "store_id, store_name, country, currency, contact_person_name, email, registration_date ";
                    string values = "@store_id, @store_name, @country, @currency, @contact_person_name, @email, @registration_date";
                    AddIfNotNull(store.phoneNumber, "phone_number", ref parameters, ref values);
                    AddIfNotNull(store.mobileNumber, "mobile", ref parameters, ref values);
                    AddIfNotNull(store.website, "website", ref parameters, ref values);
                    AddIfNotNull(store.registrationStatus.ToString(), "registration_status", ref parameters, ref values);
                    AddIfNotNull(store.validUpto.ToString(), "valid_upto", ref parameters, ref values);
                    AddIfNotNull(store.storePlan.ToString(), "store_plan", ref parameters, ref values);
                    AddIfNotNull(store.storeMode, "store_mode", ref parameters, ref values);
                    AddIfNotNull(store.address, "address", ref parameters, ref values);
                    AddIfNotNull(store.district, "district", ref parameters, ref values);
                    AddIfNotNull(store.state, "state", ref parameters, ref values);
                    AddIfNotNull(store.pincode, "pincode", ref parameters, ref values);
                    AddIfNotNull(store.licenceNumber, "licence_number", ref parameters, ref values);
                    cmd.CommandText = "INSERT INTO store (" + parameters + ") VALUES (" + values + ")";
                    cmd.Parameters.AddWithValue("@store_id", store.storeId);
                    cmd.Parameters.AddWithValue("@store_name", store.storeName);
                    cmd.Parameters.AddWithValue("@currency", store.currency);
                    cmd.Parameters.AddWithValue("@contact_person_name", store.contactPersonName);
                    cmd.Parameters.AddWithValue("@registration_date", store.registrationDate);
                    cmd.Parameters.AddWithValue("@email", store.email);
                    cmd.Parameters.AddWithValue("@country", store.country);
                    if (store.pincode != null)
                    {
                        cmd.Parameters.AddWithValue("@pincode", store.pincode);
                    }
                    if (store.licenceNumber != null)
                    {
                        cmd.Parameters.AddWithValue("@licence_number", store.licenceNumber);
                    }
                    if (store.phoneNumber != null)
                    {
                        cmd.Parameters.AddWithValue("@phone_number", store.phoneNumber);
                    }
                    if (store.mobileNumber != null)
                    {
                        cmd.Parameters.AddWithValue("@mobile", store.mobileNumber);
                    }
                    if (store.website != null)
                    {
                        cmd.Parameters.AddWithValue("@website", store.website);
                    }
                    if (store.registrationStatus != null)
                    {
                        cmd.Parameters.AddWithValue("@registration_status", store.registrationStatus);
                    }
                    if (store.validUpto != null)
                    {
                        cmd.Parameters.AddWithValue("@valid_upto", store.validUpto);
                    }
                    if (store.address != null)
                    {
                        cmd.Parameters.AddWithValue("@address", store.address);
                    }
                    if (store.storePlan != null)
                    {
                        cmd.Parameters.AddWithValue("@store_plan", store.storePlan);
                    }
                    if (store.district != null)
                    {
                        cmd.Parameters.AddWithValue("@district", store.district);
                    }
                    if (store.state != null)
                    {
                        cmd.Parameters.AddWithValue("@state", store.state);
                    }
                    if (store.storeMode != null)
                    {
                        cmd.Parameters.AddWithValue("@store_mode", store.storeMode);
                    }
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion Store Module

        #region Product Module
        public bool InsertProduct(ProductModel productModel)
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    string parameters = "store_id, product_name, trade_name, company, category, type, added_by, added_timestamp, last_updated_by, last_updated_timestamp, delete_status";
                    string values = "@store_id, @product_name, @trade_name, @company, @category, @type, @added_by, @added_timestamp, @last_updated_by, @last_updated_timestamp, @delete_status";
                    AddIfNotNull(productModel.composition, "composition", ref parameters, ref values);
                    AddIfNotNull(productModel.purpose, "purpose", ref parameters, ref values);
                    AddIfNotNull(productModel.subCategory, "sub_category", ref parameters, ref values);
                    AddIfNotNull(productModel.dosageInstruction, "dosage_instruction", ref parameters, ref values);
                    AddIfNotNull(productModel.storageInstruction, "storage_instruction", ref parameters, ref values);
                    AddIfNotNull(productModel.schedule, "schedule", ref parameters, ref values);
                    AddIfNotNull(productModel.description, "description", ref parameters, ref values);
                    AddIfNotNull(productModel.otherInformation, "other_information", ref parameters, ref values);
                    AddIfNotNull(productModel.indications, "indications", ref parameters, ref values);
                    AddIfNotNull(productModel.warning, "warning", ref parameters, ref values);
                    AddIfNotNull(productModel.status.ToString(), "status", ref parameters, ref values);
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
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public object ProductList(string productName, int storeId, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                int productCount = 0;
                List<ProductModel> listProductModels = new List<ProductModel>();
                string[] sortOrder = jtSorting.Split(' ');
                if (this.OpenConnection() == true)
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
                    cmd.Connection = connection;
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
                    this.CloseConnection();
                }
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM product_model WHERE delete_status=@delete_status AND product_name like @searchText";
                    cmd.Parameters.AddWithValue("@searchText", productName + "%");
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = connection;
                    productCount = int.Parse(cmd.ExecuteScalar().ToString());
                    this.CloseConnection();
                }
                return new { Result = "OK", Records = listProductModels, TotalRecordCount = productCount };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public object UpdateProduct(ProductModel productModel)
        {
            try
            {
                if (this.OpenConnection() == true)
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
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public object DeleteProduct(int productModelId)
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE product_model SET status=@status, delete_status=@delete_status
                                        WHERE product_model_id=@product_model_id";
                    cmd.Parameters.AddWithValue("@product_model_id", productModelId);
                    cmd.Parameters.AddWithValue("@status", 0);
                    cmd.Parameters.AddWithValue("@delete_status", 1);
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public ProductModel GetProduct(int productModelId)
        {
            ProductModel productModel = new ProductModel();
            if (this.OpenConnection() == true)
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
                cmd.Connection = connection;
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
                this.CloseConnection();
            }
            return productModel;
        }

        #endregion Product Module

        #region Supplier
        public bool InsertSupplier(Supplier supplier)
        {
            string qry = @"INSERT into supplier
                                              (added_by,
                                               added_timestamp,
                                               address,
                                               contact_person_name,
                                               country,
                                               delete_status,
                                               district,
                                               email,
                                               last_updated_by,
                                               last_updated_timestamp,
                                               licence_number,
                                               mobile,
                                               phone_number,
                                               pincode,
                                               state,
                                               status,
                                               store_id,
                                               supplier_store_name,
                                               website)
                                        VALUES
                                              (@added_by,
                                               @added_timestamp,
                                               @address,
                                               @contact_person_name,
                                               @country,
                                               @delete_status,
                                               @district,
                                               @email,
                                               @last_updated_by,
                                               @last_updated_timestamp,
                                               @licence_number,
                                               @mobile,
                                               @phone_number,
                                               @pincode,
                                               @state,
                                               @status,
                                               @store_id,
                                               @supplier_store_name,
                                               @website)";
            MySqlCommand cmd = new MySqlCommand(qry, connection);
            cmd.Parameters.AddWithValue("@added_by", supplier.addedBy);
            cmd.Parameters.AddWithValue("@added_timestamp", supplier.addedTimestamp);
            cmd.Parameters.AddWithValue("@address", supplier.address);
            cmd.Parameters.AddWithValue("@contact_person_name", supplier.contactPersonName);
            cmd.Parameters.AddWithValue("@country", supplier.country);
            cmd.Parameters.AddWithValue("@delete_status", supplier.deleteStatus);
            cmd.Parameters.AddWithValue("@district", supplier.district);
            cmd.Parameters.AddWithValue("@email", supplier.email);
            cmd.Parameters.AddWithValue("@last_updated_by", supplier.lastUpdatedBy);
            cmd.Parameters.AddWithValue("@last_updated_timestamp", supplier.lastUpdatedTimestamp);
            cmd.Parameters.AddWithValue("@licence_number", supplier.licenceNumber);
            cmd.Parameters.AddWithValue("@mobile", supplier.mobile);
            cmd.Parameters.AddWithValue("@phone_number", supplier.phoneNumber);
            cmd.Parameters.AddWithValue("@pincode", supplier.pincode);
            cmd.Parameters.AddWithValue("@state", supplier.state);
            cmd.Parameters.AddWithValue("@status", supplier.status);
            cmd.Parameters.AddWithValue("@store_id", supplier.storeId);
            cmd.Parameters.AddWithValue("@supplier_id", supplier.supplierId);
            cmd.Parameters.AddWithValue("@supplier_store_name", supplier.supplierStoreName);
            cmd.Parameters.AddWithValue("@website", supplier.website);
            try
            {
                if (this.OpenConnection())
                {
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public object SupplierList(string contactPersonName, int storeId, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                int supplierCount = 0;
                List<Supplier> supplierList = new List<Supplier>();
                string[] sortOrder = jtSorting.Split(' ');
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT * FROM supplier 
                                        WHERE delete_status=@delete_status AND store_id=@store_id AND contact_person_name LIKE @searchText 
                                        ORDER BY contact_person_name " + sortOrder[1] + " LIMIT @jtStartIndex,@jtPageSize";
                    cmd.Parameters.AddWithValue("@searchText", contactPersonName + '%');
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Parameters.AddWithValue("@jtStartIndex", jtStartIndex);
                    cmd.Parameters.AddWithValue("@jtPageSize", jtPageSize);
                    cmd.Connection = this.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Supplier supplierObj = new Supplier();
                        //Not Null values
                        supplierObj.supplierId = int.Parse(dataReader["supplier_id"].ToString());
                        supplierObj.supplierStoreName = dataReader["supplier_store_name"].ToString();
                        supplierObj.addedTimestamp = DateTime.Parse(dataReader["added_timestamp"].ToString());
                        supplierObj.lastUpdatedTimestamp = DateTime.Parse(dataReader["last_updated_timestamp"].ToString());
                        //Nullable values
                        supplierObj.contactPersonName = dataReader["contact_person_name"].ToString();
                        supplierObj.address = dataReader["address"].ToString();
                        supplierObj.district = dataReader["district"].ToString();
                        supplierObj.state = dataReader["state"].ToString();
                        supplierObj.country = dataReader["country"].ToString();
                        supplierObj.pincode = dataReader["pincode"].ToString();
                        supplierObj.licenceNumber = dataReader["licence_number"].ToString();
                        supplierObj.email = dataReader["email"].ToString();
                        supplierObj.phoneNumber = dataReader["phone_number"].ToString();
                        supplierObj.mobile = dataReader["phone_number"].ToString();
                        supplierObj.website = dataReader["website"].ToString();
                        supplierObj.addedBy = dataReader["added_by"].ToString();
                        supplierList.Add(supplierObj);
                    }
                    this.CloseConnection();
                }
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM supplier WHERE delete_status=@delete_status AND contact_person_name like @searchText";
                    cmd.Parameters.AddWithValue("@searchText", contactPersonName + "%");
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = this.connection;
                    supplierCount = int.Parse(cmd.ExecuteScalar().ToString());
                    this.CloseConnection();
                }
                return new { Result = "OK", Records = supplierList, TotalRecordCount = supplierCount };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }
        public Supplier GetSupplier(int supplierId)
        {
            Supplier selectedSupplier = new Supplier();
            string qry = "SELECT * FROM supplier where supplier_id=" + supplierId;
            MySqlCommand cmd = new MySqlCommand(qry, this.connection);
            try
            {
                if (this.OpenConnection())
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        selectedSupplier.addedBy = dataReader["added_by"].ToString();
                        selectedSupplier.addedTimestamp = DateTime.Parse(dataReader["added_timestamp"].ToString());
                        selectedSupplier.address = dataReader["address"].ToString();
                        selectedSupplier.contactPersonName = dataReader["contact_person_name"].ToString();
                        selectedSupplier.country = dataReader["country"].ToString();
                        selectedSupplier.deleteStatus = int.Parse(dataReader["delete_status"].ToString());
                        selectedSupplier.district = dataReader["district"].ToString();
                        selectedSupplier.email = dataReader["email"].ToString();
                        selectedSupplier.lastUpdatedBy = dataReader["last_updated_by"].ToString();
                        selectedSupplier.lastUpdatedTimestamp = DateTime.Parse(dataReader["last_updated_timestamp"].ToString());
                        selectedSupplier.licenceNumber = dataReader["licence_number"].ToString();
                        selectedSupplier.mobile = dataReader["mobile"].ToString();
                        selectedSupplier.phoneNumber = dataReader["phone_number"].ToString();
                        selectedSupplier.pincode = dataReader["pincode"].ToString();
                        selectedSupplier.state = dataReader["state"].ToString();
                        selectedSupplier.status = int.Parse(dataReader["status"].ToString());
                        selectedSupplier.supplierId = int.Parse(dataReader["supplier_id"].ToString());
                        selectedSupplier.supplierStoreName = dataReader["supplier_store_name"].ToString();
                        selectedSupplier.website = dataReader["website"].ToString();
                        this.CloseConnection();
                        return selectedSupplier;
                    }
                    this.CloseConnection();
                    return selectedSupplier;
                }
                return selectedSupplier;
            }
            catch (Exception ex)
            {
                return selectedSupplier;
            }
        }
        public object UpdateSupplier(Supplier supplier)
        {
            string qry = @"UPDATE supplier SET 
                                           address=@address, 
                                           country=@country, 
                                           district=@district, 
                                           email=@email, 
                                           last_updated_by=@last_updated_by, 
                                           last_updated_timestamp=@last_updated_timestamp, 
                                           licence_number=@licence_number,
                                           mobile=@mobile, 
                                           phone_number=@phone_number, 
                                           pincode=@pincode, 
                                           state=@state,
                                           supplier_store_name=@supplier_store_name, 
                                           website=@website
                                WHERE supplier_id=@supplier_id";

            MySqlCommand cmd = new MySqlCommand(qry, connection);
            cmd.Parameters.AddWithValue("@address", supplier.address);
            cmd.Parameters.AddWithValue("@country", supplier.country);
            cmd.Parameters.AddWithValue("@district", supplier.district);
            cmd.Parameters.AddWithValue("@email", supplier.email);
            cmd.Parameters.AddWithValue("@last_updated_by", supplier.lastUpdatedBy);
            cmd.Parameters.AddWithValue("@last_updated_timestamp", supplier.lastUpdatedTimestamp);
            cmd.Parameters.AddWithValue("@licence_number", supplier.licenceNumber);
            cmd.Parameters.AddWithValue("@mobile", supplier.mobile);
            cmd.Parameters.AddWithValue("@phone_number", supplier.phoneNumber);
            cmd.Parameters.AddWithValue("@pincode", supplier.pincode);
            cmd.Parameters.AddWithValue("@state", supplier.state);
            cmd.Parameters.AddWithValue("@supplier_store_name", supplier.supplierStoreName);
            cmd.Parameters.AddWithValue("@website", supplier.website);
            cmd.Parameters.AddWithValue("@supplier_id", supplier.supplierId);

            try
            {
                if (this.OpenConnection())
                {
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
                return new { Result = "OK" };
            }
            catch (Exception e)
            {
                return new { Result = "Error", Message = e.Message };
            }
        }
        public object DeleteSupplier(int supplierId)
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE supplier SET status=@status, delete_status=@delete_status
                                        WHERE supplier_id=@supplier_id";
                    cmd.Parameters.AddWithValue("@supplier_id", supplierId);
                    cmd.Parameters.AddWithValue("@status", 0);
                    cmd.Parameters.AddWithValue("@delete_status", 1);
                    cmd.Connection = this.connection;
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        #endregion Supplier
    }
}