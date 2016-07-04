using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.DAO
{
    public class DAOLogin
    {
        public bool VerifyUser(string email, string password)
        {
            ConnectionManager cm = new ConnectionManager();
            string qry = "SELECT count(*) FROM user where email=@email AND password=@password";
            if (cm.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                try
                {
                    if (cmd.ExecuteNonQuery()>0)
                    {
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
            return true;
        }
    }
}