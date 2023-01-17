using DTO.Interface;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MusicLibrary.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITagDTOService _tagDTOService;
        private readonly List<ClaimsIdentity> _identities = new List<ClaimsIdentity>();

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

        public virtual bool IsInRole(string role)
        {
            for (int i = 0; i < _identities.Count; i++)
            {
                if (_identities[i] != null)
                {
                    if (_identities[i].HasClaim(_identities[i].RoleClaimType, role))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}