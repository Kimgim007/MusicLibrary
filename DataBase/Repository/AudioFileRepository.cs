using DataBase.DbEntity.Entity;
using DataBase.MyDbContext;
using DataBase.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class AudioFileRepository : IRepository<AudioFile>
    {
        private DataContext _dataContext;

        public AudioFileRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task Add(AudioFile audioFile)
        {
          
            _dataContext.AudioFiles.Add(audioFile);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<AudioFile> Get(int id)
        {
            return await _dataContext.AudioFiles.FirstOrDefaultAsync(q => q.AudioFileId == id);
        }

        public async Task<int> GetMaxIdAudioFile()
        {
            var MaxAudioFileId = await _dataContext.AudioFiles.MaxAsync(q => q.AudioFileId);
            return MaxAudioFileId;
        }

       

        public Task<List<AudioFile>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetSingleTagWhere(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            var audioFile = await _dataContext.AudioFiles.FirstOrDefaultAsync(q=>q.AudioFileId == id);
            if (audioFile != null)
            {
                _dataContext.AudioFiles.Remove(audioFile);
                _dataContext.SaveChanges();
            }
        }

        public Task SearchByTag(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(AudioFile obj)
        {
            throw new NotImplementedException();
        }
    }
}
