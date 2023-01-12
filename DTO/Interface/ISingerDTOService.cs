using DTO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface ISingerDTOService
    {
        Task AddSinger(SingerDTO extractorDTO);
        Task<List<SingerDTO>> GetSingers();
        Task<SingerDTO> GetSinger(int id);
        Task UpdateSinger(SingerDTO singerDTO);
        Task RemoveSinger(int id);


    }
}