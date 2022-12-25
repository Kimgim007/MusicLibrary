using DTO.Entity;

namespace DTO.Service
{
    public interface IAudioFileSingerDTOService
    {
        Task Add(AudioFileSingerDTO audioFileSingerDTO);
    }
}