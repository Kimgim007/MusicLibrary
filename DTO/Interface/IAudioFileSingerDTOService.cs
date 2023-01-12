using DTO.Entity;

namespace DTO.Interface
{
    public interface IAudioFileSingerDTOService
    {
        Task Add(AudioFileSingerDTO audioFileSingerDTO);
    }
}