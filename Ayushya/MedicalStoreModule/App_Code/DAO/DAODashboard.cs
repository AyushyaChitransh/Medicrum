using MedicalStoreModule.App_Code.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.DAO
{
    public class DAODashboard
    {
        ConnectionManager cm = new ConnectionManager();
        public List<object> InvoiceList(int storeId)
        {
            List<object> invoiceList = new List<object>();
            string qry = @"SELECT * FROM invoice i
                                    LEFT JOIN customer c ON i.customer_id = c.customer_id
                                    WHERE i.delete_status=@delete_status AND
                                          i.store_id=@store_id AND i.invoice_date >= CURDATE()
                                    ORDER BY invoice_number DESC LIMIT @zero,@jtPageSize;";
            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
            cmd.Parameters.AddWithValue("@store_id", storeId);
            cmd.Parameters.AddWithValue("@delete_status", 0);
            cmd.Parameters.AddWithValue("@zero", 0);
            cmd.Parameters.AddWithValue("@jtPageSize", 10);
            try
            {
                if (cm.OpenConnection())
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        object listObj = new object();
                        listObj = new
                        {
                            invoiceNumber = int.Parse(dataReader["invoice_number"].ToString()),
                            customerName = dataReader["customer_name"].ToString(),
                        };
                        invoiceList.Add(listObj);
                    }
                    cm.CloseConnection();
                    return invoiceList;
                }
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string msg = ex.Message;
            }
            return invoiceList;
        }

        public List<object> ProductEmergencyList(int storeId)
        {
            List<object> listProduct = new List<object>();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE stock_product SET in_stock=@in_stock
                                        WHERE delete_status=@zero AND store_id=@store_id AND quantity<=@uQuantity AND quantity>@zero;
                                        SELECT * FROM stock_product s 
                                        LEFT JOIN product_model p ON s.product_model_id = p.product_model_id
                                        WHERE s.delete_status=@zero AND s.store_id=@store_id AND s.quantity<=@uQuantity AND s.quantity>@zero 
                                        LIMIT @zero,@jtPageSize;";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@uQuantity", 50);
                    cmd.Parameters.AddWithValue("@zero", 0);
                    cmd.Parameters.AddWithValue("@in_stock", 2);
                    cmd.Parameters.AddWithValue("@jtPageSize", 10);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        object listObj = new object();
                        listObj = new
                        {
                            productName = dataReader["product_name"].ToString()
                        };
                        listProduct.Add(listObj);
                    }
                    cm.CloseConnection();
                    return listProduct;
                }                
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string msg = ex.Message;
            }
            return listProduct;
        }

        public List<object> ProductEmptyList(int storeId)
        {
            List<object> listProduct = new List<object>();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE stock_product SET in_stock=0
                                        WHERE delete_status=@zero AND store_id=@store_id AND quantity<=@zero;
                                        SELECT * FROM stock_product s 
                                        LEFT JOIN product_model p ON s.product_model_id = p.product_model_id
                                        WHERE s.delete_status=@zero AND s.store_id=@store_id AND s.quantity<=@zero 
                                        LIMIT @zero,@jtPageSize;";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@zero", 0);
                    cmd.Parameters.AddWithValue("@jtPageSize", 10);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        object listObj = new object();
                        listObj = new
                        {
                            productName = dataReader["product_name"].ToString()
                        };
                        listProduct.Add(listObj);
                    }
                    cm.CloseConnection();
                    return listProduct;
                }
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string msg = ex.Message;
            }
            return listProduct;
        }

        public object GetSales(int storeId)
        {
            object listObj = new object();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    string daySales, weekSales, monthSales, yearSales;
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT SUM(net_total) FROM invoice WHERE invoice_date > DATE_SUB(NOW(), INTERVAL 1 DAY) AND delete_status=@delete_status AND store_id=@store_id";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    daySales = cmd.ExecuteScalar().ToString();
                    cmd.CommandText = @"SELECT SUM(net_total) FROM invoice WHERE invoice_date > DATE_SUB(NOW(), INTERVAL 1 WEEK) AND delete_status=@delete_status AND store_id=@store_id";
                    cmd.Connection = cm.connection;
                    weekSales = cmd.ExecuteScalar().ToString();
                    cmd.CommandText = @"SELECT SUM(net_total) FROM invoice WHERE invoice_date > DATE_SUB(NOW(), INTERVAL 1 MONTH) AND delete_status=@delete_status AND store_id=@store_id";
                    cmd.Connection = cm.connection;
                    monthSales = cmd.ExecuteScalar().ToString();
                    cmd.CommandText = @"SELECT SUM(net_total) FROM invoice WHERE invoice_date > DATE_SUB(NOW(), INTERVAL 1 YEAR) AND delete_status=@delete_status AND store_id=@store_id";
                    cmd.Connection = cm.connection;
                    yearSales = cmd.ExecuteScalar().ToString();
                    cm.CloseConnection();
                    listObj = new
                    {
                        day_sales = daySales,
                        week_sales = weekSales,
                        month_sales = monthSales,
                        year_sales = yearSales
                    };
                    return listObj;
                }
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string msg = ex.Message;
            }
            return listObj;
        }
    }
}