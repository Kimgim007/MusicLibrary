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
	public class TagDTOService : ITagDTOService
	{
		private IRepository<Tag> _tagRepository { get; set; }
		public TagDTOService(IRepository<Tag> tagRepository)
		{
			this._tagRepository = tagRepository;
		}

		public async Task AddTag(TagDTO tagDTO)
		{
			await _tagRepository.Add(DTO.Service.Maping.Maping.map(tagDTO));
		}
		public async Task<List<TagDTO>> GetTags()
		{
			var singers = await _tagRepository.GetAll();
			return singers.Select(s => DTO.Service.Maping.Maping.map(s)).ToList();

		}

		public async Task RemoveTag(int id)
        {
			await _tagRepository.Remove(id);
        }
	}
}
