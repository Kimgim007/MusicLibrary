using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity.Entity
{
    public class AudioFileSinger
    {
        public int AudioFileSingerId { get; set; }

        public int AudioFileId { get; set; }
        public AudioFile AudioFile { get; set; }

        public int SingerId { get; set; }
        public Singer Singer { get; set; }
    }
}
