using Agora.MODEL.Dto;
using System.Net;
using System.Net.Mail;

namespace Agora.UI.Helper
{
    public class SendMail
    {
        public bool Contact(MailDto mail)  //Mail sınıfından m diye bir değişken tanımlarız
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Burası aynı kalacak
                client.Credentials = new NetworkCredential("esryrlmz@gmail.com", "*****");
                client.EnableSsl = true;
                MailMessage msj = new MailMessage(); 
                msj.From = new MailAddress(mail.mail);
                msj.To.Add("esryrlmz@gmail.com"); 
                msj.Subject = mail.subject;
                msj.Body = mail.text; 
               // client.Send(msj);
               // EVDEKİ PCDEN KONTROL ET PROXYDEN DOLAYI MAİL ATMIYOR OLABİLİR
                return true;
            }
            catch (System.Exception )
            {
                return false;
            }
        }
    }
}
