using MedicalStoreModule.App_Code.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.DAO
{
    public class DAOStore
    {
        ConnectionManager cm = new ConnectionManager();
        public bool CheckStoreId(int storeId)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM store WHERE store_id=@store_id";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Connection = cm.connection;
                    int count = int.Parse(cmd.ExecuteScalar().ToString());
                    cm.CloseConnection();
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
                cm.CloseConnection();
                string message = ex.Message;
                return false;
            }
        }

        public bool InsertStore(Store store)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    string parameters = "store_id, store_name, country, currency, contact_person_name, email, registration_date ";
                    string values = "@store_id, @store_name, @country, @currency, @contact_person_name, @email, @registration_date";
                    cm.AddIfNotNull(store.phoneNumber, "phone_number", ref parameters, ref values);
                    cm.AddIfNotNull(store.mobileNumber, "mobile", ref parameters, ref values);
                    cm.AddIfNotNull(store.website, "website", ref parameters, ref values);
                    cm.AddIfNotNull(store.registrationStatus.ToString(), "registration_status", ref parameters, ref values);
                    cm.AddIfNotNull(store.validUpto.ToString(), "valid_upto", ref parameters, ref values);
                    cm.AddIfNotNull(store.storePlan.ToString(), "store_plan", ref parameters, ref values);
                    cm.AddIfNotNull(store.storeMode, "store_mode", ref parameters, ref values);
                    cm.AddIfNotNull(store.address, "address", ref parameters, ref values);
                    cm.AddIfNotNull(store.district, "district", ref parameters, ref values);
                    cm.AddIfNotNull(store.state, "state", ref parameters, ref values);
                    cm.AddIfNotNull(store.pincode, "pincode", ref parameters, ref values);
                    cm.AddIfNotNull(store.licenceNumber, "licence_number", ref parameters, ref values);
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
    }
}