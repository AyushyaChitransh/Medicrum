using MedicalStoreModule.App_Code.Model;
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
        public bool InsertInvoice(Invoice invoice, List<BillingItems> billingItems)
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
                                                @delete_status);SELECT LAST_INSERT_ID();";
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

        /*public Invoice GetInvoice(int invoiceId)
        {
            Invoice invoiceObj = new Invoice();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT 
                                                invoice_number,
                                                invoice.store_id,
                                                invoice.customer_id,
                                                invoice.invoice_date,
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
                                                invoice.status,
                                                invoice.delete_status
                                        FROM invoice
                                        WHERE invoice_id=@invoice_id AND delete_status=@delete_status";
                    cmd.Parameters.AddWithValue("@invoice_id", invoiceId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
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
                    }
                    cm.CloseConnection();
                }
                return invoiceObj;
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                string message = ex.Message;
                return invoiceObj;
            }
        }*/

        /*public object GetProductOptions(int storeId)
        {
            List<object> productOption = new List<object>();
            try
            {
                if (cm.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = @"SELECT product_name, product_model_id FROM product_model 
                                        WHERE delete_status=@delete_status AND store_id=@store_id";
                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    cmd.Parameters.AddWithValue("@delete_status", 0);
                    cmd.Connection = cm.connection;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        productOption.Add(new { DisplayText = dataReader["product_name"].ToString(), Value = int.Parse(dataReader["product_model_id"].ToString()) });
                    }
                    cm.CloseConnection();
                }
                return new { Result = "OK", Options = productOption };
            }
            catch (Exception ex)
            {
                cm.CloseConnection();
                return new { Result = "ERROR", Message = ex.Message };
            }
        }*/

        /*public bool DeleteInvoiceAndBill(int invoiceId)
        {
            string qry = @"UPDATE invoice SET delete_status=@delete_status WHERE invoice_id=@invoice_id;
                           UPDATE billing_items SET delete_status=@delete_status WHERE invoice_id=@invoice_id";
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
        }*/

        /*public List<BillingItems> GetBillingItems(int invoiceId)
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
        }*/
    }
}