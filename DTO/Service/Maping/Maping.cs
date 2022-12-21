using DataBase.DbEntity.Entity;
using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Service.Maping
{
    public static class Maping
    {

        public static Singer map(SingerDTO executorDTO)
        {
            return new Singer()
            {
                SingerId = executorDTO.SingerId,
                Nickname = executorDTO.Nickname,
                FirstName = executorDTO.FirstName,
                LastName = executorDTO.LastName,
                BirthDay = executorDTO.BirthDay,
                PhotoSinger = executorDTO.PhotoSinger,
             
            };
        }
        public static SingerDTO map(Singer executor, bool stackOwerFlow)
        {

            List<AudioFileDTO> files;

            if(stackOwerFlow)
            {
                files = executor.AudioFiles.Select(q => map(q)).ToList();
            }
            else
            {
                files = executor.AudioFiles.Select(q => new AudioFileDTO() { Id = q.AudioFileId }).ToList();
            }

            return new SingerDTO()
            {
                SingerId = executor.SingerId,
                Nickname = executor.Nickname,
                FirstName = executor.FirstName,
                LastName = executor.LastName,
                BirthDay = executor.BirthDay,
                PhotoSinger = executor.PhotoSinger,
                AudioFiles = files
            };
        }

        public static Tag map(TagDTO tagDTO)
        {
            return new Tag()
            {
                TagName = tagDTO.TagName,
            };
        }
        public static TagDTO map(Tag tag)
        {
            return new TagDTO()
            {
                TagId = tag.TagId,
                TagName = tag.TagName,

            };
        }

        public static SingerTag map(SingerTagDTO singerTagDTO)
        {
            return new SingerTag()
            {
                SingerId = singerTagDTO.SingerDTO.SingerId,
                TagId = singerTagDTO.TagDTO.TagId
            };
        }
        public static SingerTagDTO map(SingerTag singerTag)
        {
            return new SingerTagDTO()
            {
                SingerTagId = singerTag.SingerTagId,
                SingerDTO = map(singerTag.Singer,false),
                TagDTO = map(singerTag.Tag)
            };
        }

        public static AudioFile map(AudioFileDTO audioFileDTO)
        {
            List<Singer> singers = audioFileDTO.SingerDTO.Select(q => new Singer() { SingerId = q.SingerId }).ToList();
            List<Tag> tags = audioFileDTO.TagsDTO.Select(t => new Tag() { TagId = t.TagId, }).ToList();

            //AudioFile audioFile = new AudioFile();

            //audioFile.AudioFileId = audioFileDTO.Id; 

            //audioFile.SongName= audioFileDTO.SongName;
            //audioFile.Path = audioFileDTO.FilePath;
            //audioFile.Tags = tags;
            //audioFile.Singers = singers;

            //return audioFile;

            return new AudioFile()
            {
                AudioFileId = audioFileDTO.Id,

                SongName = audioFileDTO.SongName,
                Path = audioFileDTO.FilePath,

                Singers= singers,
                Tags= tags
            };
        }
        public static AudioFileDTO map(AudioFile audioFile)
        {          
            return new AudioFileDTO()
            {
                Id = audioFile.AudioFileId,

                SongName = audioFile.SongName,
                FilePath = audioFile.Path,

                SingerDTO = audioFile.Singers.Select(q => map(q,false)).ToList(),
                TagsDTO = audioFile.Tags.Select(q => map(q)).ToList()
            };
        }
    }
}
