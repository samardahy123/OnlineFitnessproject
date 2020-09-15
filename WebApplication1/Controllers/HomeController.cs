using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModel contact)
        {

            var mail = new MailMessage();
            var LogInfo = new NetworkCredential("ssamarrdd818", "ssamar12345");
            mail.From = new MailAddress(contact.email);
            mail.To.Add("samardahy891@gmail.com");
            mail.Subject = contact.suject;
            mail.Body = contact.Message;

            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = LogInfo;
            smtpClient.Send(mail);

            return RedirectToAction("Index");
        }





    }
}
