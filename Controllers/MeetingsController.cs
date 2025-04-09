using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;
using System.Linq;

namespace SacramentMeetingPlanner.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Meetings/Create
        public IActionResult Create()
        {
            var speakers = _context.Speakers
                .Select(s => new { s.Id, FullName = s.FirstName + " " + s.LastName })
                .ToList();
            var hymns = _context.Hymns
                .OrderBy(h => h.Number)
                .Select(h => new { h.Id, h.Name })
                .ToList();

            ViewBag.SpeakerOptions = speakers;
            ViewBag.HymnOptions = hymns;

            return View();
        }

        // Meetings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _context.Meetings.Add(meeting);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(meeting);
        }

        // Meetings
        public IActionResult Index(string sortOrder)
        {
            var meetingsQuery = _context.Meetings
                .Include(m => m.Hymns)
                .Include(m => m.Speakers)
                .AsQueryable();

            switch (sortOrder)
            {
                case "date_desc":
                    meetingsQuery = meetingsQuery.OrderByDescending(m => m.MeetingDateTime);
                    break;
                default:
                    meetingsQuery = meetingsQuery.OrderBy(m => m.MeetingDateTime);
                    break;
            }

            var meetings = meetingsQuery.ToList();
            return View(meetings);
        }

        // Meetings/Details/5
        public IActionResult Details(int id)
        {
            var meeting = _context.Meetings
                .Include(m => m.Hymns)
                .Include(m => m.Speakers)
                .FirstOrDefault(m => m.Id == id);

            if (meeting == null)
                return NotFound();

            foreach (var hymn in meeting.Hymns)
            {
                int hymnId;
                if (int.TryParse(hymn.SelectedHymn, out hymnId))
                {
                    var hymnData = _context.Hymns.FirstOrDefault(h => h.Id == hymnId);
                    if (hymnData != null)
                    {
                        hymn.SelectedHymn = hymnData.Name;
                    }
                }
            }

            foreach (var speaker in meeting.Speakers)
            {
                int speakerId;
                if (int.TryParse(speaker.SelectedSpeaker, out speakerId))
                {
                    var speakerData = _context.Speakers.FirstOrDefault(s => s.Id == speakerId);
                    if (speakerData != null)
                    {
                        speaker.SelectedSpeaker = $"{speakerData.FirstName} {speakerData.LastName}";
                    }
                }
            }

            return View(meeting);
        }

        // Meetings/Edit/5
        public IActionResult Edit(int id)
        {
            var meeting = _context.Meetings
                .Include(m => m.Hymns)
                .Include(m => m.Speakers)
                .FirstOrDefault(m => m.Id == id);

            if (meeting == null)
                return NotFound();

            return View(meeting);
        }

        // Meetings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Meeting meeting)
        {
            if (id != meeting.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(meeting);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // Meetings/Delete/5
        public IActionResult Delete(int id)
        {
            var meeting = _context.Meetings.FirstOrDefault(m => m.Id == id);
            if (meeting == null)
                return NotFound();

            return View(meeting);
        }

        // Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var meeting = _context.Meetings.Find(id);
            if (meeting != null)
            {
                _context.Meetings.Remove(meeting);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
