using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace CarShop
{
    public class Utility
    {
        public static void SendEmail(string toAddress, string subject, string body)
        {
            var fromAddress = new MailAddress("carsaletest123@gmail.com", "Tom Tran");
            var toEmailAddress = new MailAddress(toAddress, "Carsale");
            const string fromPassword = "carsale123456";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toEmailAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}