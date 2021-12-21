using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using G2G1FinalProject.Data;
using G2G1FinalProject.Models;

namespace G2G1FinalProject.Areas.Client.Controllers
{
    [Area("Client")]
    public class CoursesController : Controller
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Client/Courses
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Courses.Include(c => c.Category).Include(c => c.Trainer);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Client/Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Trainer)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Client/Courses/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerName");
            return View();
        }

        // POST: Client/Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,CourseName,CoursePrice,CourseDate,CategoryId,TrainerId")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", course.CategoryId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerName", course.TrainerId);
            return View(course);
        }

    }
}
