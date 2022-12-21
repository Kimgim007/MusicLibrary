using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.DbEntity.Entity
{
    public class AudioFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AudioFileId { get; set; }

        public string SongName { get; set; }
        public string Path { get; set; }


        public ICollection<Singer> Singers { get; set; } = new List<Singer>();
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    }
}
