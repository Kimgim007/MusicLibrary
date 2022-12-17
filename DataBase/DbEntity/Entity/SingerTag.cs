using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity.Entity
{
    public class SingerTag 
    {
        public int SingerTagId { get; set; }

        public int SingerId { get; set; }
        public Singer Singer { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

        
    }
}
