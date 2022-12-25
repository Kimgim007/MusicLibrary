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
    public class AudioFileSingerRepository : IRepository<AudioFileSinger>
    {

        private DataContext _dataContext;

        public AudioFileSingerRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task Add(AudioFileSinger audioFileSinger)
        {
            _dataContext.AudioFileSingers.Add(audioFileSinger);
           await _dataContext.SaveChangesAsync();
        }

        public Task<AudioFileSinger> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AudioFileSinger>> GetAll()
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

        public Task Update(AudioFileSinger obj)
        {
            throw new NotImplementedException();
        }
    }
}
