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
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Members list
        public async Task<ActionResult> Index()
        {
            return View(await _context.Members.ToListAsync());
        }
        public ActionResult CreateMember()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateMember(Member member)
        {
            member.MemberRegistrationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return CreateMember();
        }
        public async Task<ActionResult> DeleteMember(int id = 0)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null || id == 0)
                return HttpNotFound();
            return View(member);
        }
        [HttpPost, ActionName("DeleteMember")]
        public async Task<ActionResult> DeleteMemberConfirmed(int id = 0)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null || id == 0)
                return HttpNotFound();
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> EditMember(int id = 0)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null || id == 0)
                return HttpNotFound();
            return View(member);
        }
        [HttpPost]
        public async Task<ActionResult> EditMember(Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(member).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return await EditMember(member.MemberId);
        }
        public async Task<ActionResult> DetailsMember(int id = 0)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null || id == 0)
                return HttpNotFound();
            return View(member);
        }
    }
}