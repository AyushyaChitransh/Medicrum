using MedicalStoreModule.App_Code.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.DAO
{
    public class DAOUser
    {
        ConnectionManager cm = new ConnectionManager();
        public bool CheckUserName(string userName)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM user WHERE user_name=@user_name";
                    cmd.Parameters.AddWithValue("@user_name", userName);
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

        public bool CheckEmail(string email)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM user WHERE email=@email";
                    cmd.Parameters.AddWithValue("@email", email);
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

        public bool InsertUser(User record)
        {
            string qry = @"INSERT INTO user
                                          (user_name,
                                          name,
                                          role,
                                          store_id,
                                          password,
                                          email,
                                          phone_number,
                                          address,
                                          store_status,
                                          status,
                                          delete_status)
                                  VALUES
                                          (@user_name,
                                          @name,
                                          @role,
                                          @store_id,
                                          @password,
                                          @email,
                                          @phone_number,
                                          @address,
                                          @store_status,
                                          @status,
                                          @delete_status)";
            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
            cmd.Parameters.AddWithValue("@user_name", record.userName);
            cmd.Parameters.AddWithValue("@name", record.name);
            cmd.Parameters.AddWithValue("@role", record.role);
            cmd.Parameters.AddWithValue("@store_id", record.storeId);
            cmd.Parameters.AddWithValue("@password", record.password);
            cmd.Parameters.AddWithValue("@email", record.email);
            cmd.Parameters.AddWithValue("@phone_number", record.phoneNumber);
            cmd.Parameters.AddWithValue("@address", record.address);
            cmd.Parameters.AddWithValue("@store_status", record.storeStatus);
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
                cm.CloseConnection();
                string message = ex.Message;
                return false;
            }
        }

        public object UserList(string userName, int storeId, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                int userCount = 0;
                List<User> listUser = new List<User>();
                string[] sortOrder = jtSorting.Split(' ');
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT * FROM user 
                                        WHERE delete_status=@delete_status AND store_id=@store_id AND user_name LIKE @searchText 
                                        ORDER BY name " + sortOrder[1] + " LIMIT @jtStartIndex,@jtPageSize";
                    cmd.Parameters.AddWithValue("@searchText", userName + '%');
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Parameters.AddWithValue("@jtStartIndex", jtStartIndex);
                    cmd.Parameters.AddWithValue("@jtPageSize", jtPageSize);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        User singleUser = new User();
                        singleUser.userName = dataReader["user_name"].ToString();
                        singleUser.name = dataReader["name"].ToString();
                        singleUser.role = int.Parse(dataReader["role"].ToString());
                        singleUser.storeId = int.Parse(dataReader["store_id"].ToString());
                        singleUser.password = dataReader["password"].ToString();
                        singleUser.email = dataReader["email"].ToString();
                        singleUser.phoneNumber = dataReader["phone_number"].ToString();
                        singleUser.address = dataReader["address"].ToString();
                        int storeStatusTemp = new int();
                        if (int.TryParse(dataReader["store_status"].ToString(), out storeStatusTemp))
                        {
                            singleUser.storeStatus = storeStatusTemp;
                        }
                        int statusTemp = new int();
                        if (int.TryParse(dataReader["status"].ToString(), out statusTemp))
                        {
                            singleUser.status = statusTemp;
                        }
                        //delete_status is always zero as we have selected
                        singleUser.deleteStatus = 0;
                        listUser.Add(singleUser);
                    }
                    cm.CloseConnection();
                }
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM user WHERE delete_status=@delete_status AND store_id=@store_id AND user_name like @searchText";
                    cmd.Parameters.AddWithValue("@searchText", userName + "%");
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    userCount = int.Parse(cmd.ExecuteScalar().ToString());
                    cm.CloseConnection();
                }
                return new { Result = "OK", Records = listUser, TotalRecordCount = userCount };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public object UpdateUser(User record)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    string qry = @"UPDATE user SET
                                          name=@name,
                                          role=@role,
                                          password=@password,
                                          email=@email,
                                          phone_number=@phone_number,
                                          address=@address,
                                          status=@status
                                        WHERE 
                                          user_name=@user_name";
                    MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
                    cmd.Parameters.AddWithValue("@user_name", record.userName);
                    cmd.Parameters.AddWithValue("@name", record.name);
                    cmd.Parameters.AddWithValue("@role", record.role);
                    cmd.Parameters.AddWithValue("@password", record.password);
                    cmd.Parameters.AddWithValue("@email", record.email);
                    cmd.Parameters.AddWithValue("@phone_number", record.phoneNumber);
                    cmd.Parameters.AddWithValue("@address", record.address);
                    cmd.Parameters.AddWithValue("@status", record.status);
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

        public object DeleteUser(string userName)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE user SET status=@status, delete_status=@delete_status
                                        WHERE user_name=@user_name";
                    cmd.Parameters.AddWithValue("@user_name", userName);
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

        public User GetUser(string userName)
        {
            User user = new User();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT 
                                          user.user_name,
                                          user.name,
                                          user.role,
                                          user.store_id,
                                          user.password,
                                          user.email,
                                          user.phone_number,
                                          user.address,
                                          user.store_status,
                                          user.status
                                    FROM user
                                          WHERE user_name=@user_name";
                    cmd.Parameters.AddWithValue("@user_name", userName);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        user.userName = dataReader["user_name"].ToString();
                        user.name = dataReader["name"].ToString();
                        user.role = int.Parse(dataReader["role"].ToString());
                        user.storeId = int.Parse(dataReader["store_id"].ToString());
                        user.password = dataReader["password"].ToString();
                        user.email = dataReader["email"].ToString();
                        user.phoneNumber = dataReader["phone_number"].ToString();
                        user.address = dataReader["address"].ToString();
                        user.status = int.Parse(dataReader["status"].ToString());
                        user.storeStatus = int.Parse(dataReader["store_status"].ToString());
                    }
                    cm.CloseConnection();
                }
                return user;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return user;
            }
        }

        #region Password Reset
        public bool AddResetCode(string email, string resetPasswordCode)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    string qry = @"UPDATE user SET
                                          reset_password_code=@reset_password_code,
                                          reset_password_flag=@reset_password_flag
                                        WHERE 
                                          email=@email";
                    MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
                    cmd.Parameters.AddWithValue("@reset_password_code", resetPasswordCode);
                    cmd.Parameters.AddWithValue("@reset_password_flag", true);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();
                    cm.CloseConnection();
                }
                return true;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return false;
            }
        }

        public bool CheckForResetPasswordCodeUniqueness(string resetPasswordCode, out User userLoginDetails)
        {
            userLoginDetails = new User();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    string qry = @"SELECT 
                                          store_id,
                                          user_name
                                        FROM User
                                        WHERE 
                                          reset_password_code=@reset_password_code AND
                                          reset_password_flag=@reset_password_flag";
                    MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
                    cmd.Parameters.AddWithValue("@reset_password_code", resetPasswordCode);
                    cmd.Parameters.AddWithValue("@reset_password_flag", true);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        userLoginDetails.storeId = int.Parse(dataReader["store_id"].ToString());
                        userLoginDetails.userName = dataReader["user_name"].ToString();
                        cm.CloseConnection();
                        return true;
                    }
                    else
                    {
                        cm.CloseConnection();
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return false;
            }
        }

        public bool CheckForResetPasswordCodeUniqueness(string resetPasswordCode)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM user WHERE reset_password_code=@reset_password_code";
                    cmd.Parameters.AddWithValue("@reset_password_code", resetPasswordCode);
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

        public bool ExpireResetCode(string email)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    string qry = @"UPDATE user SET
                                          reset_password_code=@reset_password_code,
                                          reset_password_flag=@reset_password_flag,
                                        WHERE 
                                          email=@email";
                    MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
                    cmd.Parameters.AddWithValue("@reset_password_code", DBNull.Value);
                    cmd.Parameters.AddWithValue("@reset_password_flag", false);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();
                    cm.CloseConnection();
                }
                return true;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return false;
            }
        }

        public bool UpdatePassword(string password, string userName)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    string qry = @"UPDATE user SET
                                          password=@password,
                                          reset_password_code=@reset_password_code,
                                          reset_password_flag=@reset_password_flag
                                        WHERE 
                                          user_name=@user_name";
                    MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
                    cmd.Parameters.AddWithValue("@user_name", userName);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@reset_password_code", DBNull.Value);
                    cmd.Parameters.AddWithValue("@reset_password_flag", false);
                    cmd.ExecuteNonQuery();
                    cm.CloseConnection();
                }
                return true;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return false;
            }
        }
        #endregion
    }
}