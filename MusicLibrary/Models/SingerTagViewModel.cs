
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MusicLibrary.Models
{
    public class SingerTagViewModel
    {
        public int SingerTagId { get; set; }

        public int SingerId { get; set; }

        public int TagId { get; set; }

        public List<SelectListItem> Tags { get; set; }   

    }
}
