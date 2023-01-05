using DataBase.DbEntity.Entity;
using DTO.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DTO.Service
{
	public interface ITagDTOService
	{
		Task AddTag(TagDTO tagDTO);
		Task<List<TagDTO>> GetTags();
		Task<TagDTO> Get(int id);
        Task RemoveTag(int id);
	}
}