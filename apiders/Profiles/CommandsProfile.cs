using apiders.Models;
using AutoMapper;
using apiders.DTOS;

namespace apiders.Profiles
{
    public class CommandsProfile:Profile
    {
        public CommandsProfile()
        {
            CreateMap<Commad, CommadReadDto>();
            CreateMap<CommadCreateDto, Commad>();
            CreateMap<CommadUpdataDto, Commad>();
        }
    }
}
