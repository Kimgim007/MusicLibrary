using DataBase.DbEntity.Entity;
using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

            List<AudioFileSingerDTO> files;

            if (stackOwerFlow)
            {
                files = executor.AudioFileSinger.Select(q => map(q)).ToList();
            }
            else
            {
                files = executor.AudioFileSinger.Select(q => new AudioFileSingerDTO() { AudioFileSingerDTOId = q.AudioFileSingerId}).ToList();
            }

            return new SingerDTO()
            {
                SingerId = executor.SingerId,
                Nickname = executor.Nickname,
                FirstName = executor.FirstName,
                LastName = executor.LastName,
                BirthDay = executor.BirthDay,
                PhotoSinger = executor.PhotoSinger,
                AudioFileSingerDTO = files
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
                SingerDTO = map(singerTag.Singer, false),
                TagDTO = map(singerTag.Tag)
            };
        }

        public static AudioFile map(AudioFileDTO audioFileDTO)
        {

            return new AudioFile()
            {
                AudioFileId = audioFileDTO.Id,

                SongName = audioFileDTO.SongName,
                Path = audioFileDTO.FilePath,

            };
        }
        public static AudioFileDTO map(AudioFile audioFile)
        {
            return new AudioFileDTO()
            {
                Id = audioFile.AudioFileId,

                SongName = audioFile.SongName,
                FilePath = audioFile.Path,

            };
        }

        public static AudioFileSinger map(AudioFileSingerDTO audioFileSingerDTO)
        {
            return new AudioFileSinger()
            {
                AudioFileId = audioFileSingerDTO.AudioFileDTO.Id,
                SingerId = audioFileSingerDTO.SingerDTO.SingerId

            };
        }
        public static AudioFileSingerDTO map(AudioFileSinger audioFileSinger)
        {

            return new AudioFileSingerDTO()
            {
                AudioFileSingerDTOId = audioFileSinger.AudioFileSingerId,
                SingerDTO = new SingerDTO() { SingerId = audioFileSinger.SingerId },
                AudioFileDTO = new AudioFileDTO() { Id = audioFileSinger.AudioFileId}
            };
        }


        public static AudioFileTag map(AudioFileTagDTO audioFileTagDTO)
        {
            return new AudioFileTag
            {
                AudioFileId = audioFileTagDTO.AudioFileDTO.Id,
                TagId = audioFileTagDTO.TagDTO.TagId
            };
        }
        public static AudioFileTagDTO map(AudioFileTag audioFileTag)
        {
            return new AudioFileTagDTO
            {
                AudioFileTagDTOId = audioFileTag.AudioFileTagId,
                TagDTO = map(audioFileTag.Tag),
                AudioFileDTO= map(audioFileTag.AudioFile)
            };
        }
    }
}
