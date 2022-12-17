using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class TagDTO
    {
        public TagDTO() { }
        public TagDTO(string TagName)
        {
            this.TagName = TagName;
        }

        public int TagId { get; set; }
        public string TagName { get; set; }

        public List<SingerTagDTO> ExecutorTags { get; set; }
        public List<AudioFileDTO> AudioFiles { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is TagDTO tagDTO) return TagId == tagDTO.TagId;
            return false;
        }
        public override int GetHashCode() => TagId.GetHashCode();
    }
}
