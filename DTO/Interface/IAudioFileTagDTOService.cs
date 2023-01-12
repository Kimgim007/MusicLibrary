using DTO.Entity;

namespace DTO.Interface
{
    public interface IAudioFileTagDTOService
    {
        Task Add(AudioFileTagDTO audioFileTagDTO);
        Task<List<AudioFileTagDTO>> AudioFileByTag(int id);
    }
}