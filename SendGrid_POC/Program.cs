using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Http;
using System.Web;

namespace SendGrid_POC
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            //var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("rmalewar@prokarma.com", "Rakesh Malewar");
            var subject = "Sending with SendGrid";
            
            var to = new EmailAddress("rmalewar@prokarma.com;pshivakoti@prokarma.com", "test User");
            var plainTextContent = "Sendgrid message, with API";
            var htmlContent = "<strong>Got this email address at sendgrid site, Trying to read email</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

           }
}
