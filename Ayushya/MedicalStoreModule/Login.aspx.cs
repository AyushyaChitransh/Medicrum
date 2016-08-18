using MedicalStoreModule.App_Code.DAO;
using MedicalStoreModule.App_Code.Model;
using MedicalStoreModule.App_Code.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalStoreModule
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["LoginData"] != null)
            {
                string encryptedLoginData = Request.Cookies["LoginData"].Value;
                try
                {
                    string[] decryptedLoginData = StringCipher.Decrypt(encryptedLoginData).Split(',');
                    Session["storeId"] = decryptedLoginData[0];
                    Session["userName"] = decryptedLoginData[1];
                    Response.Redirect("~/Dashboard");
                }
                catch (Exception)
                {
                    Response.Cookies["LoginData"].Expires = DateTime.Now.AddDays(-1);
                    Response.Redirect("~/Login.aspx");
                }
            }
            else
            {
                if (Session["storeId"] != null && Session["userName"] != null)
                {
                    Response.Write(@"<script>window.location.href='Dashboard.aspx';</script>");
                }
            }
        }

        [WebMethod]
        public static bool LoginButtonClicked(string email, string password, bool rememberMe)
        {
            DAOLogin accessLogindb = new DAOLogin();
            User user = accessLogindb.VerifyUser(email, password);
            if (user.storeId != 0 && user.userName != null)
            {
                HttpContext.Current.Session["storeId"] = user.storeId;
                HttpContext.Current.Session["userName"] = user.userName;
                if (rememberMe)
                {
                    HttpCookie cookie = new HttpCookie("LoginData");
                    cookie.Value = StringCipher.Encrypt(user.storeId + "," + user.userName);
                    cookie.Expires = DateTime.Now.AddDays(30);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public static void Logout()
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies["LoginData"].Expires = DateTime.Now.AddDays(-1);
        }

        [WebMethod]
        public static bool SendResetCode(string email)
        {
            DAOUser accessUserDb = new DAOUser();
            if (!accessUserDb.CheckEmail(email))
            {
                string randomString = GenerateRandomString();
                accessUserDb.AddResetCode(email, randomString);

                MailAddress frm = new MailAddress("ayushyachitransh@gmail.com", "Medicrum Admin");
                MailAddress to = new MailAddress(email);
                MailMessage msg = new MailMessage();
                msg.From = frm;
                msg.To.Add(to);
                msg.Subject = "OTP to reset Password";
                msg.Body = "Follow the link to reset your password: http://localhost:13804/ResetPassword.aspx?q=" + randomString;
                return SendEmail(email, msg);
            }
            else
            {
                return false;
            }
        }

        public static string GenerateRandomString()
        {
            char[] charArr = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            string randomString = string.Empty;
            Random objRandom = new Random();
            for (int i = 0; i < 11; i++)
            {
                int x = objRandom.Next(1, charArr.Length);
                randomString += charArr.GetValue(x);
            }
            DAOUser accessUserDb = new DAOUser();
            bool result = accessUserDb.CheckForResetPasswordCodeUniqueness(randomString);
            if (result == false)
                GenerateRandomString();
            return randomString;
        }

        public static bool SendEmail(string email, MailMessage msg)
        {
            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                //change these to send email
                Credentials = new NetworkCredential("youremail@gmail.com", "password"),
                EnableSsl = true
            };
            //smtp.Send("ayushyachitransh@gmail.com", "ayushyachitransh@gmail.com", "test", "testbody");



            try
            {
                smtp.Send(msg);
                return true;
                //Response.Write("<script>alert('Email Sent Successfully')</script>");
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return false;
            }
        }
    }
}