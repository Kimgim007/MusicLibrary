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
    public class SingerTagRepository : IRepository<SingerTag>
    {
        private DataContext _dataContext;
        public SingerTagRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task Add(SingerTag singerTag)
        {
          await _dataContext.AddAsync(singerTag);
            _dataContext.SaveChanges();
        }

        public Task<SingerTag> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SingerTag>> GetAll()
        {
            return await _dataContext.SingerTags.Include(q=>q.Singer).Include(q=>q.Tag).ToListAsync();
        }

        public async Task<List<SingerTag>> GetSingleTagWhere(int id)
        {
            return await _dataContext.SingerTags.Include(q => q.Singer).Include(q => q.Tag).Where(q=>q.SingerId == id).ToListAsync();
        }

        public Task Update(SingerTag obj)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SingerTag>> SearchByTag(int id)
		{
            var singerTags = await _dataContext.SingerTags.Include(q => q.Singer).Include(q => q.Tag).Where(q=>q.TagId == id).ToListAsync();
            return  singerTags;
		}

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<SingerTag>.SearchByTag(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<SingerTag>.GetSingleTagWhere(int id)
        {
            throw new NotImplementedException();
        }
    }
}
