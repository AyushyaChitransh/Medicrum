using MedicalStoreModule.App_Code.DAO;
using MedicalStoreModule.App_Code.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdectModelModule.App_Code.DAO
{
    public class DAOCustomer
    {
        ConnectionManager cm = new ConnectionManager();
        public bool InsertCustomer(Customer record)
        {
            string qry = @"INSERT into customer
                                               (customer_id,
                                                store_id,
                                                customer_name,
                                                company_name,
                                                address,
                                                district,
                                                state,
                                                country,
                                                pincode,
                                                phone_number,
                                                mobile,
                                                email,
                                                date_of_birth,
                                                height,
                                                weight,
                                                blood_group,
                                                added_by,
                                                added_timestamp,
                                                last_updated_by,
                                                last_updated_timestamp,
                                                status,
                                                delete_status)
                                        VALUES
                                               (@customer_id,
                                                @store_id,
                                                @customer_name,
                                                @company_name,
                                                @address,
                                                @district,
                                                @state,
                                                @country,
                                                @pincode,
                                                @phone_number,
                                                @mobile,
                                                @email,
                                                @date_of_birth,
                                                @height,
                                                @weight,
                                                @blood_group,
                                                @added_by,
                                                @added_timestamp,
                                                @last_updated_by,
                                                @last_updated_timestamp,
                                                @status,
                                                @delete_status)";
            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
            cmd.Parameters.AddWithValue("@customer_id", record.customerId);
            cmd.Parameters.AddWithValue("@store_id", record.storeId);
            cmd.Parameters.AddWithValue("@customer_name", record.customerName);
            cmd.Parameters.AddWithValue("@company_name", record.companyName);
            cmd.Parameters.AddWithValue("@address", record.address);
            cmd.Parameters.AddWithValue("@district", record.district);
            cmd.Parameters.AddWithValue("@state", record.state);
            cmd.Parameters.AddWithValue("@country", record.country);
            cmd.Parameters.AddWithValue("@pincode", record.pincode);
            cmd.Parameters.AddWithValue("@phone_number", record.phoneNumber);
            cmd.Parameters.AddWithValue("@mobile", record.mobile);
            cmd.Parameters.AddWithValue("@email", record.email);
            cmd.Parameters.AddWithValue("@date_of_birth", record.dateOfBirth);
            cmd.Parameters.AddWithValue("@height", record.height);
            cmd.Parameters.AddWithValue("@weight", record.weight);
            cmd.Parameters.AddWithValue("@blood_group", record.bloodGroup);
            cmd.Parameters.AddWithValue("@added_by", record.addedBy);
            cmd.Parameters.AddWithValue("@added_timestamp", record.addedTimestamp);
            cmd.Parameters.AddWithValue("@last_updated_by", record.lastUpdatedBy);
            cmd.Parameters.AddWithValue("@last_updated_timestamp", record.lastUpdatedTimestamp);
            cmd.Parameters.AddWithValue("@status", record.status);
            cmd.Parameters.AddWithValue("@delete_status", record.deleteStatus);
            try
            {
                if (cm.OpenConnection())
                {
                    cmd.ExecuteNonQuery();
                    cm.CloseConnection();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return false;
        }
    }
}