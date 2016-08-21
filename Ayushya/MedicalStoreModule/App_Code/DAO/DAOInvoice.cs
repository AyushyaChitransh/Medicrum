using MedicalStoreModule.App_Code.Model;
using MedicalStoreModule.App_Code.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalStoreModule.App_Code.DAO
{
    public class DAOInvoice
    {
        ConnectionManager cm = new ConnectionManager();
        public object InsertInvoice(Invoice invoice, List<BillingItems> billingItems, string tax)
        {
            int invoiceId = new int();
            string qry = @"INSERT into invoice
                                               (invoice_number,
                                                store_id,
                                                customer_id,
                                                invoice_date,
                                                invoice_type,
                                                payment_terms,
                                                payment_mode,
                                                total_amount,
                                                tax_amount,
                                                discount_type,
                                                discount_amount,
                                                coupon_code,
                                                net_total,
                                                amount_paid,
                                                status,
                                                delete_status)
                                        VALUES
                                               (@invoice_number,
                                                @store_id,
                                                @customer_id,
                                                @invoice_date,
                                                @invoice_type,
                                                @payment_terms,
                                                @payment_mode,
                                                @total_amount,
                                                @tax_amount,
                                                @discount_type,
                                                @discount_amount,
                                                @coupon_code,
                                                @net_total,
                                                @amount_paid,
                                                @status,
                                                @delete_status);
                                        SELECT LAST_INSERT_ID();";
            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
            cmd.Parameters.AddWithValue("@invoice_number", invoice.invoiceNumber);
            cmd.Parameters.AddWithValue("@store_id", invoice.storeId);
            cmd.Parameters.AddWithValue("@customer_id", invoice.customerId);
            cmd.Parameters.AddWithValue("@invoice_date", invoice.invoiceDate);
            cmd.Parameters.AddWithValue("@invoice_type", invoice.invoiceType);
            cmd.Parameters.AddWithValue("@payment_terms", invoice.paymentTerms);
            cmd.Parameters.AddWithValue("@payment_mode", invoice.paymentMode);
            cmd.Parameters.AddWithValue("@total_amount", invoice.totalAmount);
            cmd.Parameters.AddWithValue("@tax_amount", invoice.taxAmount);
            cmd.Parameters.AddWithValue("@discount_type", invoice.discountType);
            cmd.Parameters.AddWithValue("@discount_amount", invoice.discountAmount);
            cmd.Parameters.AddWithValue("@coupon_code", invoice.couponCode);
            cmd.Parameters.AddWithValue("@net_total", invoice.netTotal);
            cmd.Parameters.AddWithValue("@amount_paid", invoice.amountPaid);
            cmd.Parameters.AddWithValue("@status", invoice.status);
            cmd.Parameters.AddWithValue("@delete_status", invoice.deleteStatus);
            try
            {
                if (cm.OpenConnection())
                {
                    invoiceId = int.Parse(cmd.ExecuteScalar().ToString());
                    cm.CloseConnection();
                    foreach (BillingItems item in billingItems)
                    {
                        item.invoiceId = invoiceId;
                        item.status = 1;
                        item.deleteStatus = 0;
                        InsertBill(item);
                    }
                    InsertTax(tax, (decimal)invoice.taxAmount, invoiceId);
                }
                return invoiceId;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return invoiceId;
            }
        }

        private bool InsertBill(BillingItems record)
        {
            string qry = @"INSERT into billing_items
                                       (invoice_id,
                                        product_id,
                                        quantity,
                                        unit_price,
                                        price,
                                        status,
                                        delete_status)
                                  VALUES
                                       (@invoice_id,
                                        @product_id,
                                        @quantity,
                                        @unit_price,
                                        @price,
                                        @status,
                                        @delete_status);
                            UPDATE stock_product
                            SET quantity = quantity - " + record.quantity + " WHERE product_id=@product_id;";
            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
            cmd.Parameters.AddWithValue("@invoice_id", record.invoiceId);
            cmd.Parameters.AddWithValue("@product_id", record.productId);
            cmd.Parameters.AddWithValue("@quantity", record.quantity);
            cmd.Parameters.AddWithValue("@unit_price", record.unitPrice);
            cmd.Parameters.AddWithValue("@price", record.price);
            cmd.Parameters.AddWithValue("@status", 1);
            cmd.Parameters.AddWithValue("@delete_status", 0);
            try
            {
                if (cm.OpenConnection())
                {
                    cmd.ExecuteNonQuery();
                    cm.CloseConnection();
                    return true;
                }
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string msg = ex.Message;
                return false;
            }
            return true;
        }

        private bool InsertTax(string tax, decimal taxAmount, int invoiceId)
        {
            string qry = @"INSERT into invoice_tax
                                       (invoice_id,
                                        tax_type,
                                        tax_amount,
                                        status,
                                        delete_status)
                                  VALUES
                                       (@invoice_id,
                                        @tax_type,
                                        @tax_amount,
                                        @status,
                                        @delete_status);";
            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
            cmd.Parameters.AddWithValue("@invoice_id", invoiceId);
            cmd.Parameters.AddWithValue("@tax_type", tax);
            cmd.Parameters.AddWithValue("@tax_amount", taxAmount);
            cmd.Parameters.AddWithValue("@status", 1);
            cmd.Parameters.AddWithValue("@delete_status", 0);
            try
            {
                if (cm.OpenConnection())
                {
                    cmd.ExecuteNonQuery();
                    cm.CloseConnection();
                    return true;
                }
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string msg = ex.Message;
                return false;
            }
            return true;
        }

        public object GetInvoiceNumber(int storeId)
        {
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "SELECT MAX(invoice_number) FROM invoice WHERE store_id=@store_id";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Connection = cm.connection;
                    int invoiceNumber = int.Parse(cmd.ExecuteScalar().ToString());
                    cm.CloseConnection();
                    return invoiceNumber + 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return 0;
            }
        }

        public object GetProductOptions(int storeId)
        {
            List<object> productOptions = new List<object>();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT s.product_id, s.batch_number, p.product_name FROM stock_product s
                                        LEFT JOIN product_model p ON s.product_model_id = p.product_model_id
                                        WHERE s.delete_status=@delete_status AND s.store_id=@store_id AND s.quantity > 0 AND s.expiry_date >= CURDATE()";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        productOptions.Add(new { DisplayText = dataReader["product_name"].ToString() + " | " + dataReader["batch_number"].ToString(), Value = int.Parse(dataReader["product_id"].ToString()) });
                    }
                    cm.CloseConnection();
                }
                return productOptions;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return productOptions;
            }
        }

        public object GetCustomerOptions(int storeId)
        {
            List<object> customerOptions = new List<object>();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT * FROM customer 
                                        WHERE delete_status=@delete_status AND store_id=@store_id";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        customerOptions.Add(new { DisplayText = dataReader["customer_name"].ToString() + " | " + dataReader["phone_number"].ToString(), Value = int.Parse(dataReader["customer_id"].ToString()) });
                    }
                    cm.CloseConnection();
                }
                return customerOptions;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return customerOptions;
            }
        }

        public object GetProductPrice(int productId)
        {
            decimal unitPrice = new decimal();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT price FROM stock_product 
                                        WHERE product_id=@product_id";
                    cmd.Parameters.AddWithValue("@product_id", productId);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        unitPrice = decimal.Parse(dataReader["price"].ToString());
                    }
                    cm.CloseConnection();
                }
                return unitPrice;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return unitPrice;
            }
        }

        public List<object> GetInvoiceList(string customerName, int storeId)
        {
            List<object> invoiceList = new List<object>();
            string qry = @"SELECT * FROM invoice i
                                    LEFT JOIN customer c ON i.customer_id = c.customer_id
                                    WHERE i.delete_status=@delete_status AND
                                          i.store_id=@store_id AND
                                          c.customer_name LIKE @searchText
                                    ORDER BY invoice_number DESC";
            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
            cmd.Parameters.AddWithValue("@searchText", customerName + '%');
            cmd.Parameters.AddWithValue("@store_id", storeId);
            cmd.Parameters.AddWithValue("@delete_status", 0);
            try
            {
                if (cm.OpenConnection())
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Invoice invoiceObj = new Invoice();
                        object listObj = new object();
                        invoiceObj.invoiceId = int.Parse(dataReader["invoice_id"].ToString());
                        invoiceObj.invoiceNumber = int.Parse(dataReader["invoice_number"].ToString());
                        invoiceObj.customerId = int.Parse(dataReader["customer_id"].ToString());
                        invoiceObj.storeId = int.Parse(dataReader["store_id"].ToString());
                        invoiceObj.invoiceDate = DateTime.Parse(dataReader["invoice_date"].ToString());
                        invoiceObj.invoiceType = dataReader["invoice_type"].ToString();
                        invoiceObj.paymentTerms = dataReader["payment_terms"].ToString();
                        invoiceObj.paymentMode = dataReader["payment_mode"].ToString();
                        decimal totalAmountTemp = new decimal();
                        if (decimal.TryParse(dataReader["total_amount"].ToString(), out totalAmountTemp))
                        {
                            invoiceObj.totalAmount = totalAmountTemp;
                        }
                        decimal taxAmountTemp = new decimal();
                        if (decimal.TryParse(dataReader["tax_amount"].ToString(), out taxAmountTemp))
                        {
                            invoiceObj.taxAmount = taxAmountTemp;
                        }
                        invoiceObj.discountType = dataReader["discount_type"].ToString();
                        decimal discountAmountTemp = new decimal();
                        if (decimal.TryParse(dataReader["discount_amount"].ToString(), out discountAmountTemp))
                        {
                            invoiceObj.discountAmount = discountAmountTemp;
                        }
                        invoiceObj.couponCode = dataReader["coupon_code"].ToString();
                        decimal netTotalTemp = new decimal();
                        if (decimal.TryParse(dataReader["net_total"].ToString(), out netTotalTemp))
                        {
                            invoiceObj.netTotal = netTotalTemp;
                        }
                        decimal amountPaidTemp = new decimal();
                        if (decimal.TryParse(dataReader["amount_paid"].ToString(), out amountPaidTemp))
                        {
                            invoiceObj.amountPaid = amountPaidTemp;
                        }
                        invoiceObj.status = int.Parse(dataReader["status"].ToString());
                        listObj = new
                        {
                            invoiceId = invoiceObj.invoiceId,
                            invoiceNumber = invoiceObj.invoiceNumber,
                            storeId = invoiceObj.storeId,
                            customerId = invoiceObj.customerId,
                            customerName = dataReader["customer_name"].ToString(),
                            invoiceDate = invoiceObj.invoiceDate,
                            invoiceType = invoiceObj.invoiceType,
                            paymentTerms = invoiceObj.paymentTerms,
                            paymentMode = invoiceObj.paymentMode,
                            totalAmount = invoiceObj.totalAmount,
                            discountType = invoiceObj.discountType,
                            discountAmount = invoiceObj.discountAmount,
                            couponCode = invoiceObj.couponCode,
                            netTotal = invoiceObj.netTotal,
                            amountPaid = invoiceObj.amountPaid,
                            status = invoiceObj.status,
                            deleteStatus = invoiceObj.deleteStatus
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

        public InvoiceJson GetInvoiceJson(int invoiceId)
        {
            InvoiceJson invoiceJson = new InvoiceJson();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT 
                                                invoice_number,
                                                invoice_type,
                                                invoice.invoice_date as invoice_date,
                                                customer.customer_name as invoice_customer,
                                                customer.address as invoice_address,
                                                customer.district as invoice_district,
                                                customer.state as invoice_state,
                                                customer.country as invoice_country,
                                                customer.pincode as invoice_pincode,
                                                customer.email as invoice_email,
                                                customer.mobile as invoice_mobile,
                                                store.store_name as invoice_store_name,
                                                store.address as invoice_store_address,
                                                store.district as invoice_store_district,
                                                store.state as invoice_store_state,
                                                store.country as invoice_store_country,
                                                store.pincode as invoice_store_pincode,
                                                store.email as invoice_store_email,
                                                store.mobile as invoice_store_mobile,
                                                total_amount as invoice_total_value,
                                                discount_amount as invoice_discount_amount,
                                                net_total as invoice_payable_amount,
                                                tax_amount as invoice_vat_value,
                                                discount_type,
                                                coupon_code,
                                                amount_paid,
                                                payment_terms as invoice_payment_terms,
                                                payment_mode as invoice_payment_mode
                                        FROM invoice 
                                             LEFT JOIN customer on invoice.customer_id = customer.customer_id 
                                             LEFT JOIN store on store.store_id = invoice.store_id
                                        WHERE invoice_id=@invoice_id AND invoice.delete_status=@delete_status";
                    cmd.Parameters.AddWithValue("@invoice_id", invoiceId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        invoiceJson.invoice_id = invoiceId;
                        invoiceJson.invoice_number = int.Parse(dataReader["invoice_number"].ToString());
                        invoiceJson.invoice_type = dataReader["invoice_type"].ToString();
                        invoiceJson.invoice_date = DateTime.Parse(dataReader["invoice_date"].ToString());
                        invoiceJson.invoice_customer = dataReader["invoice_customer"].ToString();
                        invoiceJson.invoice_address = dataReader["invoice_address"].ToString();
                        invoiceJson.invoice_district = dataReader["invoice_district"].ToString();
                        invoiceJson.invoice_state = dataReader["invoice_state"].ToString();
                        invoiceJson.invoice_country = dataReader["invoice_country"].ToString();
                        invoiceJson.invoice_pincode = dataReader["invoice_pincode"].ToString();
                        invoiceJson.invoice_email = dataReader["invoice_email"].ToString();
                        invoiceJson.invoice_mobile = dataReader["invoice_mobile"].ToString();
                        invoiceJson.invoice_store_name = dataReader["invoice_store_name"].ToString();
                        invoiceJson.invoice_store_address = dataReader["invoice_store_address"].ToString();
                        invoiceJson.invoice_store_district = dataReader["invoice_store_district"].ToString();
                        invoiceJson.invoice_store_state = dataReader["invoice_store_state"].ToString();
                        invoiceJson.invoice_store_country = dataReader["invoice_store_country"].ToString();
                        invoiceJson.invoice_store_pincode = dataReader["invoice_store_pincode"].ToString();
                        invoiceJson.invoice_store_email = dataReader["invoice_store_email"].ToString();
                        invoiceJson.invoice_store_mobile = dataReader["invoice_store_mobile"].ToString();
                        invoiceJson.invoice_payment_mode = dataReader["invoice_payment_mode"].ToString();
                        invoiceJson.invoice_payment_terms = dataReader["invoice_payment_terms"].ToString();
                        decimal totalValueTemp = new decimal();
                        if (decimal.TryParse(dataReader["invoice_total_value"].ToString(), out totalValueTemp))
                        {
                            invoiceJson.invoice_total_value = totalValueTemp;
                        }

                        decimal vatValueTemp = new decimal();
                        if (decimal.TryParse(dataReader["invoice_vat_value"].ToString(), out vatValueTemp))
                        {
                            invoiceJson.invoice_vat_value = vatValueTemp;
                        }
                        decimal discountAmountTemp = new decimal();
                        if (decimal.TryParse(dataReader["invoice_discount_amount"].ToString(), out discountAmountTemp))
                        {
                            invoiceJson.invoice_discount_amount = discountAmountTemp;
                        }
                        decimal netAmountTemp = new decimal();
                        if (decimal.TryParse(dataReader["invoice_payable_amount"].ToString(), out netAmountTemp))
                        {
                            invoiceJson.invoice_payable_amount = netAmountTemp;
                        }
                    }
                    cm.CloseConnection();
                    List<BillingItems> billingItems = GetBillingItems(invoiceId);
                    Invoice_Medicines[] invoiceMedicine = new Invoice_Medicines[billingItems.Count];
                    int i = 0;
                    foreach (BillingItems item in billingItems)
                    {
                        Invoice_Medicines med = new Invoice_Medicines(item);
                        invoiceMedicine[i++] = med;
                    }
                    invoiceJson.invoice_medicines = invoiceMedicine;
                }
                return invoiceJson;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return invoiceJson;
            }
        }

        public List<BillingItems> GetBillingItems(int invoiceId)
        {
            List<BillingItems> listBillingItems = new List<BillingItems>();
            string qry = @"SELECT * FROM billing_items WHERE invoice_id=@invoice_id AND delete_status=@delete_status";
            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
            cmd.Parameters.AddWithValue("@invoice_id", invoiceId);
            cmd.Parameters.AddWithValue("@delete_status", 0);
            try
            {
                if (cm.OpenConnection())
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        BillingItems item = new BillingItems();
                        item.invoiceId = invoiceId;
                        item.billId = int.Parse(dataReader["bill_id"].ToString());
                        item.productId = int.Parse(dataReader["product_id"].ToString());
                        item.quantity = int.Parse(dataReader["quantity"].ToString());
                        item.unitPrice = decimal.Parse(dataReader["unit_price"].ToString());
                        item.price = decimal.Parse(dataReader["price"].ToString());
                        item.status = int.Parse(dataReader["status"].ToString());
                        listBillingItems.Add(item);
                    }
                    cm.CloseConnection();
                    return listBillingItems;
                }
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string msg = ex.Message;
                return listBillingItems;
            }
            return listBillingItems;
        }

        public bool DeleteInvoice(int invoiceId)
        {
            string qry = @"UPDATE invoice SET delete_status=@delete_status WHERE invoice_id=@invoice_id;
                           UPDATE billing_items SET delete_status=@delete_status WHERE invoice_id=@invoice_id
                           Update invoice_tax SET delete_status=@delete_status WHERE invoice_id=@invoice_id";
            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
            cmd.Parameters.AddWithValue("@delete_status", 1);
            cmd.Parameters.AddWithValue("@invoice_id", invoiceId);
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
                string msg = ex.Message;
                return false;
            }
        }

    }
}