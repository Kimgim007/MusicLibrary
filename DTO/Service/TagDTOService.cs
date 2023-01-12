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
			var tags = await _tagRepository.GetAll();
			return tags.Select(s => DTO.Service.Maping.Maping.map(s)).ToList();

		}
		public async Task<TagDTO> Get(int id)
		{
			var tag = await _tagRepository.Get(id);
			return DTO.Service.Maping.Maping.map(tag);
		}
		public async Task RemoveTag(int id)
        {
			await _tagRepository.Remove(id);
        }
	}
}
