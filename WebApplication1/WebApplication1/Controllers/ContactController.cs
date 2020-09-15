using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
      dbemarktingEntities1  db = new dbemarktingEntities1();
        // GET: Contact
        public ActionResult Index()
        {
           
            return View(db.contacts.ToList());
        }

        public ActionResult create()
        {

            return View(new contact());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> create(contact model)
        {
            if (ModelState.IsValid) {
                db.contacts.Add(model);
               await  db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}