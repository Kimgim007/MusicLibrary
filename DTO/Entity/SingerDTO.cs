using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class SingerDTO
    {
        public SingerDTO() { }
        public SingerDTO(string NickName,string FirstName,string LastName, DateTime BirthDay,string? Photo)
        {
            this.Nickname = NickName;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDay = BirthDay;
            this.PhotoSinger = Photo;
        }

        public int SingerId { get; set; }

        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

        public string? PhotoSinger { get; set; }

        public List<SingerTagDTO> SingerTags { get; set; }

        public List<AudioFileDTO> AudioFiles { get; set; }

        public int Age()
        {
            int age = DateTime.Now.Year - BirthDay.Year;
            if (DateTime.Now.Month < BirthDay.Month)
            {
                age--;
            }
            if (DateTime.Now.Month == BirthDay.Month)
            {
                if (DateTime.Now.Day < BirthDay.Day)
                {
                    age--;
                }
            }
            return age;
        }
    }
}
