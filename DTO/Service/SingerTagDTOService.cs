using DataBase.DbEntity.Entity;
using DataBase.Repository;
using DataBase.Repository.IRepository;
using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Service
{
    public class SingerTagDTOService : ISingerTagDTOService
    {

        private SingerTagRepository _singerTagRepository;
        public SingerTagDTOService(SingerTagRepository singerTagRepository)
        {
            this._singerTagRepository = singerTagRepository;
        }

        public async Task Add_Tag_User(SingerTagDTO singerTagDTO)
        {
            await _singerTagRepository.Add(DTO.Service.Maping.Maping.map(singerTagDTO));
        }

        public async Task<List<SingerTagDTO>> GetSingleTags()
        {
            var singleTags = await _singerTagRepository.GetAll();

            return singleTags.Select(q=>DTO.Service.Maping.Maping.map(q)).ToList();
        }

        public async Task<List<SingerTagDTO>> GetSingleTagWhere(int id)
        {
            var singleTags = await _singerTagRepository.GetSingleTagWhere(id);
            return singleTags.Select(q => DTO.Service.Maping.Maping.map(q)).ToList();
        }
        public async Task<List<SingerTagDTO>> SearchByTag(int id)
        {
            var singerTags = await _singerTagRepository.SearchByTag(id);
            return singerTags.Select(q => DTO.Service.Maping.Maping.map(q)).ToList();
        }
    }
}
