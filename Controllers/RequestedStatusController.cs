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

namespace AAO_App.Controllers
{
    public class RequestedStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestedStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RequestedStatus
        public ActionResult Index(CalendarModelView model)
        {

            var MyTripModelData = (from Re in _context.RequestedStatus
                                   join t in _context.Trips
                                   on Re.TripId equals t.TripId
                                   join dr in _context.Drivers
                                   on Re.DriverId equals dr.DriverId


                                   select new CalendarModelView
                                   {
                                       TripId = t.TripId,
                                       DateStart = t.DateStart,
                                       DateEnd = t.DateEnd,
                                       Message = t.Message,
                                       DeliveryInfo = t.DeliveryInfo,
                                       DriverId = dr.DriverId,
                                       Status = Re.Status,
                                       RequestId = Re.RequestId
                                   }).ToList();
            return View(MyTripModelData);
        }

        // GET: RequestedStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestedStatus = await _context.RequestedStatus
                .Include(r => r.Drivers)
                .Include(r => r.Trips)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (requestedStatus == null)
            {
                return NotFound();
            }

            return View(requestedStatus);
        }

        // GET: RequestedStatus/Create
        public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "Addresse");
            ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId");
            return View();
        }

        // POST: RequestedStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,TripId,DriverId,Status")] RequestedStatus requestedStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestedStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "Addresse", requestedStatus.DriverId);
            ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId", requestedStatus.TripId);
            return View(requestedStatus);
        }

        // GET: RequestedStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestedStatus = await _context.RequestedStatus.FindAsync(id);
            if (requestedStatus == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "Addresse", requestedStatus.DriverId);
            ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId", requestedStatus.TripId);
            return View(requestedStatus);
        }

        // POST: RequestedStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,TripId,DriverId,Status")] RequestedStatus requestedStatus)
        {
            if (id != requestedStatus.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestedStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestedStatusExists(requestedStatus.RequestId))
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
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "Addresse", requestedStatus.DriverId);
            ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId", requestedStatus.TripId);
            return View(requestedStatus);
        }

        // GET: RequestedStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestedStatus = await _context.RequestedStatus
                .Include(r => r.Drivers)
                .Include(r => r.Trips)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (requestedStatus == null)
            {
                return NotFound();
            }

            return View(requestedStatus);
        }

        // POST: RequestedStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestedStatus = await _context.RequestedStatus.FindAsync(id);
            _context.RequestedStatus.Remove(requestedStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestedStatusExists(int id)
        {
            return _context.RequestedStatus.Any(e => e.RequestId == id);
        }
    }
}
