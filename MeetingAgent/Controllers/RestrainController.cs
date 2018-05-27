using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingAgent.Controllers
{
    [Authorize]
    public class RestrainController : Controller
    {

        public ActionResult GetRestrain([DataSourceRequest] DataSourceRequest request)
        {

            string current_usr = User.Identity.GetUserId();
            using (var context = new MeetingContext())
            {


                // Query for the Blog named ADO.NET Blog 
                var query = context.rst_restrain
                                .Where(b => b.user_id == current_usr);



                List<rst_restrain> cc = query.ToList();
                return Json(cc.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }


            //  return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);


        }

        // GET: Restrain
        public ActionResult Index()
        {
            return View();
        }

        // GET: Restrain/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Restrain/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restrain/Create
        [HttpPost]
        public ActionResult Create(rst_restrain restrain)
        {
            try
            {
                //// TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(restrain);
                }

                string current_usr = User.Identity.GetUserId();
                restrain.user_id = current_usr;
                using (var db = new MeetingContext())
                {
                    
                        db.rst_restrain.Add(restrain);
                        db.SaveChanges();
                    
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restrain/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restrain/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restrain/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restrain/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
