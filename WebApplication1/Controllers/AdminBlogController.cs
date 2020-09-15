using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminBlogController : Controller
    {
        dbemarktingEntities4 db = new dbemarktingEntities4();
        // GET: AdminBlog
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult login(admin_for_blogerr avm)
        {
            admin_for_blogerr ad = db.admin_for_blogerr.Where(x => x.adblog_username == avm.adblog_username && x.adblog_password == avm.adblog_password).SingleOrDefault();
            if (ad != null)
            {

                Session["adblog_id"] = ad.adblog_id.ToString();
                return RedirectToAction("CreateBlog");




            }
            else
            {
                ViewBag.error = "Invalid username or password";

            }

            return View();
        }
        [HttpGet]
        public ActionResult CreateBlog()
        {
            if (Session["adblog_id"] == null)
            {
                return RedirectToAction("login");
            }
            return View();
        }


        [HttpPost]
        public ActionResult CreateBlog(blog cvm, HttpPostedFileBase imgfile)
        {
            string path = uploadimgfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded....";
            }
            else
            {
                blog cat = new blog();

                cat.title = cvm.title;
                cat.blog_im = path;
                cat.blog_content = cvm.blog_content;
                cat.adblog = Convert.ToInt32(Session["adblog_id"].ToString());
                db.blogs.Add(cat);
                db.SaveChanges();
                return RedirectToAction("ViewBlog");
            }

            return View();
        }

        



        public string uploadimgfile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {

                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);

                        //    ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Please select a file'); </script>");
                path = "-1";
            }



            return path;
        }


        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}