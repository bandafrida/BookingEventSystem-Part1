using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingEvent.Models;

namespace BookingEvent.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // INDEX - SHOW ALL EVENTS
        // =========================
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.ToListAsync();
            return View(events);
        }

        // =========================
        // DETAILS
        // =========================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var eventModel = await _context.Events
                .FirstOrDefaultAsync(e => e.EventId == id);

            if (eventModel == null) return NotFound();

            return View(eventModel);
        }

        // =========================
        // CREATE (GET)
        // =========================
        public IActionResult Create()
        {
            return View();
        }

        // =========================
        // CREATE (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event eventModel)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(eventModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(eventModel);
        }

        // =========================
        // EDIT (GET)
        // =========================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var eventModel = await _context.Events.FindAsync(id);

            if (eventModel == null) return NotFound();

            return View(eventModel);
        }

        // =========================
        // EDIT (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Event eventModel)
        {
            if (id != eventModel.EventId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(eventModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(eventModel);
        }

        // =========================
        // DELETE (GET)
        // =========================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var eventModel = await _context.Events
                .FirstOrDefaultAsync(e => e.EventId == id);

            if (eventModel == null) return NotFound();

            return View(eventModel);
        }

        // =========================
        // DELETE (POST)
        // =========================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventModel = await _context.Events.FindAsync(id);

            _context.Events.Remove(eventModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}