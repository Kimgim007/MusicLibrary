using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class SingerDTO
    {
        public SingerDTO() { }
        public SingerDTO(string NickName,string? Photo)
        {
            this.Nickname = NickName;      
            this.PhotoSinger = Photo;
        }

        public int SingerId { get; set; }

        public string Nickname { get; set; }
       
        public string? PhotoSinger { get; set; }

        public List<SingerTagDTO> SingerTags { get; set; }

        public List<AudioFileSingerDTO> AudioFileSingerDTO { get; set; }

        public List<AudioFileDTO> AudioFileDTO { get; set; }
    
    }
}
