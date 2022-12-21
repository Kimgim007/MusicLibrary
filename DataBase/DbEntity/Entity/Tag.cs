﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity.Entity
{
    public class Tag 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<SingerTag> SingerTags { get; set; } = new List<SingerTag>();
        public virtual ICollection<AudioFile> AudioFiles { get; set; } = new List<AudioFile>();
    }
}
