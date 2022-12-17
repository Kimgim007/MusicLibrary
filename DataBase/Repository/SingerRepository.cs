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
    public class SingerRepository : IRepository<Singer>
    {
        private DataContext _dataContext;
        public SingerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(Singer executor)
        {
            _dataContext.Add(executor);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<Singer> Get(int id)
        {
            var executor = await _dataContext.Singers.Include(q=>q.AudioFiles).Include(q=>q.AudioFiles).FirstOrDefaultAsync(q=>q.SingerId == id);
            return  executor;

        }

        public async Task<List<Singer>> GetAll()
        {
            return await _dataContext.Singers.Include(q=>q.SingerTags).ToListAsync();
            
        }

        public async Task Update(Singer singer)
        {
           var singerInDatabase = await _dataContext.Singers.FirstOrDefaultAsync(q=>q.SingerId == singer.SingerId);

            if(singerInDatabase != null)
			{
                singerInDatabase.Nickname = singer.Nickname;
                singerInDatabase.FirstName = singer.FirstName;
                singerInDatabase.LastName = singer.LastName;
                singerInDatabase.BirthDay = singer.BirthDay;
                singerInDatabase.PhotoSinger = singer.PhotoSinger;
                await _dataContext.SaveChangesAsync();
            }

        }

        public async Task Remove(int id)
        {
            var singer = await _dataContext.Singers.FirstOrDefaultAsync(q=>q.SingerId == id);
            if(singer != null)
            {
                _dataContext.Singers.Remove(singer);
                _dataContext.SaveChanges();
            }
          
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
