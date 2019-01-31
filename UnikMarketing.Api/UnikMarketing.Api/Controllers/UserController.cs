using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnikMarketing.Api.Models;
using UnikMarketing.Business;
using UnikMarketing.Domain;

namespace UnikMarketing.Api.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IRequestService _requestService;

        public UserController(IMapper mapper, IUserService userService, IRequestService requestService)
        {
            _mapper = mapper;
            _userService = userService;
            _requestService = requestService;
        }

        //GET /users (Gets all users)
        [HttpGet]
        public async Task<ActionResult<ICollection<UserDto>>> GetUsers()
        {
            var users = await _userService.GetAll();
            var usersDtos = _mapper.Map<ICollection<UserDto>>(users);

            return Ok(usersDtos);
        }

        //GET /users/{id} (Gets user with id})
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(string id)
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
        public async Task<ActionResult<ICollection<RequestDto>>> GetUserRequests(string id)
        {
            var requests = await _requestService.GetByUser(id);
            var requestDtos = _mapper.Map<ICollection<RequestDto>>(requests);

            return Ok(requestDtos);
        }
        
        //POST /users (Creates new users)
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var createdUserDto = _mapper.Map<UserDto>(await _userService.Create(user));

            return CreatedAtAction("GetUser", new { createdUserDto.Id }, createdUserDto);
        }

        /*TODO: Solve Request issue
        //POST /users/{id}/requests (Creates a user's requests)
        //[HttpPost("{id}/requests")]
        //public async Task<ActionResult<User>> CreateUserRequest(int id, [FromBody] RequestDto requestDto)
        //{
        //    var user = await _userRepository.Get(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    var request = _mapper.Map<Request>(requestDto);
        //    var createdRequest = await _userRepository.AddRequest(user, request);

        //    return CreatedAtAction("GetRequest", "Request", new { id = createdRequest.Id }, createdRequest);
        //}
        */

        //PUT /users/{id} (Updates an user ex- new email)
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(string id, [FromBody] UserDto userDto)
        {
            var user = _userService.Get(id);

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

        //DELETE /users/{id} (Self explanatory)

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
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