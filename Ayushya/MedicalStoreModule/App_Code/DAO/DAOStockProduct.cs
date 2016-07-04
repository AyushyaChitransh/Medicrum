using MedicalStoreModule.App_Code.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.DAO
{
    public class DAOStockProduct
    {
        ConnectionManager cm = new ConnectionManager();
        public bool InsertProduct(StockProduct stockProduct)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    string parameters = "product_model_id, store_id, supplier_id, batch_number, manufacture_date, expiry_date, package_quantity, price, quantity, in_stock, delete_status";
                    string values = "@product_model_id, @store_id, @supplier_id, @batch_number, @manufacture_date, @expiry_date, @package_quantity, @price, @quantity, @in_stock, @delete_status";
                    cm.AddIfNotNull(stockProduct.barcode.ToString(), "barcode", ref parameters, ref values);
                    cm.AddIfNotNull(stockProduct.manufactureLicenceNumber, "manufacture_licence_number", ref parameters, ref values);
                    cm.AddIfNotNull(stockProduct.weight.ToString(), "weight", ref parameters, ref values);
                    cm.AddIfNotNull(stockProduct.volume.ToString(), "volume", ref parameters, ref values);
                    cm.AddIfNotNull(stockProduct.tax.ToString(), "tax", ref parameters, ref values);
                    cm.AddIfNotNull(stockProduct.status.ToString(), "status", ref parameters, ref values);
                    cmd.CommandText = "INSERT INTO stock_product (" + parameters + ") VALUES (" + values + ")";
                    cmd.Parameters.AddWithValue("@product_model_id", stockProduct.productModelId);
                    cmd.Parameters.AddWithValue("@store_id", stockProduct.storeId);
                    cmd.Parameters.AddWithValue("@supplier_id", stockProduct.supplierId);
                    cmd.Parameters.AddWithValue("@batch_number", stockProduct.batchNumber);
                    cmd.Parameters.AddWithValue("@manufacture_date", stockProduct.manufactureDate);
                    cmd.Parameters.AddWithValue("@expiry_date", stockProduct.expiryDate);
                    cmd.Parameters.AddWithValue("@package_quantity", stockProduct.packageQuantity);
                    cmd.Parameters.AddWithValue("@price", stockProduct.price);
                    cmd.Parameters.AddWithValue("@quantity", stockProduct.quantity);
                    cmd.Parameters.AddWithValue("@in_stock", stockProduct.inStock);
                    cmd.Parameters.AddWithValue("@delete_status", stockProduct.deleteStatus);
                    if (stockProduct.barcode != null)
                    {
                        cmd.Parameters.AddWithValue("@barcode", stockProduct.barcode);
                    }
                    if (stockProduct.manufactureLicenceNumber != null)
                    {
                        cmd.Parameters.AddWithValue("@manufacture_licence_number", stockProduct.manufactureLicenceNumber);
                    }
                    if (stockProduct.weight != null)
                    {
                        cmd.Parameters.AddWithValue("@weight", stockProduct.weight);
                    }
                    if (stockProduct.volume != null)
                    {
                        cmd.Parameters.AddWithValue("@volume", stockProduct.volume);
                    }
                    if (stockProduct.tax != null)
                    {
                        cmd.Parameters.AddWithValue("@tax", stockProduct.tax);
                    }
                    if (stockProduct.status != null)
                    {
                        cmd.Parameters.AddWithValue("@status", stockProduct.status);
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

        public object ProductList(string productModelId, int storeId, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                int productCount = 0;
                List<StockProduct> listProduct = new List<StockProduct>();
                string[] sortOrder = jtSorting.Split(' ');
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT * FROM stock_product s 
                                        LEFT JOIN product_model p ON s.product_model_id = p.product_model_id
                                        WHERE s.delete_status=@delete_status AND s.store_id=@store_id AND p.product_name LIKE @searchText 
                                        ORDER BY p.product_name " + sortOrder[1] + " LIMIT @jtStartIndex,@jtPageSize";
                    cmd.Parameters.AddWithValue("@searchText", productModelId + '%');
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Parameters.AddWithValue("@jtStartIndex", jtStartIndex);
                    cmd.Parameters.AddWithValue("@jtPageSize", jtPageSize);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        StockProduct product = new StockProduct();
                        product.productId = int.Parse(dataReader["product_id"].ToString());
                        product.productModelId = int.Parse(dataReader["product_model_id"].ToString());
                        product.supplierId = int.Parse(dataReader["supplier_id"].ToString());
                        int barcode = new int();
                        if (int.TryParse(dataReader["barcode"].ToString(), out barcode))
                        {
                            product.barcode = barcode;
                        }
                        product.batchNumber = dataReader["batch_number"].ToString();
                        DateTime manufactureDate = new DateTime();
                        if (DateTime.TryParse(dataReader["manufacture_date"].ToString(), out manufactureDate))
                        {
                            product.manufactureDate = manufactureDate;
                        }
                        DateTime expiryDate = new DateTime();
                        if (DateTime.TryParse(dataReader["expiry_date"].ToString(), out expiryDate))
                        {
                            product.expiryDate = expiryDate;
                        }
                        int packageQuantity = new int();
                        if (int.TryParse(dataReader["package_quantity"].ToString(), out packageQuantity))
                        {
                            product.packageQuantity = packageQuantity;
                        }
                        decimal price = new decimal();
                        if (decimal.TryParse(dataReader["price"].ToString(), out price))
                        {
                            product.price = price;
                        }
                        product.manufactureLicenceNumber = dataReader["manufacture_licence_number"].ToString();
                        decimal weight = new decimal();
                        if (decimal.TryParse(dataReader["weight"].ToString(), out weight))
                        {
                            product.weight = weight;
                        }
                        decimal volume = new decimal();
                        if (decimal.TryParse(dataReader["volume"].ToString(), out volume))
                        {
                            product.volume = volume;
                        }
                        int quantity = new int();
                        if (int.TryParse(dataReader["quantity"].ToString(), out quantity))
                        {
                            product.quantity = quantity;
                        }
                        decimal tax = new decimal();
                        if (decimal.TryParse(dataReader["tax"].ToString(), out tax))
                        {
                            product.tax = tax;
                        }
                        int status = new int();
                        if (int.TryParse(dataReader["status"].ToString(), out status))
                        {
                            product.status = status;
                        }
                        int inStock = new int();
                        if (int.TryParse(dataReader["in_stock"].ToString(), out inStock))
                        {
                            product.inStock = inStock;
                        }
                        listProduct.Add(product);
                    }
                    cm.CloseConnection();
                }
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT COUNT(*) FROM stock_product s
                                        LEFT JOIN product_model p ON s.product_model_id = p.product_model_id
                                        WHERE s.delete_status=@delete_status AND p.product_name like @searchText";
                    cmd.Parameters.AddWithValue("@searchText", productModelId + "%");
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    productCount = int.Parse(cmd.ExecuteScalar().ToString());
                    cm.CloseConnection();
                }
                return new { Result = "OK", Records = listProduct, TotalRecordCount = productCount };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public object UpdateProduct(StockProduct stockProduct)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE stock_product SET product_model_id=@product_model_id, supplier_id=@supplier_id, barcode=@barcode, 
                                        batch_number=@batch_number, manufacture_date=@manufacture_date, expiry_date=@expiry_date, 
                                        package_quantity=@package_quantity, price=@price, manufacture_licence_number=@manufacture_licence_number, 
                                        weight=@weight, volume=@volume, quantity=@quantity, tax=@tax
                                        WHERE product_id=@product_id";
                    cmd.Parameters.AddWithValue("@product_id", stockProduct.productId);
                    cmd.Parameters.AddWithValue("@product_model_id", stockProduct.productModelId);
                    cmd.Parameters.AddWithValue("@supplier_id", stockProduct.supplierId);
                    cmd.Parameters.AddWithValue("@barcode", stockProduct.barcode);
                    cmd.Parameters.AddWithValue("@batch_number", stockProduct.batchNumber);
                    cmd.Parameters.AddWithValue("@manufacture_date", stockProduct.manufactureDate);
                    cmd.Parameters.AddWithValue("@expiry_date", stockProduct.expiryDate);
                    cmd.Parameters.AddWithValue("@package_quantity", stockProduct.packageQuantity);
                    cmd.Parameters.AddWithValue("@price", stockProduct.price);
                    cmd.Parameters.AddWithValue("@manufacture_licence_number", stockProduct.manufactureLicenceNumber);
                    cmd.Parameters.AddWithValue("@weight", stockProduct.weight);
                    cmd.Parameters.AddWithValue("@volume", stockProduct.volume);
                    cmd.Parameters.AddWithValue("@quantity", stockProduct.quantity);
                    cmd.Parameters.AddWithValue("@tax", stockProduct.tax);
                    cmd.Connection = cm.connection;
                    cmd.CommandTimeout = 0;
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

        public object DeleteProduct(int productId)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    //                    MySqlCommand cmd = new MySqlCommand();
                    //                    cmd.CommandText = @"UPDATE product_model SET status=@status, delete_status=@delete_status
                    //                                        WHERE product_model_id=@product_model_id";
                    //                    cmd.Parameters.AddWithValue("@product_model_id", productModelId);
                    //                    cmd.Parameters.AddWithValue("@status", 0);
                    //                    cmd.Parameters.AddWithValue("@delete_status", 1);
                    //                    cmd.Connection = connection;
                    //                    cmd.ExecuteNonQuery();
                    //                    this.CloseConnection();
                }
                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public object GetProduct(int productId)
        {
            StockProduct stockProduct = new StockProduct();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT * FROM stock_product s 
                                        LEFT JOIN product_model p ON s.product_model_id = p.product_model_id
                                        WHERE product_id=@product_id";
                    cmd.Parameters.AddWithValue("@product_id", productId);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {

                        stockProduct.productId = int.Parse(dataReader["product_id"].ToString());
                        stockProduct.productModelId = int.Parse(dataReader["product_model_id"].ToString());
                        stockProduct.storeId = int.Parse(dataReader["store_id"].ToString());
                        stockProduct.supplierId = int.Parse(dataReader["supplier_id"].ToString());
                        int barcode = new int();
                        if (int.TryParse(dataReader["barcode"].ToString(), out barcode))
                        {
                            stockProduct.barcode = barcode;
                        }
                        stockProduct.batchNumber = dataReader["batch_number"].ToString();
                        DateTime manufactureDate = new DateTime();
                        if (DateTime.TryParse(dataReader["manufacture_date"].ToString(), out manufactureDate))
                        {
                            stockProduct.manufactureDate = manufactureDate;
                        }
                        DateTime expiryDate = new DateTime();
                        if (DateTime.TryParse(dataReader["expiry_date"].ToString(), out expiryDate))
                        {
                            stockProduct.expiryDate = expiryDate;
                        }
                        int packageQuantity = new int();
                        if (int.TryParse(dataReader["package_quantity"].ToString(), out packageQuantity))
                        {
                            stockProduct.packageQuantity = packageQuantity;
                        }
                        decimal price = new decimal();
                        if (decimal.TryParse(dataReader["price"].ToString(), out price))
                        {
                            stockProduct.price = price;
                        }
                    }
                    cm.CloseConnection();
                }
                return stockProduct;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return stockProduct;
            }
        }

        public List<KeyValuePair<int, string>> GetProductModelForProduct(int storeId)
        {
            List<KeyValuePair<int, string>> kvpList = new List<KeyValuePair<int, string>>();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT *
                                    FROM  product_model 
                                    WHERE delete_status=@delete_status AND store_id=@store_id";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        kvpList.Add(new KeyValuePair<int, string>(int.Parse(dataReader["product_model_id"].ToString()), dataReader["product_name"].ToString()));
                    }
                    cm.CloseConnection();
                }
                return kvpList;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return kvpList;
            }
        }

        public List<KeyValuePair<int, string>> GetSupplierForProduct(int storeId)
        {
            List<KeyValuePair<int, string>> kvpList = new List<KeyValuePair<int, string>>();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT *
                                    FROM supplier 
                                    WHERE delete_status=@delete_status AND store_id=@store_id";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        kvpList.Add(new KeyValuePair<int, string>(int.Parse(dataReader["supplier_id"].ToString()), dataReader["supplier_store_name"].ToString()));
                    }
                    cm.CloseConnection();
                }
                return kvpList;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return kvpList;
            }
        }

        public object GetProductModelOptions(int storeId)
        {
            //var productModelOption = new[]{};
            List<object> productModelOption = new List<object>();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT * FROM product_model 
                                    WHERE delete_status=@delete_status AND store_id=@store_id";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    int i = 0;
                    while (dataReader.Read())
                    {
                        productModelOption.Add(new { DisplayText = dataReader["product_name"].ToString(), Value = int.Parse(dataReader["product_model_id"].ToString()) });
                    }
                    cm.CloseConnection();
                }
                return new { Result = "OK", Options = productModelOption };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public object GetSupplierOptions(int storeId)
        {
            //var supplierOptions = new object();
            List<object> supplierOptions = new List<object>();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT * FROM supplier 
                                        WHERE delete_status=@delete_status AND store_id=@store_id";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        supplierOptions.Add(new { DisplayText = dataReader["supplier_store_name"].ToString(), Value = int.Parse(dataReader["supplier_id"].ToString()) });
                    }
                    cm.CloseConnection();
                }
                return new { Result = "OK", Options = supplierOptions };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }
    }
}