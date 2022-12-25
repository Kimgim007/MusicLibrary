using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class SingerTagDTO
    {

        public SingerTagDTO() { }
        public SingerTagDTO(SingerDTO singerDTO,TagDTO tagDTO)
        {
            this.SingerDTO = singerDTO;
            this.TagDTO = tagDTO;
        }

        public int SingerTagId { get; set; }

        public string SingerTagName { get; set;}// Разобраться 

        public SingerDTO SingerDTO { get; set; }
        public TagDTO TagDTO { get; set; }
    }
}
