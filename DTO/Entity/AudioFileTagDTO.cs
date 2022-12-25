using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class AudioFileTagDTO
    {

        public AudioFileTagDTO() { }
        public AudioFileTagDTO(AudioFileDTO audioFileDTO, TagDTO tagDTO)
        {
            this.AudioFileDTO = audioFileDTO;
            this.TagDTO = tagDTO;
        }

        public int AudioFileTagDTOId { get; set; }

        public AudioFileDTO AudioFileDTO { get; set; }
        public TagDTO TagDTO { get; set; }

    }
}
