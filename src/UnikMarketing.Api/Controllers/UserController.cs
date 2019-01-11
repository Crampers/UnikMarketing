using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Serilog;
using UnikMarketing.Api.Models;
using UnikMarketing.Business;
using UnikMarketing.Domain;

namespace UnikMarketing.Api.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserController(IUserService userService, IMapper mapper, ILogger logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        //GET /users (Gets all users)
        [HttpGet]
        public async Task<ActionResult<ICollection<UserDto>>> GetUsers()
        {
            //_logger.Information("Get Me!");
            var users = await _userService.GetAll();
            var usersDtos = _mapper.Map<ICollection<UserDto>>(users);

            return Ok(usersDtos);
        }

        //GET /users/{id} (Gets user with id})
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        //GET /users/{id}/requests (Gets a user's requests)
        [HttpGet("{id}/requests")]
        public async Task<ActionResult<ICollection<RequestDto>>> GetUserRequests(int id)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            var requestDtos = _mapper.Map<ICollection<RequestDto>>(user.Requests);

            return Ok(requestDtos);
        }

        //GET /users/{id}/criteria (Gets a user's criteria)
        [HttpGet("{id}/criteria")]
        public async Task<ActionResult<Criteria>> GetUserCriteria(int id)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            var criteriaDto = _mapper.Map<CriteriaDto>(user.Criteria);

            return Ok(criteriaDto);
        }

        //POST /users (Creates new users)
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var createdUserDto = _mapper.Map<UserDto>(await _userService.Create(user));

            return CreatedAtAction("GetUser", new { Id = createdUserDto.Id }, createdUserDto);
        }

        //POST /users/{id}/requests (Creates a user's requests)
        [HttpPost("{id}/requests")]
        public async Task<ActionResult<User>> CreateUserRequest(int id, [FromBody] RequestDto requestDto)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            var request = _mapper.Map<Request>(requestDto);
            var createdRequest = await _userService.AddRequest(user, request);

            return CreatedAtAction("GetRequest", "Request", new { id = createdRequest.Id }, createdRequest);
        }

        //PUT /users/{id} (Updates an user ex- new email)
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            if (id != userDto.Id)
            {
                return BadRequest();
            }

            var updatedUser = _mapper.Map<User>(userDto);
            var updatedUserDto = _mapper.Map<UserDto>(await _userService.Update(updatedUser));

            return Ok(updatedUserDto);
        }

        //PUT /users/{id}/criteria (Updates a user's criteria))
        [HttpPut("{id}/criteria")]
        public async Task<ActionResult<User>> UpdateUserCriteria(int id, CriteriaDto criteriaDto)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            var criteria = _mapper.Map<Criteria>(criteriaDto);
            var updatedCriteria = await _userService.UpdateCriteria(user, criteria);

            return Ok(updatedCriteria);
        }

        //DELETE /users/{id} (Self explanatory)
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userService.Delete(id);

            return NoContent();
        }
    }
}