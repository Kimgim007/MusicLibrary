using DataBase.DbEntity.Entity;
using DataBase.Repository;
using DataBase.Repository.IRepository;
using DTO.Entity;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Service
{
    public class SingerDTOService : ISingerDTOService
	{
		private IRepository<Singer> _singerRepository { get; set; }
		public SingerDTOService(IRepository<Singer> singerRepository)
		{
			this._singerRepository = singerRepository;
		}

		public async Task AddSinger(SingerDTO extractorDTO)
		{
			await _singerRepository.Add(DTO.Service.Maping.Maping.map(extractorDTO));
		}
		public async Task<List<SingerDTO>> GetSingers()
		{
			var singers = await _singerRepository.GetAll();
			return singers.Select(s => DTO.Service.Maping.Maping.map(s, false)).ToList();

		}

		public async  Task<SingerDTO> GetSinger(int id)
        {
			var singer = await _singerRepository.Get(id);
			var singerSort = DTO.Service.Maping.Maping.map(singer, true);
			return singerSort;
        }

		public async Task UpdateSinger(SingerDTO singerDTO)
		{
			await _singerRepository.Update(DTO.Service.Maping.Maping.map(singerDTO));
		}

		public async Task RemoveSinger(int id)
        {
			await _singerRepository.Remove(id);
        }
	}
}
