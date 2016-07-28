using MedicalStoreModule.App_Code.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.DAO
{
    public class DAOSupplier
    {
        ConnectionManager cm = new ConnectionManager();
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
            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
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
                if (cm.OpenConnection())
                {
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

        public object SupplierList(string supplierStoreName, int storeId, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                int supplierCount = 0;
                List<Supplier> supplierList = new List<Supplier>();
                string[] sortOrder = jtSorting.Split(' ');
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT * FROM supplier 
                                        WHERE delete_status=@delete_status AND store_id=@store_id 
                                              AND ( supplier_store_name LIKE @searchText OR contact_person_name LIKE @searchText )
                                        ORDER BY supplier_store_name " + sortOrder[1] + " LIMIT @jtStartIndex,@jtPageSize";
                    cmd.Parameters.AddWithValue("@searchText", supplierStoreName + '%');
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Parameters.AddWithValue("@jtStartIndex", jtStartIndex);
                    cmd.Parameters.AddWithValue("@jtPageSize", jtPageSize);
                    cmd.Connection = cm.connection;
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
                    cm.CloseConnection();
                }
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM supplier WHERE delete_status=@delete_status AND store_id=@store_id AND contact_person_name like @searchText";
                    cmd.Parameters.AddWithValue("@searchText", supplierStoreName + "%");
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    supplierCount = int.Parse(cmd.ExecuteScalar().ToString());
                    cm.CloseConnection();
                }
                return new { Result = "OK", Records = supplierList, TotalRecordCount = supplierCount };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public Supplier GetSupplier(int supplierId)
        {
            Supplier selectedSupplier = new Supplier();
            string qry = "SELECT * FROM supplier where supplier_id=" + supplierId;
            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
            try
            {
                if (cm.OpenConnection())
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
                        cm.CloseConnection();
                        return selectedSupplier;
                    }
                    cm.CloseConnection();
                    return selectedSupplier;
                }
                return selectedSupplier;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return selectedSupplier;
            }
        }

        public object UpdateSupplier(Supplier supplier)
        {
            string qry = @"UPDATE supplier SET 
                                           contact_person_name=@contact_person_name,
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

            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
            cmd.Parameters.AddWithValue("@contact_person_name", supplier.contactPersonName);
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
                if (cm.OpenConnection())
                {
                    cmd.ExecuteNonQuery();
                    cm.CloseConnection();
                }
                return new { Result = "OK" };
            }
            catch (Exception e)
            {
                cm.CloseConnection();
                return new { Result = "Error", Message = e.Message };
            }
        }

        public object DeleteSupplier(int supplierId)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE supplier SET status=@status, delete_status=@delete_status
                                        WHERE supplier_id=@supplier_id";
                    cmd.Parameters.AddWithValue("@supplier_id", supplierId);
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
    }
}