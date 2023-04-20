using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;

namespace InvoiceCreatorFrontend.helpers
{
    public class EmailHelper
    {
        public static void SendEmail(string email, string name)
        {
            var smtpClient = new SmtpClient("levelup-invoice.stuffs.co.za",587)
            {
                Credentials = new NetworkCredential("no-reply@levelup-invoice.stuffs.co.za", "BBDInvoice123!"),
                EnableSsl = true,
            };
            smtpClient.Send("no-reply@levelup-invoice.stuffs.co.za","stevenp@bbd.co.za","PAY ME", "PAY ME SOME MORE");
            
        }
    }
}
