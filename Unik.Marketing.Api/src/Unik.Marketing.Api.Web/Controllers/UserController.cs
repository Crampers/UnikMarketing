using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Unik.Marketing.Api.Data;
using Unik.Marketing.Api.Data.Request.Queries;
using Unik.Marketing.Api.Data.User.Queries;
using Unik.Marketing.Api.Domain;
using Unik.Marketing.Api.Domain.User;
using Unik.Marketing.Api.Domain.User.Commands;
using Unik.Marketing.Api.Web.Models;

namespace Unik.Marketing.Api.Web.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        private readonly ICommandProcessor _commandProcessor;
        private readonly IQueryProcessor _queryProcessor;
        private readonly IMapper _mapper;

        public UserController(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor, IMapper mapper)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
            _mapper = mapper;
        }

        //GET /users (Gets all users)
        [HttpGet]
        public async Task<ActionResult<ICollection<UserDto>>> GetUsers()
        {
            var users = await _queryProcessor.Process(new GetUsersQuery());
            var usersDtos = _mapper.Map<ICollection<UserDto>>(users);

            return Ok(usersDtos);
        }

        //GET /users/{id} (Gets user with id})
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(string id)
        {
            var users = await _queryProcessor.Process(new GetUsersQuery()
            {
                Ids = { id }
            });
            var user = users.FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        //GET /users/{id}/requests (Gets a user's requests)
        [HttpGet("{id}/requests")]
        public async Task<ActionResult<ICollection<RequestDto>>> GetUserRequests(string id)
        {
            var requests = await _queryProcessor.Process(new GetRequestsQuery()
            {
                UserIds = { id }
            });
            var requestDtos = _mapper.Map<ICollection<RequestDto>>(requests);

            return Ok(requestDtos);
        }
        
        //POST /users (Creates new users)
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var createdUser = await _commandProcessor.Process(new CreateUserCommand(user));
            var createdUserDto = _mapper.Map<UserDto>(createdUser);

            return CreatedAtAction("GetUser", new { createdUserDto.Id }, createdUserDto);
        }
        
        //PUT /users/{id} (Updates an user ex- new email)
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(string id, [FromBody] UserDto userDto)
        {
            var users = await _queryProcessor.Process(new GetUsersQuery()
            {
                Ids = { id }
            });
            var user = users.FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            if (id != userDto.Id)
            {
                return BadRequest();
            }

            var updatingUser = _mapper.Map<User>(userDto);
            var updatedUser = _commandProcessor.Process(new UpdateUserCommand(updatingUser));
            var updatedUserDto = _mapper.Map<UserDto>(updatedUser);

            return Ok(updatedUserDto);
        }

        //DELETE /users/{id} (Self explanatory)

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var users = await _queryProcessor.Process(new GetUsersQuery()
            {
                Ids = { id }
            });
            var user = users.FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            await _commandProcessor.Process(new DeleteUserCommand(id));

            return NoContent();
        }
    }
}