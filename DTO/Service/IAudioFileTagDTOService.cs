using DTO.Entity;

namespace DTO.Service
{
    public interface IAudioFileTagDTOService
    {
        Task Add(AudioFileTagDTO audioFileTagDTO);
        Task<List<AudioFileTagDTO>> AudioFileByTag(int id);
    }
}