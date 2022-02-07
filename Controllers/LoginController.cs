using AAO_App.Data;
using AAO_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AAO_App
{
    [Route("login")]

    public class LoginController : Controller
    {
        //dependency Injection
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("")]
        [Route("Index")]
        [Route("~/")]
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Route("index")]
        [HttpPost]
        public IActionResult Login(string phone, string password)
        {
            //var User = _context.Drivers.Select(d => d).Where(d => d.Phone == phone);
            //bool verified = BC.Verify(password, _context.Drivers.Select(d => d).Where(d => d.Password == d.Password)); Maybe some day
            var driver = _context.Drivers.Select(d => d).Where(d => d.Phone == phone && d.Password == password).ToList();
            if (phone != null && password != null && driver.Count() > 0) 
            {

                //HttpContext.Session.SetString("Addresse", driver[0].Addresse);
                //HttpContext.Session.SetString("DoB", driver[0].DoB.ToString());
                //HttpContext.Session.SetString("Locations.City", driver[0].Locations.City);
                HttpContext.Session.SetString("DriverId", driver[0].DriverId.ToString());
                HttpContext.Session.SetString("Firstname", driver[0].Firstname);
                HttpContext.Session.SetString("Lastname", driver[0].Lastname);
                //HttpContext.Session.SetString("CityId", driver[0].Locations.City);
                //HttpContext.Session.SetString("Locations.CountryCode", driver[0].Locations.CountryCode);
                //HttpContext.Session.SetString("Phone", driver[0].Phone);

                return RedirectToAction("Index", "Trips");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }
        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("phone");
            return RedirectToAction("Index");
        }

    }

}
