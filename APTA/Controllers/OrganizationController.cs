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
    public class OrganizationController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
       
        // GET: Organizations list
        public async Task<ActionResult> Index()
        {
            return View(await _context.Organizations.ToListAsync());
        }
        public ActionResult CreateOrganization()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateOrganization(Organization organization)
        {
            if (ModelState.IsValid)
            {
                _context.Organizations.Add(organization);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return (CreateOrganization());
        }

        public async Task<ActionResult> DeleteOrganization(int id = 0)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null || id == 0)
                return HttpNotFound();
            return View(organization);
        }
        [HttpPost, ActionName("DeleteOrganization")]
        public async Task<ActionResult> DeleteOrganizationConfirmed(int id = 0)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null || id == 0)
                return HttpNotFound();
            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> EditOrganization(int id = 0)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null || id == 0)
                return HttpNotFound();
            return View(organization);
        }
        [HttpPost]
        public async Task<ActionResult> EditOrganization(Organization organization)
        {
            if(ModelState.IsValid)
            {
                _context.Entry(organization).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return await EditOrganization(organization.OrganizationId);
        }
        public async Task<ActionResult> DetailsOrganization(int id = 0)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null || id == 0) 
                return HttpNotFound();
            return View(organization);
        }
    }
}