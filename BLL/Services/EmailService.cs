//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;

//namespace BLL.Services
//{
//    public class EmailService
//    {
//        public void SendLowStockAlert(string toEmail, string subject, string body)
//        {


//            Debug.WriteLine("---------------- EMAIL SIMULATION ----------------");
//            Debug.WriteLine($"TO: {toEmail}");
//            Debug.WriteLine($"SUBJECT: {subject}");
//            Debug.WriteLine($"BODY: {body}");
//            Debug.WriteLine("--------------------------------------------------");


//            Console.WriteLine($"[Email Sent] To: {toEmail} | Subject: {subject}");
//        }
//    }
//}

using Microsoft.Extensions.Configuration; // এটা লাগবে
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendLowStockAlert(string toEmail, string subject, string body)
        {
            try
            {
              
                var fromEmail = _config["EmailSettings:FromEmail"];
                var password = _config["EmailSettings:Password"];
                var host = _config["EmailSettings:Host"];
                var port = int.Parse(_config["EmailSettings:Port"]);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail, "Swapno Inventory"), 
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false, 
                };
                mailMessage.To.Add(toEmail);

               
                var smtpClient = new SmtpClient(host, port)
                {
                    EnableSsl = true, 
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromEmail, password)
                };

          
                smtpClient.Send(mailMessage);

                Console.WriteLine($"[Success] Real email sent to {toEmail}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] Failed to send email: {ex.Message}");
            }
        }
    }
}
