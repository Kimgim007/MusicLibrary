using DTO.Entity;
using DTO.Service;

using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Models;
using System.Threading.Tasks;

namespace MusicLibrary.Controllers
{
	public class TagController: Controller
	{
		ITagDTOService _tagDTOService;

		public TagController(ITagDTOService tagDTOService)
		{
			this._tagDTOService = tagDTOService;
		}

        [HttpGet]
        public async Task<IActionResult> AddTag()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTag(TagViewModel tagViewModel)
        {
            TagDTO tagDTO = new TagDTO()
            {
                TagName = tagViewModel.TagName,
            };
            await _tagDTOService.AddTag(tagDTO);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> GetTags()
        {
            var singers = await _tagDTOService.GetTags();
            return View(singers);
        }

        public async Task<IActionResult> RemoveTag(int id)
        {
            await _tagDTOService.RemoveTag(id);
            return RedirectToAction("GetTags", "Tag");
        }
    }
}
