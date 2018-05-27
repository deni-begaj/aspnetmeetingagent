using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingAgent.Controllers
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public bool Edit()
        {
            using (var db = new MeetingContext())
            {
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: ");

                var mtg = new mtg_meeting { place = "Dubai" };
                db.mtg_meeting.Add(mtg);
                db.SaveChanges();

                // Display all Blogs from the database 
                //var query = from b in db.Blogs
                //            orderby b.Name
                //            select b;

                //Console.WriteLine("All blogs in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.Name);
                ////}

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }

            return true;
        }
    }
}