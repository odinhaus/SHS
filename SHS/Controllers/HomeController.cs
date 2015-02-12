using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHS.Data;
using SHS.Models;

namespace SHS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Industries = Enum.GetNames(typeof(Industry));
            ViewBag.Title = "Submit your feedback!";
            ViewBag.Message = "We want to hear from you...";
            ViewBag.Banner = "Survey";
            return View();
        }

        [HttpPost]
        public ActionResult Submit(Feedback feedback)
        {
            using (var ctx = DataContext.FeedbackContext())
            {
                ctx.Feedback.Add(feedback);
                ctx.SaveChanges();
            }

            return Json((ActionResponse)"/Home/ThankYou", "application/json");
        }

        public ActionResult ThankYou()
        {
            ViewBag.Title = "";
            ViewBag.Message = "Thanks for your feedback.  To view other results, follow the link below...";
            ViewBag.Banner = "Thank You!";
            return View();
        }

        public ActionResult Results()
        {
            using(var ctx = DataContext.FeedbackContext())
            {
                var results = ctx.Feedback.ToArray();
                ViewBag.Message = "Feedback results...";
                ViewBag.Banner = "Results";
                ViewBag.Results = results;
                ViewBag.AverageRating = results.Length > 0 ? results.Average(f => f.Rating).ToString() : "No Feedback";
            }

           return View();
        }
    }
}
