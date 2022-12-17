using DataBase.DbEntity.Entity;
using DataBase.MyDbContext;
using DataBase.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<AudioFile> Get(int id)
        {
            return _dataContext.AudioFiles.Include(q=>q.Tag).Include(q=>q.Singer).FirstOrDefaultAsync(q=>q.AudioFileId == id);
        }

        public Task<List<AudioFile>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetSingleTagWhere(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
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
