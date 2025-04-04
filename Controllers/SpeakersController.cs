using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpeakersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Speakers
        public IActionResult Index()
        {
            var speakers = _context.Speakers.ToList();
            return View(speakers);
        }

        // Speakers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var speaker = _context.Speakers.FirstOrDefault(s => s.Id == id);
            if (speaker == null) return NotFound();

            return View(speaker);
        }

        // Speakers/Create
        public IActionResult Create()
        {
            return View();
        }

        // Speakers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                _context.Speakers.Add(speaker);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(speaker);
        }

        // Speakers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var speaker = _context.Speakers.Find(id);
            if (speaker == null) return NotFound();

            return View(speaker);
        }

        // Speakers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Speaker speaker)
        {
            if (id != speaker.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(speaker);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(speaker);
        }

        // Speakers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var speaker = _context.Speakers.FirstOrDefault(s => s.Id == id);
            if (speaker == null) return NotFound();

            return View(speaker);
        }

        // Speakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var speaker = _context.Speakers.Find(id);
            if (speaker != null)
            {
                _context.Speakers.Remove(speaker);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
