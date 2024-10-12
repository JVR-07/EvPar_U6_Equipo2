using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvPar_U6_Equipo2.Models;

namespace EvPar_U6_Equipo2.Controllers
{
    public class EmergencyContactPersonsController : Controller
    {
        private readonly HospitalBdContext _context;

        public EmergencyContactPersonsController(HospitalBdContext context)
        {
            _context = context;
        }

        // GET: EmergencyContactPersons
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmergencyContactPerson.ToListAsync());
        }

        // GET: EmergencyContactPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergencyContactPerson = await _context.EmergencyContactPerson
                .FirstOrDefaultAsync(m => m.EmergencyContactPersonID == id);
            if (emergencyContactPerson == null)
            {
                return NotFound();
            }

            return View(emergencyContactPerson);
        }

        // GET: EmergencyContactPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmergencyContactPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmergencyContactPersonID,LastName,FirstName,Mobile,Email")] EmergencyContactPerson emergencyContactPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emergencyContactPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emergencyContactPerson);
        }

        // GET: EmergencyContactPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergencyContactPerson = await _context.EmergencyContactPerson.FindAsync(id);
            if (emergencyContactPerson == null)
            {
                return NotFound();
            }
            return View(emergencyContactPerson);
        }

        // POST: EmergencyContactPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmergencyContactPersonID,LastName,FirstName,Mobile,Email")] EmergencyContactPerson emergencyContactPerson)
        {
            if (id != emergencyContactPerson.EmergencyContactPersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emergencyContactPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmergencyContactPersonExists(emergencyContactPerson.EmergencyContactPersonID))
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
            return View(emergencyContactPerson);
        }

        // GET: EmergencyContactPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergencyContactPerson = await _context.EmergencyContactPerson
                .FirstOrDefaultAsync(m => m.EmergencyContactPersonID == id);
            if (emergencyContactPerson == null)
            {
                return NotFound();
            }

            return View(emergencyContactPerson);
        }

        // POST: EmergencyContactPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emergencyContactPerson = await _context.EmergencyContactPerson.FindAsync(id);
            if (emergencyContactPerson != null)
            {
                _context.EmergencyContactPerson.Remove(emergencyContactPerson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmergencyContactPersonExists(int id)
        {
            return _context.EmergencyContactPerson.Any(e => e.EmergencyContactPersonID == id);
        }
    }
}
