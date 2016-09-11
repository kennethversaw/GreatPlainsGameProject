using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using DataContracts;
using Contracts;
using UnityResolver;

namespace Website.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            List<Attendee> attendees = new List<Attendee>();
            UserContext uc = new UserContext();
            uc.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            attendees = UnityCache.ResolveDefault<IRegistrationManager>().GetAllAttendees(uc).ToList();
            return View(attendees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Attendee attendee)
        {
            List<Attendee> attendees = new List<Attendee>();
            attendees.Add(attendee);
            IRegistrationManager regManager = UnityCache.ResolveDefault<IRegistrationManager>();
            UserContext uc = new UserContext();
            uc.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            regManager.ProcessRegistration(uc, attendees);
            return View();
        }
    }
}