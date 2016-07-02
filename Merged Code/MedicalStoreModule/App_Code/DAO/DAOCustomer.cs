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
                    return true;
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

        public object CustomerList(string customerName, int storeId, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int customerCount = 0;
            List<Customer> listCustomer = new List<Customer>();
            string[] sortOrder = jtSorting.Split(' ');
            string qry = @"SELECT * FROM 
                                        customer 
                                   WHERE delete_status=@delete_status AND
                                        store_id=@store_id AND 
                                        customer_name LIKE @searchText 
                                   ORDER BY customer_name " + sortOrder[1] + " LIMIT @jtStartIndex,@jtPageSize";
            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
            cmd.Parameters.AddWithValue("@searchText", customerName + '%');
            cmd.Parameters.AddWithValue("@store_id", storeId);
            cmd.Parameters.AddWithValue("@delete_status", 0);
            cmd.Parameters.AddWithValue("@jtStartIndex", jtStartIndex);
            cmd.Parameters.AddWithValue("@jtPageSize", jtPageSize);
            try
            {
                if (cm.OpenConnection())
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Customer singleCustommer = new Customer();
                        singleCustommer.customerId = int.Parse(dataReader["customer_id"].ToString());
                        singleCustommer.storeId = int.Parse(dataReader["store_id"].ToString());
                        singleCustommer.customerName = dataReader["customer_name"].ToString();
                        singleCustommer.companyName = dataReader["company_name"].ToString();
                        singleCustommer.address = dataReader["address"].ToString();
                        singleCustommer.district = dataReader["district"].ToString();
                        singleCustommer.state = dataReader["state"].ToString();
                        singleCustommer.country = dataReader["country"].ToString();
                        singleCustommer.pincode = dataReader["pincode"].ToString();
                        singleCustommer.phoneNumber = dataReader["phone_number"].ToString();
                        singleCustommer.mobile = dataReader["mobile"].ToString();
                        singleCustommer.email = dataReader["email"].ToString();
                        singleCustommer.dateOfBirth = DateTime.Parse(dataReader["date_of_birth"].ToString());
                        singleCustommer.height = int.Parse(dataReader["height"].ToString());
                        singleCustommer.weight = Decimal.Parse(dataReader["weight"].ToString());
                        singleCustommer.bloodGroup = dataReader["blood_group"].ToString();
                        singleCustommer.addedBy = dataReader["added_by"].ToString();
                        singleCustommer.addedTimestamp = DateTime.Parse(dataReader["added_timestamp"].ToString());
                        singleCustommer.lastUpdatedBy = dataReader["last_updated_by"].ToString();
                        singleCustommer.lastUpdatedTimestamp = DateTime.Parse(dataReader["last_updated_timestamp"].ToString());
                        singleCustommer.status = int.Parse(dataReader["status"].ToString());
                        listCustomer.Add(singleCustommer);
                    }
                    cm.CloseConnection();
                }
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.CommandText = "SELECT COUNT(*) FROM customer WHERE delete_status=@delete_status AND customer_name like @searchText";
                    cmd2.Parameters.AddWithValue("@searchText", customerName + "%");
                    cmd2.Parameters.AddWithValue("@delete_status", 0);
                    cmd2.Connection = cm.connection;
                    customerCount = int.Parse(cmd2.ExecuteScalar().ToString());
                    cm.CloseConnection();
                }
                return new { Result = "OK", Records = listCustomer, TotalRecordCount = customerCount };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }
        public object UpdateCustomer(Customer record)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    string qry = @"UPDATE customer SET
                                                customer_name=@customer_name,
                                                company_name=@company_name,
                                                address=@address,
                                                district=@district,
                                                state=@state,
                                                country=@country,
                                                pincode=@pincode,
                                                phone_number=@phone_number,
                                                mobile=@mobile,
                                                email=@email,
                                                date_of_birth=@date_of_birth,
                                                height=@height,
                                                weight=@weight,
                                                blood_group=@blood_group,
                                                last_updated_by=@last_updated_by,
                                                last_updated_timestamp=@last_updated_timestamp,
                                                status=@status
                                        WHERE
                                               customer_id=@customer_id";
                    MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
                    cmd.Parameters.AddWithValue("@customer_id", record.customerId);
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
                    cmd.Parameters.AddWithValue("@last_updated_by", record.lastUpdatedBy);
                    cmd.Parameters.AddWithValue("@last_updated_timestamp", record.lastUpdatedTimestamp);
                    cmd.Parameters.AddWithValue("@status", record.status);
                    cmd.ExecuteNonQuery();
                    cm.CloseConnection();
                }
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }
        public object DeleteCustomer(int customerId)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE customer SET status=@status, delete_status=@delete_status
                                        WHERE customer_id=@customer_id";
                    cmd.Parameters.AddWithValue("@customer_id", customerId);
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
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public Customer GetCustomer(int customerId)
        {
            Customer singleCustomer = new Customer();
            if (cm.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = @"SELECT customer_id,
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
                                u1.name as added_by,  
                                           added_timestamp,
                                u2.name as last_updated_by  
                                           last_updated_timestamp,
                                           status,
                                           delete_status
                                    FROM customer c
                                           JOIN user u1 ON p.added_by = u1.user_name  
                                           JOIN user u2 ON p.last_updated_by = u2.user_name
                                    WHERE customer_id=@customer_id";
                cmd.Parameters.AddWithValue("@customer_id", customerId);
                cmd.Connection = cm.connection;
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Customer singleCustommer = new Customer();
                    singleCustommer.customerId = int.Parse(dataReader["customer_id"].ToString());
                    singleCustommer.storeId = int.Parse(dataReader["store_id"].ToString());
                    singleCustommer.customerName = dataReader["customer_name"].ToString();
                    singleCustommer.companyName = dataReader["company_name"].ToString();
                    singleCustommer.address = dataReader["address"].ToString();
                    singleCustommer.district = dataReader["district"].ToString();
                    singleCustommer.state = dataReader["state"].ToString();
                    singleCustommer.country = dataReader["country"].ToString();
                    singleCustommer.pincode = dataReader["pincode"].ToString();
                    singleCustommer.phoneNumber = dataReader["phone_number"].ToString();
                    singleCustommer.mobile = dataReader["mobile"].ToString();
                    singleCustommer.email = dataReader["email"].ToString();
                    singleCustommer.dateOfBirth = DateTime.Parse(dataReader["date_of_birth"].ToString());
                    singleCustommer.height = int.Parse(dataReader["height"].ToString());
                    singleCustommer.weight = Decimal.Parse(dataReader["weight"].ToString());
                    singleCustommer.bloodGroup = dataReader["blood_group"].ToString();
                    singleCustommer.addedBy = dataReader["added_by"].ToString();
                    singleCustommer.addedTimestamp = DateTime.Parse(dataReader["added_timestamp"].ToString());
                    singleCustommer.lastUpdatedBy = dataReader["last_updated_by"].ToString();
                    singleCustommer.lastUpdatedTimestamp = DateTime.Parse(dataReader["last_updated_timestamp"].ToString());
                    singleCustommer.status = int.Parse(dataReader["status"].ToString());
                }
                cm.CloseConnection();
            }
            return singleCustomer;
        }
    }
}