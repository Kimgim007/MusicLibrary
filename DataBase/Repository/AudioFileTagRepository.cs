using DataBase.DbEntity.Entity;
using DataBase.MyDbContext;
using DataBase.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class AudioFileTagRepository : IRepository<AudioFileTag>
    {
        private DataContext _dataContext;

        public AudioFileTagRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task Add(AudioFileTag audioFileTag)
        {
            _dataContext.AudioFileTags.Add(audioFileTag);
            await _dataContext.SaveChangesAsync();
        }

        public Task<AudioFileTag> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AudioFileTag>> GetAll()
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

        public Task Update(AudioFileTag obj)
        {
            throw new NotImplementedException();
        }
    }
}
