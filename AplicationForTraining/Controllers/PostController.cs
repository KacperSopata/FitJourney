using ApplicationForTrainingWEB.Application.Interfaces;
using ApplicationForTrainingWEB.Application.ViewModels.PostVm;
using ApplicationForTrainingWEB.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AplicationForTraining.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly UserManager<ApplicationUser> _userManager;
        public PostController(IPostService postService, UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _userManager = userManager;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _postService.GetAllPostForList(10, 1, "");
            var userId = _userManager.GetUserId(User);
            var isAdmin = User.IsInRole("Admin");
            ViewBag.IsAdmin = isAdmin;
            ViewBag.UserId = userId;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _postService.GetAllPostForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }


        [Authorize]
        [HttpGet]
        public IActionResult AddPost()
        {
            return View(new NewPostVm());
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostVm model)
        {

            var userId = _userManager.GetUserId(User);
            model.UserId = userId;

            if (model.ImageContent != null && model.ImageContent.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.ImageContent.CopyToAsync(memoryStream);
                    model.Image = memoryStream.ToArray();
                }
            }

            var id = _postService.AddPost(model);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var model = _postService.GetPostDetail(id);
            return View(model);
        }
    }
}
