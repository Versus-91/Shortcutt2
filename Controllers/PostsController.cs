using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shortcutt.Data;
using Shortcutt.Models;
using Shortcutt.ViewModels;
using System.Diagnostics;
using System.Security.Claims;

namespace Shortcutt.Controllers
{
    public class PostsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _context;

        public PostsController(ILogger<HomeController> logger, ApplicationDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePost inputs)
        {
            if (ModelState.IsValid)
            {
                var post = inputs.MapToPost();
                post.UserId =  User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _context.Posts.AddAsync(post);
                if (inputs.Image is not null)
                {
                    var filePath = Path.Combine(_env.WebRootPath,"images",
                        Path.GetRandomFileName() + Path.GetExtension(inputs.Image.FileName));

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await inputs.Image.CopyToAsync(stream);
                    }
                }
                ViewData["message"] = "پست با موفقیت ثبت شد.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}