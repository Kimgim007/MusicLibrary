using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity.Entity
{
    public class AudioFileTag
    {

        public int AudioFileTagId { get; set; }

        public int AudioFileId { get; set; }
        public AudioFile AudioFile { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

    }
}
