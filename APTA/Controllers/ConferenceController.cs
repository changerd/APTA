using APTA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APTA.Controllers
{
    public class ConferenceController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Conference
        public async Task<ActionResult> Index()
        {
            return View(await _context.Conferences.Include(m => m.Members).Include(o => o.Organization).Include(e => e.Events).ToListAsync());
        }
        public ActionResult CreateConference()
        {
            SelectList organizations = new SelectList(_context.Organizations, "OrganizationId", "OrganizationName");
            ViewBag.Organizations = organizations;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateConference(Conference conference)
        {
            if (ModelState.IsValid)
            {
                _context.Conferences.Add(conference);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return (CreateConference());
        }

        public async Task<ActionResult> DeleteConference(int id = 0)
        {
            var conference = await _context.Conferences.FindAsync(id);
            if (conference == null || id == 0)
                return HttpNotFound();
            return View(conference);
        }
        [HttpPost, ActionName("DeleteConference")]
        public async Task<ActionResult> DeleteConferenceConfirmed(int id = 0)
        {
            var conference = await _context.Conferences.FindAsync(id);
            if (conference == null || id == 0)
                return HttpNotFound();
            _context.Conferences.Remove(conference);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> EditConference(int id = 0)
        {
            SelectList organizations = new SelectList(_context.Organizations, "OrganizationId", "OrganizationName");
            ViewBag.Organizations = organizations;
            var conference = await _context.Conferences.FindAsync(id);
            if (conference == null || id == 0)
                return HttpNotFound();
            return View(conference);
        }
        [HttpPost]
        public async Task<ActionResult> EditConference(Conference conference)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(conference).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return await EditConference(conference.ConferenceId);
        }
        public async Task<ActionResult> DetailsConference(int id = 0)
        {
            var conference = await _context.Conferences.Include(m => m.Members).Include(o => o.Organization).Include(e => e.Events).SingleOrDefaultAsync(i => i.ConferenceId == id);
            if (conference == null || id == 0)
                return HttpNotFound();
            return View(conference);
        }
        public ActionResult CreateEvent(int id = 0)
        {
            if (id == 0)
                return HttpNotFound();
            Event _event = new Event()
            {
                ConferenceId = id,
            };
            return View(_event);
        }
        [HttpPost]
        public async Task<ActionResult> CreateEvent(Event _event)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(_event);
                await _context.SaveChangesAsync();
                return RedirectToAction("DetailsConference", new { id = _event.ConferenceId });
            }
            return CreateEvent(_event.ConferenceId);
        }
        public async Task<ActionResult> EditEvent(int id = 0)
        {
            var _event = await _context.Events.FindAsync(id);
            if (_event == null || id == 0)
                return HttpNotFound();
            return View(_event);
        }
        [HttpPost]
        public async Task<ActionResult> EditEvent(Event _event)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(_event).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("DetailsConference", new { id = _event.ConferenceId });
            }
            return await EditEvent(_event.EventId);
        }
        public async Task<ActionResult> DeleteEvent(int id = 0)
        {
            var _event = await _context.Events.FindAsync(id);
            if (_event == null || id == 0)
                return HttpNotFound();
            return View(_event);
        }
        [HttpPost, ActionName("DeleteEvent")]
        public async Task<ActionResult> DeleteEventConfirmed(int id)
        {
            var _event = await _context.Events.FindAsync(id);
            if (_event == null || id == 0)
                return HttpNotFound();
            _context.Events.Remove(_event);
            await _context.SaveChangesAsync();
            return RedirectToAction("DetailsConference", new { id = _event.ConferenceId });
        }
        public async Task<ActionResult> AddMember(int id = 0)
        {
            var conference = await _context.Conferences.FindAsync(id);
            if (conference == null || id == 0)
                return HttpNotFound();
            ViewBag.Members = await _context.Members.OrderBy(n => n.MemberFirstName).ToListAsync();
            return View(conference);
        }
        [HttpPost]
        public async Task<ActionResult> AddMember(Conference conference, int[] selectedMembers)
        {
            var tempconference = _context.Conferences.Find(conference.ConferenceId);
            tempconference.Members.Clear();
            if (selectedMembers != null)
            {
                foreach (var m in _context.Members.Where(m => selectedMembers.Contains(m.MemberId)))
                {
                    tempconference.Members.Add(m);
                }
            }

            _context.Entry(tempconference).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction("DetailsConference", new { id = conference.ConferenceId });

        }
        [HttpPost]
        public async Task<ActionResult> DeleteMember(int mid = 0, int cid = 0)
        {
            if (mid == 0 && cid == 0)
                return HttpNotFound();
            var conference = await _context.Conferences.FindAsync(cid);
            var member = await _context.Members.FindAsync(mid);
            conference.Members.Remove(member);
            _context.Entry(conference).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("DetailsConference", new { id = cid });
        }
    }
}