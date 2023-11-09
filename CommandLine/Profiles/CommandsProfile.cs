using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandLine.Dtos;
using CommandLine.Models;

namespace CommandLine.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<CommandCreatedDto, Command>();

            CreateMap<CommandUpdatedDto, Command>();

            CreateMap<Command, CommandReadDto>();
        }
    }
}
