using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity.Entity
{
    public class Singer
    {
   
        public int SingerId { get; set; }


        public string Nickname { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

        public string? PhotoSinger { get; set; }

        public virtual ICollection<SingerTag> SingerTags { get; set; } = new List<SingerTag>();
        public virtual ICollection<AudioFileSinger> AudioFileSinger { get; set; } = new List<AudioFileSinger>();

    }
}
