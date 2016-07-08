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
        public Invoice GetInvoice(int invoiceId)
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
                        invoiceObj.discountType= dataReader["discount_type"].ToString();
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
        }
        public bool InsertInvoice(Invoice record)
        {
            string qry = @"INSERT into invoice
                                               (invoice_id,
                                                invoice_number,
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
                                               (@invoice_id,
                                                @invoice_number,
                                                @store_id,
                                                @customer_id,
                                                @invoice_date,
                                                @nvoice_type,
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
                                                @delete_status)";
            MySqlCommand cmd = new MySqlCommand(qry, cm.connection);
            cmd.Parameters.AddWithValue("@invoice_id", record.invoiceId);
            cmd.Parameters.AddWithValue("@store_id", record.storeId);
            cmd.Parameters.AddWithValue("@customer_id", record.customerId);
            cmd.Parameters.AddWithValue("@invoice_date", record.invoiceDate);
            cmd.Parameters.AddWithValue("@payment_terms", record.paymentTerms);
            cmd.Parameters.AddWithValue("@payment_mode", record.paymentMode);
            cmd.Parameters.AddWithValue("@total_amount", record.totalAmount);
            cmd.Parameters.AddWithValue("@tax_amount", record.taxAmount);
            cmd.Parameters.AddWithValue("@discount_type", record.discountType);
            cmd.Parameters.AddWithValue("@discount_amount", record.discountAmount);
            cmd.Parameters.AddWithValue("@coupon_code", record.couponCode);
            cmd.Parameters.AddWithValue("@net_total", record.netTotal);
            cmd.Parameters.AddWithValue("@amount_paid", record.amountPaid);
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
    }
}