using GravelFamily.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravelFamilyWeb.Controllers
{
    public class UnitsController : Controller
    {
        private readonly GravelFamilyContext _context;

        public UnitsController(GravelFamilyContext context)
        {
            _context = context;
        }

        // GET: Units
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Units.ToList());
        }

        // GET: Units/Details/5
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = _context.Units
                .FirstOrDefault(m => m.UnitId == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // GET: Units/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Units/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Unit unit)
        {

            _context.Add(unit);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        // GET: Units/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = _context.Units.Find(id);
            if (unit == null)
            {
                return NotFound();
            }
            return View(unit);
        }

        // POST: Units/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Unit unit)
        {
            if (id != unit.UnitId)
            {
                return NotFound();
            }


            _context.Update(unit);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        // GET: Units/Delete/5
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = _context.Units
                .FirstOrDefault(m => m.UnitId == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var unit = _context.Units.Find(id);
            _context.Units.Remove(unit);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Units.Any(e => e.UnitId == id);
        }
    }
}
