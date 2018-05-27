using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MeetingAgent.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MeetingAgent.Controllers
{
    [Authorize]
    public class MeetingController : Controller
    {

        // GET: Meeting
        public ActionResult Index()
        {

            VMeetingList model = new VMeetingList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(VMeetingList MeetingDate)
        {
            try
            {
                //// TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(MeetingDate);
                }
                var approve = MeetingDate.VMeetingModelListRels.Where(p => p.IsApproved == true);
                var reject = MeetingDate.VMeetingModelListRels.Where(p => p.IsRejected == true);

                using (var db = new MeetingContext())
                {
                    foreach (var item in approve)
                    {
                        int relId = item.RelId;

                        var originalObject = db.mtg_user_meeting_rel.SingleOrDefault(b => b.id == relId);

                        originalObject.status_id = 2;
                        db.SaveChanges();
                    }


                    foreach (var item in reject)
                    {
                        int relId = item.RelId;

                        var originalObject = db.mtg_user_meeting_rel.SingleOrDefault(b => b.id == relId);
                        originalObject.status_id = 3;
                        db.SaveChanges();
                    }

                }

                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                return View(MeetingDate);
            }
        }

        
        public ActionResult GetMeetingForApproval([DataSourceRequest] DataSourceRequest request)
        {

            string current_usr = User.Identity.GetUserId();
            using (var context = new MeetingContext())
            {


                // Query for the Blog named ADO.NET Blog 
                var query = context.v_meeting
                                .Where(b => b.status_id == 1 &&
                                            b.user_id== current_usr);



            List<v_meeting> cc = query.ToList();
                return Json(cc.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }


          //  return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
           

        }

        public ActionResult GetMeetingApproved([DataSourceRequest] DataSourceRequest request)
        {

            string current_usr = User.Identity.GetUserId();
            using (var context = new MeetingContext())
            {


                // Query for the Blog named ADO.NET Blog 
                var query = context.v_meeting
                                .Where(b => b.status_id == 2 &&
                                            b.user_id == current_usr);



                List<v_meeting> cc = query.ToList();
                return Json(cc.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }



        }
        
        public ActionResult GetCheckMeeting([DataSourceRequest] DataSourceRequest request)
        {

            string current_usr = User.Identity.GetUserId();
            using (var context = new MeetingContext())
            {


                // Query for the Blog named ADO.NET Blog 
                var query = context.v_check_meeting
                                .Where(b => b.user_id != current_usr).Where(b => b.created_user == current_usr);



                List<v_check_meeting> cc = query.ToList();
                return Json(cc.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }



        }
        public ActionResult GetMeetingRejected([DataSourceRequest] DataSourceRequest request)
        {

            string current_usr = User.Identity.GetUserId();
            using (var context = new MeetingContext())
            {


                // Query for the Blog named ADO.NET Blog 
                var query = context.v_meeting
                                .Where(b => b.status_id == 3 &&
                                            b.user_id == current_usr);



                List<v_meeting> cc = query.ToList();
                return Json(cc.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }



        }

        // GET: Meeting/Create
        public ActionResult Create()
        {
            ViewBag.ChildModel = new UserViewModelList();
            return View();
        }
        public ActionResult GetUsers([DataSourceRequest] DataSourceRequest request)
        {
            //convert string to date end to time

            //if (string.IsNullOrEmpty(date) || (string.IsNullOrEmpty(startHour)) || (string.IsNullOrEmpty(endHour)))
            //{
            //    return null;
            //}
            //else
            //{
            //DateTime _date;
            //DateTime.TryParseExact(date + " 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out _date);

            //DateTime date_startHour = DateTime.ParseExact(startHour, "HH:mm",
            //                            CultureInfo.InvariantCulture);

            //DateTime date_endHour = DateTime.ParseExact(endHour, "HH:mm",
            //                     CultureInfo.InvariantCulture);
            //TimeSpan _startHour = date_startHour.TimeOfDay;
            //TimeSpan _endHour = date_endHour.TimeOfDay;

            string current_usr = User.Identity.GetUserId();

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            List<UserViewModel> model = new List<UserViewModel>();
            using (var connection = new SqlConnection(connString)) 
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spc_GetUsers]", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //command.Parameters.AddWithValue("@p_post_date", _date);
                    //command.Parameters.AddWithValue("@p_start_hour", _startHour);
                    //command.Parameters.AddWithValue("@p_end_hour", _endHour);
                    command.Parameters.AddWithValue("@p_user", current_usr);

                        using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) {
                            UserViewModel temp = new UserViewModel();
                            temp.Identification = reader["Id"].ToString();
                            temp.FullName = reader["FullName"].ToString();
                            temp.Email =reader["Email"].ToString();
                            model.Add(temp);
                        }
                        
                    }

                    //connection.close();
                    
                }
            }
            //return item 

            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
           // }
         
        }


        // POST: Meeting/Create
        [HttpPost]
        public ActionResult Create(DateTime? MeetingDate, mtg_meeting meeting, UserViewModelList user)
        {
            try
            {
                //// TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(meeting);
                }
                var temp = user.UserViewModelListRels.Where(p => p.IsChecked == true);
                string current_usr = User.Identity.GetUserId();
                meeting.created_user = current_usr;
                meeting.created_date = DateTime.Now;
                meeting.date = MeetingDate;
                using (var db = new MeetingContext())
                {
                    db.mtg_meeting.Add(meeting);
                    db.SaveChanges();

                    mtg_user_meeting_rel rel_current_user = new mtg_user_meeting_rel();
                    rel_current_user.meeting_id = meeting.id;
                    rel_current_user.user_id = current_usr;
                    rel_current_user.status_id = 2; // approved
                    db.mtg_user_meeting_rel.Add(rel_current_user);
                    db.SaveChanges();
                    
                    foreach (var item in temp)
                    {
                        mtg_user_meeting_rel rel = new mtg_user_meeting_rel();
                        rel.meeting_id = meeting.id;
                        rel.user_id = item.Identification;
                        rel.status_id = 1;  //pending approval
                        db.mtg_user_meeting_rel.Add(rel);
                        db.SaveChanges();
                    }

                }

                return RedirectToAction("Index","Home");
            }
            catch(Exception ex)
            {
                return View(meeting);
            }
        }

       
         
    }
}
