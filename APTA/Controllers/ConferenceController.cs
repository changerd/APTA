using APTA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    }
}