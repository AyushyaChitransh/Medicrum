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
                int productId = new int();
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd1 = new MySqlCommand();
                    cmd1.CommandText = @"SELECT product_id from stock_product 
                                        WHERE product_model_id=@product_model_id 
                                            AND batch_number=@batch_number 
                                            AND delete_status=@delete_status 
                                            AND store_id=@store_id";
                    cmd1.Parameters.AddWithValue("@product_model_id", stockProduct.productModelId);
                    cmd1.Parameters.AddWithValue("@store_id", stockProduct.storeId);
                    cmd1.Parameters.AddWithValue("@batch_number", stockProduct.batchNumber);
                    cmd1.Parameters.AddWithValue("@delete_status", 0);
                    cmd1.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd1.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int.TryParse(dataReader["product_id"].ToString(), out productId);
                        int t = productId;
                    }
                    dataReader.Close();
                    if (productId == 0)
                    {
                        MySqlCommand cmd2 = new MySqlCommand();
                        string parameters = "product_model_id, store_id, supplier_id, batch_number, manufacture_date, expiry_date, package_quantity, price, quantity, in_stock, delete_status";
                        string values = "@product_model_id, @store_id, @supplier_id, @batch_number, @manufacture_date, @expiry_date, @package_quantity, @price, @quantity, @in_stock, @delete_status";
                        cm.AddIfNotNull(stockProduct.barcode.ToString(), "barcode", ref parameters, ref values);
                        cm.AddIfNotNull(stockProduct.manufactureLicenceNumber, "manufacture_licence_number", ref parameters, ref values);
                        cm.AddIfNotNull(stockProduct.weight.ToString(), "weight", ref parameters, ref values);
                        cm.AddIfNotNull(stockProduct.volume.ToString(), "volume", ref parameters, ref values);
                        cm.AddIfNotNull(stockProduct.tax.ToString(), "tax", ref parameters, ref values);
                        cm.AddIfNotNull(stockProduct.status.ToString(), "status", ref parameters, ref values);
                        cm.AddIfNotNull(stockProduct.shelf, "shelf", ref parameters, ref values);
                        cmd2.CommandText = "INSERT INTO stock_product (" + parameters + ") VALUES (" + values + ")";
                        cmd2.Parameters.AddWithValue("@product_model_id", stockProduct.productModelId);
                        cmd2.Parameters.AddWithValue("@store_id", stockProduct.storeId);
                        cmd2.Parameters.AddWithValue("@supplier_id", stockProduct.supplierId);
                        cmd2.Parameters.AddWithValue("@batch_number", stockProduct.batchNumber);
                        cmd2.Parameters.AddWithValue("@manufacture_date", stockProduct.manufactureDate);
                        cmd2.Parameters.AddWithValue("@expiry_date", stockProduct.expiryDate);
                        cmd2.Parameters.AddWithValue("@package_quantity", stockProduct.packageQuantity);
                        cmd2.Parameters.AddWithValue("@price", stockProduct.price);
                        cmd2.Parameters.AddWithValue("@quantity", stockProduct.quantity);
                        cmd2.Parameters.AddWithValue("@in_stock", stockProduct.inStock);
                        cmd2.Parameters.AddWithValue("@delete_status", stockProduct.deleteStatus);
                        if (stockProduct.barcode != null)
                        {
                            cmd2.Parameters.AddWithValue("@barcode", stockProduct.barcode);
                        }
                        if (stockProduct.manufactureLicenceNumber != null)
                        {
                            cmd2.Parameters.AddWithValue("@manufacture_licence_number", stockProduct.manufactureLicenceNumber);
                        }
                        if (stockProduct.weight != null)
                        {
                            cmd2.Parameters.AddWithValue("@weight", stockProduct.weight);
                        }
                        if (stockProduct.volume != null)
                        {
                            cmd2.Parameters.AddWithValue("@volume", stockProduct.volume);
                        }
                        if (stockProduct.tax != null)
                        {
                            cmd2.Parameters.AddWithValue("@tax", stockProduct.tax);
                        }
                        if (stockProduct.status != null)
                        {
                            cmd2.Parameters.AddWithValue("@status", stockProduct.status);
                        }
                        if (stockProduct.shelf != null)
                        {
                            cmd2.Parameters.AddWithValue("@shelf", stockProduct.shelf);
                        }
                        cmd2.Connection = cm.connection;
                        cmd2.ExecuteNonQuery();
                        cm.CloseConnection();
                        return true;
                    }
                    else
                    {
                        MySqlCommand cmd2 = new MySqlCommand();
                        cmd2.CommandText = @"UPDATE stock_product
                                                SET quantity = quantity + " + stockProduct.quantity + " WHERE product_id=@product_id;";
                        cmd2.Parameters.AddWithValue("@product_id", productId);
                        cmd2.ExecuteNonQuery();
                        cm.CloseConnection();
                        return true;
                    }
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
                if (sortOrder[0].Equals("productModelId"))
                    sortOrder[0] = "p.product_name";
                else if (sortOrder[0].Equals("supplierId"))
                    sortOrder[0] = "su.supplier_store_name";
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE stock_product SET in_stock=@emergency_in_stock
                                        WHERE delete_status=@delete_status AND store_id=@store_id AND quantity<=@uQuantity AND quantity>@lQuantity;
                                        UPDATE stock_product SET in_stock=@empty_in_stock
                                        WHERE delete_status=@delete_status AND store_id=@store_id AND quantity<=@quantity;
                                        SELECT * FROM stock_product s 
                                        LEFT JOIN product_model p ON s.product_model_id = p.product_model_id
                                        LEFT JOIN supplier su ON s.supplier_id = su.supplier_id
                                        WHERE s.delete_status=@delete_status AND s.store_id=@store_id 
                                              AND ( p.product_name LIKE @searchText OR p.company LIKE @searchText OR s.shelf LIKE @searchText OR s.batch_number LIKE @searchText )
                                        ORDER BY " + sortOrder[0] + " " + sortOrder[1] + " LIMIT @jtStartIndex,@jtPageSize";
                    cmd.Parameters.AddWithValue("@searchText", productModelId + '%');
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@uQuantity", 50);
                    cmd.Parameters.AddWithValue("@lQuantity", 0);
                    cmd.Parameters.AddWithValue("@emergency_in_stock", 2);
                    cmd.Parameters.AddWithValue("@quantity", 0);
                    cmd.Parameters.AddWithValue("@empty_in_stock", 0);
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
                        product.shelf = dataReader["shelf"].ToString();
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
                                        WHERE s.delete_status=@delete_status AND s.store_id=@store_id AND p.product_name like @searchText";
                    cmd.Parameters.AddWithValue("@searchText", productModelId + "%");
                    cmd.Parameters.AddWithValue("@store_id", storeId);
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
                                        weight=@weight, volume=@volume, quantity=@quantity, tax=@tax, shelf=@shelf
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
                    cmd.Parameters.AddWithValue("@shelf", stockProduct.shelf);
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
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE stock_product SET status=@status, delete_status=@delete_status
                                                            WHERE product_id=@product_id";
                    cmd.Parameters.AddWithValue("@product_id", productId);
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

        public object GetProduct(int productId)
        {
            object product = new object();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT * FROM stock_product s 
                                        LEFT JOIN product_model p ON s.product_model_id = p.product_model_id
                                        LEFT JOIN supplier su on s.supplier_id = su.supplier_id
                                        WHERE s.product_id=@product_id";
                    cmd.Parameters.AddWithValue("@product_id", productId);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int barcodeVar = new int();
                        int.TryParse(dataReader["barcode"].ToString(), out barcodeVar);

                        DateTime manufactureDateVar = new DateTime();
                        DateTime.TryParse(dataReader["manufacture_date"].ToString(), out manufactureDateVar);

                        DateTime expiryDateVar = new DateTime();
                        DateTime.TryParse(dataReader["expiry_date"].ToString(), out expiryDateVar);

                        int packageQuantityVar = new int();
                        int.TryParse(dataReader["package_quantity"].ToString(), out packageQuantityVar);

                        decimal priceVar = new decimal();
                        decimal.TryParse(dataReader["price"].ToString(), out priceVar);

                        decimal weightVar = new decimal();
                        decimal.TryParse(dataReader["weight"].ToString(), out weightVar);

                        decimal volumeVar = new decimal();
                        decimal.TryParse(dataReader["volume"].ToString(), out volumeVar);

                        int quantityVar = new int();
                        int.TryParse(dataReader["quantity"].ToString(), out quantityVar);

                        decimal taxVar = new decimal();
                        decimal.TryParse(dataReader["tax"].ToString(), out taxVar);

                        int inStockVar = new int();
                        int.TryParse(dataReader["in_stock"].ToString(), out inStockVar);

                        product = new { productName = dataReader["product_name"].ToString(), supplierStoreName = dataReader["supplier_store_name"].ToString(), batchNumber = dataReader["batch_number"].ToString(), barcode = barcodeVar, manufactureDate = manufactureDateVar, expiryDate = expiryDateVar, packageQuantity = packageQuantityVar, price = priceVar, manufactureLicenceNumber = dataReader["manufacture_licence_number"].ToString(), weight = weightVar, volume = volumeVar, quantity = quantityVar, tax = taxVar, inStock = inStockVar, shelf = dataReader["shelf"].ToString() };
                    }
                    cm.CloseConnection();
                }
                return product;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return product;
            }
        }

        public object GetProductModelOptions(int storeId)
        {
            List<object> productModelOptions = new List<object>();
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
                    while (dataReader.Read())
                    {
                        productModelOptions.Add(new { DisplayText = dataReader["product_name"].ToString(), Value = int.Parse(dataReader["product_model_id"].ToString()) });
                    }
                    cm.CloseConnection();
                }
                return new { Result = "OK", Options = productModelOptions };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        public object GetSupplierOptions(int storeId)
        {
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

        public object GetSupplierComboOptions(int storeId)
        {
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
                        supplierOptions.Add(new { DisplayText = dataReader["supplier_store_name"].ToString() + " | " + dataReader["contact_person_name"].ToString(), Value = int.Parse(dataReader["supplier_id"].ToString()) });
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

        public object ProductEmergencyList(string productModelId, int storeId, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                int productCount = 0;
                List<StockProduct> listProduct = new List<StockProduct>();
                string[] sortOrder = jtSorting.Split(' ');
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE stock_product SET in_stock=@in_stock
                                        WHERE delete_status=@delete_status AND store_id=@store_id AND quantity<=@uQuantity AND quantity>@lQuantity;
                                        SELECT * FROM stock_product s 
                                        LEFT JOIN product_model p ON s.product_model_id = p.product_model_id
                                        WHERE s.delete_status=@delete_status AND s.store_id=@store_id AND s.quantity<=@uQuantity AND s.quantity>@lQuantity 
                                              AND ( p.product_name LIKE @searchText OR p.company LIKE @searchText OR s.shelf LIKE @searchText OR s.batch_number LIKE @searchText ) 
                                        ORDER BY p.product_name " + sortOrder[1] + " LIMIT @jtStartIndex,@jtPageSize";
                    cmd.Parameters.AddWithValue("@searchText", productModelId + '%');
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@uQuantity", 50);
                    cmd.Parameters.AddWithValue("@lQuantity", 0);
                    cmd.Parameters.AddWithValue("@in_stock", 2);
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
                                        WHERE s.delete_status=@delete_status AND s.store_id=@store_id AND s.quantity<@quantity  AND p.product_name like @searchText";
                    cmd.Parameters.AddWithValue("@searchText", productModelId + "%");
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@quantity", 50);
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

        public object ProductEmptyList(string productModelId, int storeId, int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                int productCount = 0;
                List<StockProduct> listProduct = new List<StockProduct>();
                string[] sortOrder = jtSorting.Split(' ');
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"UPDATE stock_product SET in_stock=@in_stock
                                        WHERE delete_status=@delete_status AND store_id=@store_id AND quantity<=@quantity;
                                        SELECT * FROM stock_product s 
                                        LEFT JOIN product_model p ON s.product_model_id = p.product_model_id
                                        WHERE s.delete_status=@delete_status AND s.store_id=@store_id AND s.quantity<=@quantity 
                                              AND ( p.product_name LIKE @searchText OR p.company LIKE @searchText OR s.shelf LIKE @searchText OR s.batch_number LIKE @searchText ) 
                                        ORDER BY p.product_name " + sortOrder[1] + " LIMIT @jtStartIndex,@jtPageSize;";
                    cmd.Parameters.AddWithValue("@searchText", productModelId + '%');
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@quantity", 0);
                    cmd.Parameters.AddWithValue("@in_stock", 0);
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
                                        WHERE s.delete_status=@delete_status AND s.store_id=@store_id AND s.quantity<=@quantity AND p.product_name like @searchText";
                    cmd.Parameters.AddWithValue("@searchText", productModelId + "%");
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@quantity", 0);
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
    }
}