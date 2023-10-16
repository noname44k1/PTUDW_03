using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTUDW_03.Models;

namespace PTUDW_03.Controllers
{
    public class BlogController : Controller
    {
        private readonly HarmicContext _context;

        public BlogController(HarmicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.TbBlogs.Where(m => (bool)m.IsActive).OrderByDescending(i => i.BlogId).ToList();
            ViewBag.blogComment = _context.TbBlogComments.Where(m => (bool)m.IsActive).ToList();
            return View(items);
        }

        [Route("/blog/{alias}-{id}.html")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _context.TbBlogs.Where(i => i.BlogId == id && (bool)i.IsActive).FirstOrDefault();
            if (post == null)
            {
                return NotFound();
            }
            ViewBag.blogComment = _context.TbBlogComments.Where(i => i.BlogId == id && (bool)i.IsActive).OrderByDescending(i=>i.CommentId).ToList();
            return View(post);
        }
    }
}
