using DTO.Entity;
using System.Threading.Tasks;

namespace DTO.Service
{
    public interface IAudiFileDTOService
    {
        Task AddAudiFile(AudioFileDTO audioFileDTO);
        Task<AudioFileDTO> Get(int id);
        Task<int> GetMaxAudioFileId();
    }
}