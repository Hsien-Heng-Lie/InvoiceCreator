using ceTe.DynamicPDF;
using InvoiceCreator.Helpers;
using System.IO;
using System.Net;
using System.Net.Mail;


namespace InvoiceCreatorFrontend.helpers
{
    public class EmailHelper
    {
        public static void SendEmail(string email, string name, int transId)
        {

            var smtpClient = new SmtpClient("levelup-invoice.stuffs.co.za", 587)
            {
                Credentials = new NetworkCredential("no-reply@levelup-invoice.stuffs.co.za", "BBDInvoice123!"),
                EnableSsl = true,
            };

            var message = new MailMessage();
            message.From = new MailAddress("no-reply@levelup-invoice.stuffs.co.za");
            message.To.Add(new MailAddress(email, name));
            message.Subject = "PAY ME";
            message.Body = "PAY ME SOME MORE";

            Document document = PDFHelper.GeneratePDF(transId);
            var memorystream = new System.IO.MemoryStream();
            document.Draw(memorystream);
            memorystream.Seek(0, SeekOrigin.Begin);


            var attachment = new Attachment(memorystream,name+"-invoice.pdf");
            message.Attachments.Add(attachment);

            smtpClient.Send(message);
        }

    }
}
