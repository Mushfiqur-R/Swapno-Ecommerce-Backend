using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BLL.Services
{
    public class EmailService
    {
        public void SendLowStockAlert(string toEmail, string subject, string body)
        {


            Debug.WriteLine("---------------- EMAIL SIMULATION ----------------");
            Debug.WriteLine($"TO: {toEmail}");
            Debug.WriteLine($"SUBJECT: {subject}");
            Debug.WriteLine($"BODY: {body}");
            Debug.WriteLine("--------------------------------------------------");

            // আপনি চাইলে Console.WriteLine ও ব্যবহার করতে পারেন
            Console.WriteLine($"[Email Sent] To: {toEmail} | Subject: {subject}");
        }
    }
}

