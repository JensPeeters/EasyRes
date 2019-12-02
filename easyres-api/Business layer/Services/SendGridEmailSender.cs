using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Business_layer.Services
{
    public class SendGridEmailSender
    {
        public async Task SendEmailAsync(string userEmail, string emailSubject, string message, int? factuurId = null, MemoryStream stream = null)
        {
            //De render wordt normaal niet meegestuurd
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
                msg.AddAttachment(AddAttachment(factuurId, stream));
            }

            var response = await client.SendEmailAsync(msg);

        }
        public Attachment AddAttachment(int? factuurId, MemoryStream stream = null)
        {
            if (factuurId == null)
                return null;
            string fileName = "Factuur" + factuurId + ".pdf";
            /// Standaard moet je de lijn in commentaar doen en die eronder niet, ook moet er standaard het document niet worden meegestuurd
            //byte[] pdfBytes = File.ReadAllBytes("./Bestellingen/" + fileName);
            //byte[] pdfBytes = File.ReadAllBytes("factuur" + factuurId + ".pdf");
            //string pdfBase64 = Convert.ToBase64String(pdfBytes);
            byte[] buffer = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Flush();
            stream.Read(buffer, 0, (int)stream.Length);
            string pdfBase64 = Convert.ToBase64String(buffer);
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
