using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    //api/commands
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _command;
        private readonly IMapper _mapper;

        //private readonly MockCommanderRepo repo = new MockCommanderRepo();

        public CommandsController(ICommanderRepo commander, IMapper mapper)
        {
            _command = commander;
            _mapper = mapper;
        }

        //GET api/command
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var models = _command.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(models));
        }

        //GET api/command/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _command.GetCommandById(id);

            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommands(CommandCreateDto cmdCreateDto)
        {
            var createModel = _mapper.Map<Command>(cmdCreateDto);
            _command.CreateCommand(createModel);
            _command.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(createModel);
            return CreatedAtRoute(nameof(GetCommandById), new { id = commandReadDto.Id }, commandReadDto);
            //return Ok(commandModel);
        }
    }
}




