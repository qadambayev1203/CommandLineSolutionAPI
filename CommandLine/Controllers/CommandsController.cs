using AutoMapper;
using CommandLine.Data;
using CommandLine.Dtos;
using CommandLine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandLine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _repository;

        private readonly IMapper _mapper;

        public CommandsController(ICommandAPIRepo repository, IMapper mapper)
        {
            _repository = repository;

            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommand(CommandCreatedDto commandCreatedDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreatedDto);

            await _repository.CreateCommand(commandModel);

            await _repository.SaveChangesAsync();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return Created("", commandReadDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetCommands()
        {
            var commands = await _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommandById(int id)
        {
            var command = await _repository.GetCommandById(id);

            if (command == null)
            {
                return NotFound();
            }
           
            return Ok(_mapper.Map<CommandReadDto>(command));
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommand(int id)
        {
            var commandModelFromRepo = await _repository.GetCommandById(id);

            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromRepo);

            await _repository.SaveChangesAsync();

            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommand(int id, CommandUpdatedDto commandUpdatedDto)
        {
            var commandModelFromRepo = await _repository.GetCommandById(id);

            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdatedDto, commandModelFromRepo);

            //await _repository.UpdateCommand(commandModelFromRepo);

            await _repository.SaveChangesAsync();

            return Ok(_mapper.Map<CommandReadDto>(commandModelFromRepo));
        }

    }
}
