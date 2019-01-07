using CallingHubFromController.SignalR_Backend;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallingHubFromController.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendNotifications()
        {
            return View();
        }

        public PartialViewResult CallingHub()
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<Notifications>();
            hubContext.Clients.All.addNewMessageToPage("you have receive notification on " + DateTime.Now);
            return PartialView();
        }

        public ActionResult recivedNotification()
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
    }
}