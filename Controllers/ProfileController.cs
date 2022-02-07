using AAO_App.Data;
using AAO_App.Models;
using AAO_App.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_App
{
    public class ProfileController : Controller
    {

        //dependency Injection
        private readonly ApplicationDbContext _db;

        public ProfileController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ActionResult Index(ProfileModelView model)
        {

            var MyProfileModelData = (from dr in _db.Drivers
                                      join lo in _db.Locations
                                      on dr.Locations.LocationId equals lo.LocationId
                                      where dr.DriverId == int.Parse(HttpContext.Session.GetString("DriverId"))

                                      select new ProfileModelView
                                      {
                                          Firstname = dr.Firstname,
                                          Lastname = dr.Lastname,
                                          Addresse = dr.Addresse,
                                          Phone = dr.Phone,
                                          DoB = dr.DoB,
                                          Password = dr.Password,
                                          ProfileImage = dr.ProfileImage,
                                          License = dr.License,
                                          City = lo.City,
                                          CountryCode = lo.CountryCode,
                                          DriverId = dr.DriverId,

                                      }).ToList();

            return View(MyProfileModelData);

        }

        //GET: DriverTest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _db.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            //  ViewData["CityId"] = new SelectList(_db.Cities, "CityId", "CityId", driver.CityId);
            return View(driver);
        }

        // POST: DriverTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DriverId,Firstname,Lastname,Addresse,Phone,DoB" +
            ",Password,ProfileImage,License")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    driver.DriverId = id;
                    driver.DriverId = int.Parse(this.HttpContext.Session.GetString("DriverId"));
                    driver.Locations.LocationId = int.Parse(this.HttpContext.Session.GetString("LocationId"));
                    _db.Update(driver);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driver.DriverId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(driver);
        }

        public IActionResult Setting()
        {
            return View();
        }

        // GET: DriverTest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            var driver = await _db.Drivers
                .Include(d => d.Locations.City)
                .FirstOrDefaultAsync(m => m.DriverId == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: DriverTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driver = await _db.Drivers.FindAsync(int.Parse(this.HttpContext.Session.GetString("DriverId")));
            _db.Drivers.Remove(driver);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Login");
        }

        private bool DriverExists(int id)
        {
            return _db.Drivers.Any(e => e.DriverId == id);
        }
    }
}
