using DataBase.Repository;
using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO.Service.Maping;
using DataBase.Repository.IRepository;

namespace DTO.Service
{
    public class AudioFileDTOService : IAudiFileDTOService
    {

        private AudioFileRepository _audioFileRepository;

        public AudioFileDTOService(AudioFileRepository audioFileRepository)
        {
            this._audioFileRepository = audioFileRepository;
        }

        public async Task AddAudiFile(AudioFileDTO audioFileDTO)
        {
            await _audioFileRepository.Add(DTO.Service.Maping.Maping.map(audioFileDTO));
        }

        public async Task<AudioFileDTO> Get(int id)
        {
            var audiofile = await _audioFileRepository.Get(id);
            var audioFileSort = DTO.Service.Maping.Maping.map(audiofile);
            return audioFileSort;
        }

        public async Task<int> GetMaxAudioFileId()
        {

            return await _audioFileRepository.GetMaxIdAudioFile();
        }
    }
}
