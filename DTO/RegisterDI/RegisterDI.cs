using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.RegisterDI;
using DataBase.DbEntity.Entity;
using DataBase.MyDbContext;
using DTO.Service;
using DataBase.Repository;
using DataBase.Repository.IRepository;

namespace DTO.RegisterDI
{
    public static class RegisterDI
    {
        public static void Register(IServiceCollection service)
        {
            DataBase.RegisterDI.RegisterDI.Register(service);

            service.AddScoped<IRepository<Singer> ,SingerRepository >();
            service.AddScoped<IRepository<Tag> ,TagRepository > ();
            service.AddScoped<SingerTagRepository > ();
            service.AddScoped<AudioFileRepository > ();

        }
    }
}
