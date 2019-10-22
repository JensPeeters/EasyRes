using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyres_api.Services
{
    public class SendGridEmailSender
    {
        public async Task SendEmailAsync(string userEmail, string emailSubject, string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("EasyResAP@gmail.com", "Easy Res");
            var subject = emailSubject;
            var to = new EmailAddress(userEmail, "Test");
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
