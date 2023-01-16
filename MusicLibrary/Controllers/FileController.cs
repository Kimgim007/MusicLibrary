using DTO.Entity;
using DTO.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLibrary.Models;
using NuGet.Protocol;
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
        private IAudioFileSingerDTOService _audioFileSingerDTOService;
        private IAudioFileTagDTOService _audioFileTagDTO;

        public FileController(ISingerDTOService singerDTOService,ITagDTOService tagDTOService, IAudiFileDTOService audiFileDTOService, IAudioFileSingerDTOService audioFileSingerDTOService, IAudioFileTagDTOService audioFileTagDTO)
        {
            this._singerDTOService = singerDTOService;
            this._tagDTOService = tagDTOService;
            this._audiFileDTOService = audiFileDTOService;
            this._audioFileSingerDTOService = audioFileSingerDTOService;
            this._audioFileTagDTO = audioFileTagDTO;
        }

        public async Task<IActionResult> Remove(int id)
        {
           
            AudioFileDTO audioFile = await _audiFileDTOService.Get(id);

            FileInfo fileInf = new FileInfo($"{"wwwroot/" + audioFile.FilePath}");
            if(fileInf != null)
            {
                fileInf.Delete();
            }
            await _audiFileDTOService.Remove(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> UploadFile()
        {
            FileUploadViewModel fileUploadViewModel;

            var tags = await _tagDTOService.GetTags();
            ViewBag.tags = tags;

            var singers = await _singerDTOService.GetSingers();
            var Tags = await _tagDTOService.GetTags();
        
            fileUploadViewModel = new FileUploadViewModel()
            {
                Singers = singers,
                Tags = Tags,
            
            };

            return View(fileUploadViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file, int[] SingerId, int[] TagId)
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
                              
					AudioFileDTO audioFileDTO = new AudioFileDTO(file.FileName, $"Audio/{file.FileName}");                                                    
                    await _audiFileDTOService.AddAudiFile(audioFileDTO);

                    int maxAudioFileId = await _audiFileDTOService.GetMaxAudioFileId();
                  
                    foreach (var item in SingerId)
                    {              
                        await _audioFileSingerDTOService.Add(new AudioFileSingerDTO(new AudioFileDTO() { Id = maxAudioFileId }, new SingerDTO() { SingerId = item }));
                    }
                 
                    foreach (var item in TagId)
                    {
                        await _audioFileTagDTO.Add(new AudioFileTagDTO(new AudioFileDTO() { Id = maxAudioFileId }, new TagDTO() { TagId = item }));                
                    }
                 
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    throw new Exception("File Copy Failed");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }    
        
       
    }
}
