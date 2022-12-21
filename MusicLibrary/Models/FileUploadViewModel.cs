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

        public int[] TagId { get; set; }
        public List<SelectListItem> Tags { get; set; }

        public int[] SingerId { get; set; }
        public List<SelectListItem> Singers { get; set; }

    }
}
