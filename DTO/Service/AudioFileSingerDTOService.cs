using DataBase.Repository;
using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Service
{
    public class AudioFileSingerDTOService : IAudioFileSingerDTOService
    {

        private AudioFileSingerRepository _audioFileSingerRepository;

        public AudioFileSingerDTOService(AudioFileSingerRepository audioFileSingerRepository)
        {
            this._audioFileSingerRepository = audioFileSingerRepository;
        }

        public async Task Add(AudioFileSingerDTO audioFileSingerDTO)
        {
            await _audioFileSingerRepository.Add(DTO.Service.Maping.Maping.map(audioFileSingerDTO));
        }

    }
}
