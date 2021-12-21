using G2G1FinalProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace G2G1FinalProject.ViewComponents
{
    public class CourseViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public CourseViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var appDbContext = _db.Courses.Include(c => c.Category).Include(c => c.Trainer);
            return View(appDbContext.ToList());
        }
    }
}
