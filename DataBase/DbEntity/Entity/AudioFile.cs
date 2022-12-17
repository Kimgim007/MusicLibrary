using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.DbEntity.Entity
{
    public class AudioFile
    {
        public int AudioFileId { get; set; }

        public string SongName { get; set; }
        public string Path { get; set; }


        public int SingerId { get; set; }
        public virtual Singer Singer { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

    }
}
