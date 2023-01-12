using DataBase.DbEntity.Entity;
using DataBase.MyDbContext;
using DataBase.Repository;
using DTO.Entity;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Service
{
    public class AudioFileTagDTOService : IAudioFileTagDTOService
    {
        private AudioFileTagRepository _audioFileTagRepository;

        public AudioFileTagDTOService(AudioFileTagRepository audioFileTagRepository)
        {
            this._audioFileTagRepository = audioFileTagRepository;
        }

        public async Task Add(AudioFileTagDTO audioFileTagDTO)
        {
            await _audioFileTagRepository.Add(DTO.Service.Maping.Maping.map(audioFileTagDTO));
        }

        public async Task<List<AudioFileTagDTO>> AudioFileByTag(int id)
        {
            var audioFileTag = await _audioFileTagRepository.AudioFileByTag(id);
            return audioFileTag.Select(q=>DTO.Service.Maping.Maping.map(q)).ToList();
        }
    }
}
