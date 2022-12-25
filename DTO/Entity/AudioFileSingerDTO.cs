using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class AudioFileSingerDTO
    {
        public AudioFileSingerDTO() { }
        public AudioFileSingerDTO(AudioFileDTO audioFileDTO, SingerDTO singerDTO)
        {
            this.AudioFileDTO = audioFileDTO;
            this.SingerDTO = singerDTO;
        }

        public int AudioFileSingerDTOId { get; set; }

        public AudioFileDTO AudioFileDTO { get; set; }
        public SingerDTO SingerDTO { get; set; }

    }
}
