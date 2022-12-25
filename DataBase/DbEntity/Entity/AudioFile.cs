using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.DbEntity.Entity
{
    public class AudioFile
    {
      
        public int AudioFileId { get; set; }

        public string SongName { get; set; }
        public string Path { get; set; }


        public ICollection<AudioFileSinger> AudioFileSingers { get; set; } = new List<AudioFileSinger>();
        public ICollection<AudioFileTag> AudioFileTags { get; set; } = new List<AudioFileTag>();

    }
}
