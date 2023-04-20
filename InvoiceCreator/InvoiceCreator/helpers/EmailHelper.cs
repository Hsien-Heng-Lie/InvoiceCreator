using ceTe.DynamicPDF;
using InvoiceCreator.Helpers;
using System.IO;
using System.Net;
using System.Net.Mail;

public delegate Document GenPDF(int x);
namespace InvoiceCreatorFrontend.helpers
{
    public class EmailHelper
    {
        public event GenPDF generateDoc;
        public void SendEmail(string email, string name, int studentId)
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

            
            Document document = generateDoc.Invoke(studentId);
            var memorystream = new System.IO.MemoryStream();
            document.Draw(memorystream);
            memorystream.Seek(0, SeekOrigin.Begin);


            var attachment = new Attachment(memorystream,name+"-invoice.pdf");
            message.Attachments.Add(attachment);

            smtpClient.Send(message);
        }

    }
}
