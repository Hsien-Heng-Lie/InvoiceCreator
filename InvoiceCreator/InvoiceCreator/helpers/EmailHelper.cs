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

            string emailString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("EmailSettings")["Email"];
            string passwordString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("EmailSettings")["Password"];

            var smtpClient = new SmtpClient(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("EmailSettings")["Client"], 587)
            {
                Credentials = new NetworkCredential(emailString,
                    passwordString
                    ),
                EnableSsl = true,
            };

            var message = new MailMessage();
            message.From = new MailAddress(emailString);
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
