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
    public class TagRepository : IRepository<Tag>
    {
        private DataContext _dataContext;
        
        public TagRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;    
        }
        public async Task Add(Tag tag)
        {
            _dataContext.Add(tag);
           await _dataContext.SaveChangesAsync();
        }

        public async Task<Tag> Get(int id)
        {
            var tag = await _dataContext.Tags.FirstOrDefaultAsync(q => q.TagId == id);
            return tag;
        }

        public async Task<List<Tag>> GetAll()
        {
            return await _dataContext.Tags.ToListAsync();
            
        }

        public async Task Update(Tag tag)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            var tag = _dataContext.Tags.FirstOrDefault(q => q.TagId == id);
             _dataContext.Tags.Remove(tag);
            await _dataContext.SaveChangesAsync();

        }

     

        public Task SearchByTag(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetSingleTagWhere(int id)
        {
            throw new NotImplementedException();
        }
    }
}
