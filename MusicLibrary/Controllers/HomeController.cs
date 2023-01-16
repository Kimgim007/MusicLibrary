using DTO.Interface;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MusicLibrary.Constants;

namespace MusicLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITagDTOService _tagDTOService;
        public HomeController(ILogger<HomeController> logger, ITagDTOService _tagDTOService)
        {
            _logger = logger;
            this._tagDTOService = _tagDTOService;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await _tagDTOService.GetTags();
           ViewBag.tags = tags;
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

        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
    }
}