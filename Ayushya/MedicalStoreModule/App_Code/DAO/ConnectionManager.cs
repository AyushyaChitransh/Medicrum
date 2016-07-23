using MedicalStoreModule.App_Code.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
            //string MyConn = "Database=hungasty_medicrum_dev;Data Source=localhost;User Id=root;Password=root";
            connection = new MySqlConnection(MyConn);
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
        public void AddIfNotNull(string parameterValue, string parameterName, ref string parameterList, ref string parameterValues)
        {
            if (!string.IsNullOrEmpty(parameterValue))
            {
                parameterList += ", " + parameterName;
                parameterValues += ", @" + parameterName;
            }
        }

        #endregion Utility

    }
}