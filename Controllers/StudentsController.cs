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
    public class StudentsController : Controller
    {
        private readonly MobileContext _context;

        public StudentsController(MobileContext context)
        {
            _context = context;
        }

        // GET: Students

        [Authorize]
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewData["LastNameSortParm"] = sortOrder == "lastname_asc" ? "lastname_desc" : "lastname_asc";
            ViewData["IDSortParm"] = sortOrder == "id_asc" ? "id_desc" : "id_asc";
            var students = from s in _context.Students
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Imie);
                    break;
                case "lastname_asc":
                    students = students.OrderBy(s => s.Nazwisko);
                    break;
                case "lastname_desc":
                    students = students.OrderByDescending(s => s.Nazwisko);
                    break;
                case "id_desc":
                    students = students.OrderByDescending(s => s.Id_student);
                    break;
                case "id_asc":
                    students = students.OrderBy(s => s.Id_student);
                    break;
                default:
                    students = students.OrderBy(s => s.Imie);
                    break;
            }

            if (User.Identity.IsAuthenticated)
            {
                return View(await students.AsNoTracking().Include(c => c.Student_Oceny).ToListAsync());
            }
            //return Content(User.Identity.Name);
            return View();
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id_student == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_student,Imie,Nazwisko,Ulica,Kod_pocztowy,Miejscowosc,Email,Password")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            //ViewData["Id_student"] = new SelectList(_context.Students, "Id_student", "Id_student", student.Id_student);
            return View(student);
        }


        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id_student,Imie,Nazwisko,Ulica,Kod_pocztowy,Miejscowosc,Email,Password")] Student student)
        {
            var currentStudent = _context.Students.FirstOrDefault(i => i.Id_student == student.Id_student);
            if (id != student.Id_student)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    currentStudent.Imie = student.Imie;
                    currentStudent.Nazwisko = student.Nazwisko;
                    currentStudent.Ulica = student.Ulica;
                    currentStudent.Kod_pocztowy = student.Kod_pocztowy;
                    currentStudent.Miejscowosc = student.Miejscowosc;

                    //_context.Update(student);
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id_student))
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
            //ViewData["Id_student"] = new SelectList(_context.Students, "Id_student", "Id_student", student.Id_student);

            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id_student == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id_student == id);
        }
    }
}
