using DTO.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicLibrary.Models
{
    public class FileUploadViewModel
    {

        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FilePass { get; set; }
      
        public List<TagDTO> Tags { get; set; }
     
        public List<SingerDTO> Singers { get; set; }

    }
}
