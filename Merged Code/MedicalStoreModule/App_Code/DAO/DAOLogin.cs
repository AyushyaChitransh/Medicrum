using MedicalStoreModule.App_Code.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.DAO
{
    public class DAOLogin
    {
        ConnectionManager cm = new ConnectionManager();
        public User VerifyUser(string email, string password)
        {
            User user = new User();
            try
            {
                string qry = "SELECT * FROM user where email=@email OR user_name=@email AND password=@password AND status=@status AND delete_status=@delete_status";
                if (cm.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@status", 1);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int storeId = new int();
                        if(int.TryParse(dataReader["store_id"].ToString(), out storeId))
                        {
                            user.storeId = storeId;
                        }
                        user.userName = dataReader["user_name"].ToString();
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
    }
}