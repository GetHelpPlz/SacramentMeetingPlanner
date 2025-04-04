using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;
using System.Linq;

namespace SacramentMeetingPlanner.Controllers
{
    public class HymnsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HymnsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Hymns
        public IActionResult Index()
        {
            var hymns = _context.Hymns.OrderBy(h => h.Number).ToList();
            return View(hymns);
        }

        // Hymns/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var hymn = _context.Hymns.FirstOrDefault(h => h.Id == id);
            if (hymn == null) return NotFound();
            return View(hymn);
        }

        // Hymns/Create
        public IActionResult Create()
        {
            return View();
        }

        // Hymns/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hymn hymn)
        {
            if (ModelState.IsValid)
            {
                _context.Hymns.Add(hymn);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(hymn);
        }

        // Hymns/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var hymn = _context.Hymns.Find(id);
            if (hymn == null) return NotFound();
            return View(hymn);
        }

        // POST: /Hymns/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Hymn hymn)
        {
            if (id != hymn.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(hymn);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(hymn);
        }

        // Hymns/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var hymn = _context.Hymns.FirstOrDefault(h => h.Id == id);
            if (hymn == null) return NotFound();
            return View(hymn);
        }

        // Hymns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var hymn = _context.Hymns.Find(id);
            if (hymn != null)
            {
                _context.Hymns.Remove(hymn);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
