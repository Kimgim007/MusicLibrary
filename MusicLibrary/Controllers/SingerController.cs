using DTO.Entity;
using DTO.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MusicLibrary.Controllers
{
    public class SingerController : Controller
    {

        private ISingerDTOService _singerDTOService;
        private ISingerTagDTOService _singerTagDTOService;
        private IAudiFileDTOService _audiFileDTOService;
        private ITagDTOService _tagDTOService;

        public SingerController(ISingerDTOService singerDTOService, ISingerTagDTOService singerTagDTOService, IAudiFileDTOService audiFileDTOService, ITagDTOService tagDTOService)
        {
            this._singerDTOService = singerDTOService;
            this._singerTagDTOService = singerTagDTOService;
            this._audiFileDTOService = audiFileDTOService;
            this._tagDTOService = tagDTOService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddSinger(int id)
        {
            SingerViewModel singerViewModel;

            var tags = await _tagDTOService.GetTags();
            ViewBag.tags = tags;

            if (id == 0)
            {
                singerViewModel = new SingerViewModel()
                {
                   
                };
            }
            else
            {
                var singer = await _singerDTOService.GetSinger(id);

                singerViewModel = new SingerViewModel()
                {
                    SingerViewModelId = singer.SingerId,
                    NickName = singer.Nickname,
                   

                    PhotoSinger = singer.PhotoSinger,
                };
            }

            return View(singerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddSinger(SingerViewModel singerViewModel)
        {
            SingerDTO singerDTO = new SingerDTO(singerViewModel.NickName, singerViewModel.PhotoSinger);
            if (singerViewModel.SingerViewModelId == 0)
            {
                await _singerDTOService.AddSinger(singerDTO);

            }
            else
            {
                singerDTO.SingerId = singerViewModel.SingerViewModelId;
                await _singerDTOService.UpdateSinger(singerDTO);
            }


            return RedirectToAction("GetSingers", "Singer");
        }

        public async Task<IActionResult> GetSingers()
        {
            var tags = await _tagDTOService.GetTags();
            ViewBag.tags = tags;
            var singers = await _singerDTOService.GetSingers();
            return View(singers);
        }

        public async Task<IActionResult> GetSinger(int id)
        {
            var singerTag = await _singerTagDTOService.GetSingleTagWhere(id);  
            var singer = await _singerDTOService.GetSinger(id);

            var tags = await _tagDTOService.GetTags();
            ViewBag.tags = tags;

            List<AudioFileDTO> audioFiles = new List<AudioFileDTO>();
            if (singer.AudioFileSingerDTO != null)
            {
                foreach (var item in singer.AudioFileSingerDTO)
                {
                    AudioFileDTO audioFile = await _audiFileDTOService.Get(item.AudioFileDTO.Id);
                    audioFiles.Add(audioFile);
                }
            }

            singer.AudioFileDTO = audioFiles;
            singer.SingerTags = singerTag;
            return View(singer);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveSinger(int id)
        {
            await _singerDTOService.RemoveSinger(id);

            return RedirectToAction("GetSingers", "Singer");
        }

    }
}
