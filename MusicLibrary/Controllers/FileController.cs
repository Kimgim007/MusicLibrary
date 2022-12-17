using DTO.Entity;
using DTO.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLibrary.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Controllers
{
    public class FileController : Controller
    {
        private ISingerDTOService _singerDTOService;
        private ITagDTOService _tagDTOService;
        private IAudiFileDTOService _audiFileDTOService;
        public FileController(ISingerDTOService singerDTOService,ITagDTOService tagDTOService, IAudiFileDTOService audiFileDTOService)
        {
            this._singerDTOService = singerDTOService;
            this._tagDTOService = tagDTOService;
            this._audiFileDTOService = audiFileDTOService;
        }

        [HttpGet]
        public async Task<IActionResult> UploadFile()
        {
            FileUploadViewModel fileUploadViewModel;

            var singers = await _singerDTOService.GetSingers();
            var tags = await _tagDTOService.GetTags();

            var selectListItemSingers = singers.Select(x => new SelectListItem() { Text = x.Nickname, Value = x.SingerId.ToString() });
            var selectListItemTag = tags.Select(x => new SelectListItem() { Text = x.TagName, Value = x.TagId.ToString() });

            fileUploadViewModel = new FileUploadViewModel()
            {

                Singers = selectListItemSingers.ToList(),
                Tags = selectListItemTag.ToList(),
            };

            return View(fileUploadViewModel);
        }
        [HttpPost]
        public async Task<bool> UploadFile(IFormFile file,FileUploadViewModel fileUploadViewModel)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"wwwroot\Audio"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }


                    SingerDTO singerDTO = new SingerDTO()
                    {
                        SingerId = fileUploadViewModel.SingerId
                    };
                    TagDTO tagDTO = new TagDTO()
                    {
                        TagId = fileUploadViewModel.TagId,
                    };

                    AudioFileDTO audioFileDTO = new AudioFileDTO(file.FileName, $"Audio/{file.FileName}");
                                                  
                    audioFileDTO.TagDTO = tagDTO;
                    audioFileDTO.SingerDTO = singerDTO;

                    await _audiFileDTOService.AddAudiFile(audioFileDTO);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }

        
       
    }
}
