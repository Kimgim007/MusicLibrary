using DTO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DTO.Service
{
    public interface ISingerTagDTOService
    {
        Task Add_Tag_User(SingerTagDTO singerTagDTO);
        Task<List<SingerTagDTO>> GetSingleTags();
        Task<List<SingerTagDTO>> GetSingleTagWhere(int id);
        Task<List<SingerTagDTO>> SearchByTag(int id);
    }
}