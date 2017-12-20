using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThinkSmartSchools.Models;

namespace ThinkSmartSchools.Areas.StaffUsers.Controllers
{
    [Area("StaffUsers")]
    public class SessionsController : Controller
    {
        private readonly ForSchoolsDBContext _context;

        public SessionsController(ForSchoolsDBContext context)
        {
            _context = context;
        }

        // GET: StaffUsers/Sessions
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Session.ToListAsync());
        //}

        public IActionResult Index()
        {
            return ViewComponent("SessionCRUD");
        }
        
        // GET: StaffUsers/Sessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Session
                .SingleOrDefaultAsync(m => m.Id == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // GET: StaffUsers/Sessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffUsers/Sessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status")] Session session)
        {
            if (ModelState.IsValid)
            {
                if (session.Status)
                {
                    var entries = _context.Session.Where(x => x.Status == true);
                    if (entries != null)
                    {
                        foreach (var entry in entries) { entry.Status = false; _context.Update(entry); }
                    }
                }
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Configurations");
            }
            return View(session);
        }

        // GET: StaffUsers/Sessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Session.SingleOrDefaultAsync(m => m.Id == id);
            if (session == null)
            {
                return NotFound();
            }
            return View(session);
        }

        // POST: StaffUsers/Sessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status")] Session session)
        {
            if (id != session.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (session.Status)
                    {
                        var entries = _context.Session.Where(x => x.Status == true);
                        if (entries != null)
                        {
                            foreach (var entry in entries) { entry.Status = false; _context.Update(entry); }
                        }
                    }
                    _context.Update(session);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionExists(session.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Configurations");
            }
            return View(session);
        }

        // GET: StaffUsers/Sessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Session
                .SingleOrDefaultAsync(m => m.Id == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: StaffUsers/Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.Session.SingleOrDefaultAsync(m => m.Id == id);
            _context.Session.Remove(session);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Configurations");
        }

        private bool SessionExists(int id)
        {
            return _context.Session.Any(e => e.Id == id);
        }
    }
}
