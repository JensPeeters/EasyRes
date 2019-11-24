using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Threading.Tasks;

namespace easyres_api.Services
{
    public class SendGridEmailSender
    {
        public async Task SendEmailAsync(string userEmail, string emailSubject, string message, int? factuurId = null)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("reservaties@EasyRes.be", "EasyRes"),
                Subject = emailSubject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(userEmail, ""));
            msg.SetFooterSetting(true,
                "<p style='color: grey;'>Mogelijk gemaakt door EasyRes™</p>",
                "Mogelijk gemaakt door EasyRes™");

            if (factuurId != null)
            {
                msg.AddAttachment(AddAttachment(factuurId));
            }
            
            var response = await client.SendEmailAsync(msg);
        }
        public Attachment AddAttachment(int? factuurId)
        {
            if (factuurId == null)
                return null;
            string fileName = "Factuur" + factuurId + ".pdf";
            byte[] pdfBytes = File.ReadAllBytes("./Bestellingen/" + fileName);
            string pdfBase64 = Convert.ToBase64String(pdfBytes);
            var bestelling = new Attachment()
            {
                Content = pdfBase64,
                Type = "application/pdf",
                Filename = fileName,
                Disposition = "inline",
                ContentId = "Factuur"
            };
            return bestelling;
        }
    }
}
