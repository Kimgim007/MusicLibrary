﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Entity
{
    public class AudioFileDTO
    {
        public AudioFileDTO() { }
        public AudioFileDTO(string SongName,string FilePath)
        {
            this.SongName = SongName;
       
            this.FilePath = FilePath;
        }
        public int Id { get; set; }

        public string SongName { get; set; }   
        public string FilePath { get; set; }

      
        public virtual List<SingerDTO> SingerDTO { get; set; } = new List<SingerDTO>();
        public virtual List<TagDTO> TagsDTO { get; set; } = new List<TagDTO>();
    }
}
