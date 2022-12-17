using DTO.Entity;
using DTO.Service;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Controllers
{

    public class SingerTagController:Controller
    {
        private ISingerTagDTOService _singerTagDTOService;
        private ITagDTOService _tagDTOService;

        public SingerTagController(ISingerTagDTOService singerTagDTOService, ITagDTOService tagDTOService)
        {
            this._singerTagDTOService = singerTagDTOService;
            this._tagDTOService = tagDTOService;
        }

        [HttpGet]
        public async Task<IActionResult> AddTagUser(int SingerId)
        {
            var tags = await _tagDTOService.GetTags();

            var ATagsSinger = await _singerTagDTOService.GetSingleTagWhere(SingerId);

            var result = tags.Except(ATagsSinger.Select(t=>t.TagDTO));
           
          
            
            var selectListItemTag = result.Select(x=>new SelectListItem() { Text = x.TagName, Value = x.TagId.ToString() });

            SingerTagViewModel singerTagViewModel = new SingerTagViewModel()
            {
                SingerId = SingerId,
                Tags = selectListItemTag.ToList()
            };

            return View(singerTagViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddTagUser(SingerTagViewModel singerTagViewModel)
        {
            SingerDTO singer = new SingerDTO() { SingerId = singerTagViewModel.SingerId};
            TagDTO tag = new TagDTO() { TagId = singerTagViewModel.TagId};

            SingerTagDTO singerTagDTO = new SingerTagDTO(singer, tag);
            await _singerTagDTOService.Add_Tag_User(singerTagDTO);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> GetTagUser()
        {
            var userTags = await _singerTagDTOService.GetSingleTags();
            return View(userTags);
        }

        
        public async Task<IActionResult> SearchByTag(int id)
        {
            var singerTags = await _singerTagDTOService.SearchByTag(id);
            return View(singerTags);
        }
    }
}
