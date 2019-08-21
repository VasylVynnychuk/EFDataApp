using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFDataApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace EFDataApp.Controllers
{
    public class Student_OcenyController : Controller
    {
        private readonly MobileContext _context;

        public Student_OcenyController(MobileContext context)
        {
            _context = context;
        }

        // GET: Student_Oceny
   
        public async Task<IActionResult> Index()
        {
            var mobileContext = _context.Student_Oceny.Include(s => s.Student);
            return View(await mobileContext.ToListAsync());
        }

        // GET: Student_Oceny/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Oceny = await _context.Student_Oceny
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id_oceny == id);
            if (student_Oceny == null)
            {
                return NotFound();
            }

            return View(student_Oceny);
        }

        // GET: Student_Oceny/Create
        public IActionResult Create()
        {
           

            ViewData["Id_student"] = new SelectList(_context.Students, "Id_student", "Id_student");
            return View();
        }

        // POST: Student_Oceny/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_oceny,Ocena,Ocena_slownie,Id_student")] Student_Oceny student_Oceny)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student_Oceny);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_student"] = new SelectList(_context.Students, "Id_student", "Id_student", student_Oceny.Id_student);
            return View(student_Oceny);
        }

        // GET: Student_Oceny/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Oceny = await _context.Student_Oceny.FindAsync(id);
            if (student_Oceny == null)
            {
                return NotFound();
            }
            ViewData["Id_student"] = new SelectList(_context.Students, "Id_student", "Id_student", student_Oceny.Id_student);
            return View(student_Oceny);
        }

        // POST: Student_Oceny/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_oceny,Ocena,Ocena_slownie,Id_student")] Student_Oceny student_Oceny)
        {
            if (id != student_Oceny.Id_oceny)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student_Oceny);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student_OcenyExists(student_Oceny.Id_oceny))
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
            ViewData["Id_student"] = new SelectList(_context.Students, "Id_student", "Id_student", student_Oceny.Id_student);
            return View(student_Oceny);
        }

        // GET: Student_Oceny/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Oceny = await _context.Student_Oceny
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id_oceny == id);
            if (student_Oceny == null)
            {
                return NotFound();
            }

            return View(student_Oceny);
        }

        // POST: Student_Oceny/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student_Oceny = await _context.Student_Oceny.FindAsync(id);
            _context.Student_Oceny.Remove(student_Oceny);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Student_OcenyExists(int id)
        {
            return _context.Student_Oceny.Any(e => e.Id_oceny == id);
        }
    }
}
