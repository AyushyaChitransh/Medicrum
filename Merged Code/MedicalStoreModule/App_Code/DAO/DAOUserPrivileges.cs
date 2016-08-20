using MedicalStoreModule.App_Code.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.DAO
{
    public class DAOUserPrivileges
    {
        ConnectionManager cm = new ConnectionManager();
        public UserPrivileges GetUserPrivileges(string userName)
        {
            UserPrivileges privileges = new UserPrivileges();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT * FROM user_privileges WHERE user_name=@user_name";
                    cmd.Parameters.AddWithValue("@user_name", userName);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        privileges.addProductModel = int.Parse(dataReader["add_product_model"].ToString());
                        privileges.viewProductModel = int.Parse(dataReader["view_product_model"].ToString());
                        privileges.addProduct = int.Parse(dataReader["add_product"].ToString());
                        privileges.viewProduct = int.Parse(dataReader["view_product"].ToString());
                        privileges.addSupplier = int.Parse(dataReader["add_supplier"].ToString());
                        privileges.viewSupplier = int.Parse(dataReader["view_supplier"].ToString());
                        privileges.invoice = int.Parse(dataReader["invoice"].ToString());
                        privileges.addCustomer = int.Parse(dataReader["add_customer"].ToString());
                        privileges.viewCustomer = int.Parse(dataReader["view_customer"].ToString());
                    }
                    cm.CloseConnection();
                }
                return privileges;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return privileges;
            }
        }

        public bool CheckForAdminRole(string userName)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT role FROM user WHERE user_name=@user_name";
                    cmd.Parameters.AddWithValue("@user_name", userName);
                    cmd.Connection = cm.connection;
                    int role = int.Parse(cmd.ExecuteScalar().ToString());
                    cm.CloseConnection();
                    if (role == 1)
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
    }
}