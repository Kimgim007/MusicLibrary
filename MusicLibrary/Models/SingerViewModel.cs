using DTO.Entity;
using System;
using System.Collections.Generic;

namespace MusicLibrary.Models
{
    public class SingerViewModel
    {

        public int SingerViewModelId { get; set; }
        public string NickName { get; set; }

       
        public string? PhotoSinger { get; set; }

        List<AudioFileDTO> AudioFiles { get; set; }
        

    }
}
