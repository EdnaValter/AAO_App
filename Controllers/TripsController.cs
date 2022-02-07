using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAO_App.Data;
using AAO_App.Models;
using AAO_App.ModelView;
using Microsoft.AspNetCore.Http;

namespace AAO_App.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TripsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Trips
        public ActionResult Index(MyTrip model)
        {

            var MyTripModelData = (from t in _context.Trips
                                   join c in _context.Contacts
                                   on t.Contacts.ContactId equals c.ContactId
                                   join d in _context.Departments
                                   on c.Departments.DepId equals d.DepId
                                   join lo in _context.Locations
                                   on t.Locations.LocationId equals lo.LocationId
                                   join re in _context.RequestedStatus
                                   on t.TripId equals re.TripId
                                   join dr in _context.Drivers
                                   on re.DriverId equals dr.DriverId


            select new MyTrip
                                   {
                                       TripId = t.TripId,
                                       DateStart = t.DateStart,
                                       DateEnd = t.DateEnd,
                                       Message = t.Message,
                                       DeliveryInfo = t.DeliveryInfo,
                                       Firstname = c.Firstname,
                                       Lastname = c.Lastname,
                                       Phone = c.Phone,
                                       Email = c.Email,                                     
                                       DepName = d.DepName,
                                       Country = d.Country,
                                       City = lo.City,
                                       CountryCode = lo.CountryCode,
                                       DriverId = dr.DriverId,
                                       Status = re.Status,
                                       RequestId = re.RequestId
                                   }).ToList();
            return View(MyTripModelData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Request(int requestId, int driverID)
        {
         
            if (ModelState.IsValid)
            {

               int noOfRowUpdated = _context.Database.ExecuteSqlRaw("Update RequestedStatus set Status = 1, driverid = " + driverID + " where requestid = " + requestId);

                //update table RequestedStatus set DriverId = current diriver logged in, set Status = 1 (Requested) where TripId = clicked tripid
                ////_context.Add(R);
                ////await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }






        public ActionResult Notification(MyTrip model)
        {

            var MyTripModelData = (from t in _context.Trips
                                   join c in _context.Contacts
                                   on t.Contacts.ContactId equals c.ContactId
                                   join d in _context.Departments
                                   on c.Departments.DepId equals d.DepId
                                   join lo in _context.Locations
                                   on t.Locations.LocationId equals lo.LocationId
                                   join re in _context.RequestedStatus
                                   on t.TripId equals re.TripId
                                   join dr in _context.Drivers
                                   on re.DriverId equals dr.DriverId 


                                   select new MyTrip
                                   {
                                       TripId = t.TripId,
                                       DateStart = t.DateStart,
                                       DateEnd = t.DateEnd,
                                       Message = t.Message,
                                       DeliveryInfo = t.DeliveryInfo,
                                       Firstname = c.Firstname,
                                       Lastname = c.Lastname,
                                       Phone = c.Phone,
                                       Email = c.Email,
                                       DepName = d.DepName,
                                       Country = d.Country,
                                       City = lo.City,
                                       CountryCode = lo.CountryCode,
                                       DriverId = dr.DriverId,
                                       Status = re.Status,
                                       RequestId = re.RequestId
                                   }).ToList();


            return View(MyTripModelData);

        }
        public ActionResult History(MyTrip model)
        {

            var MyTripModelData = (from t in _context.Trips
                                   join c in _context.Contacts
                                   on t.Contacts.ContactId equals c.ContactId
                                   join d in _context.Departments
                                   on c.Departments.DepId equals d.DepId
                                   join lo in _context.Locations
                                   on t.Locations.LocationId equals lo.LocationId
                                   join re in _context.RequestedStatus
                                   on t.TripId equals re.TripId
                                   where re.Status == Status.Approved
                                   join dr in _context.Drivers
                                   on re.DriverId equals dr.DriverId


                                   select new MyTrip
                                   {
                                       TripId = t.TripId,
                                       DateStart = t.DateStart,
                                       DateEnd = t.DateEnd,
                                       Message = t.Message,
                                       DeliveryInfo = t.DeliveryInfo,
                                       Firstname = c.Firstname,
                                       Lastname = c.Lastname,
                                       Phone = c.Phone,
                                       Email = c.Email,
                                       DepName = d.DepName,
                                       City = lo.City,
                                       CountryCode = lo.CountryCode,
                                       DriverId = dr.DriverId,
                                       Status = re.Status
                                   }).ToList();


            return View(MyTripModelData);

        }
    
        public ActionResult Contact(MyTrip model)
        {

            var MyContactModelData = (from c in _context.Contacts 
                                      join de in _context.Departments
                                      on c.Departments.DepId equals de.DepId
                                      join lo in _context.Locations
                                      on de.DepId equals lo.Departments.DepId

                                      select new MyTrip
                                      {
                                          Firstname = c.Firstname,
                                          Lastname = c.Lastname,
                                          Phone = c.Phone,
                                          Email = c.Email,
                                          DepName = de.DepName,
                                          DepId = de.DepId,
                                          Country = lo.Country
                                          
                                      }).ToList();

            return View(MyContactModelData);


        }

    }
}
