using DTO.Entity;
using DTO.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Models;
using System.Threading.Tasks;

namespace MusicLibrary.Controllers
{
    public class TagController : Controller
    {
        private ITagDTOService _tagDTOService;
        private IAudioFileTagDTOService _audioFileTagDTOService;
        private IAudiFileDTOService _audiFileDTOService;

        public TagController(ITagDTOService tagDTOService, IAudioFileTagDTOService audioFileTagDTOService, IAudiFileDTOService audiFileDTOService)
        {
            this._tagDTOService = tagDTOService;
            this._audioFileTagDTOService = audioFileTagDTOService;
            this._audiFileDTOService = audiFileDTOService;
        }

        [HttpGet]
        public async Task<IActionResult> AddTag()
        {
            var tags = await _tagDTOService.GetTags();
            ViewBag.tags = tags;

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

        public async Task<IActionResult> GetTag(int id)
        {
			var tags = await _tagDTOService.GetTags();
			ViewBag.tags = tags;

            var tag = await _tagDTOService.Get(id);

            var audioFileByTag = await _audioFileTagDTOService.AudioFileByTag(id);
            foreach(var item in audioFileByTag)
            {
                AudioFileDTO audioFile = await _audiFileDTOService.Get(item.AudioFileDTO.Id);
                tag.AudioFilesDTO.Add( audioFile);
            }

		
            return View(tag);
        }

        public async Task<IActionResult> GetTags()
        {
            var tags = await _tagDTOService.GetTags();

            ViewBag.tags = tags;

            return View(tags);
        }

        public async Task<List<TagDTO>> GetListTagsDTO()
        {
            var tags = await _tagDTOService.GetTags();
            return tags;
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RemoveTag(int id)
        {
            await _tagDTOService.RemoveTag(id);
            return RedirectToAction("GetTags", "Tag");
        }
    }
}
