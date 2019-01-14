using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnikMarketing.Api.Models;
using UnikMarketing.Business;
using UnikMarketing.Domain;

namespace UnikMarketing.Api.Controllers
{
    [Route("requests")]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        //GET /requests (Gets all requests)
        [HttpGet]
        public async Task<ActionResult<ICollection<Request>>> GetRequests()
        {
            return Ok(await _requestService.GetAll());
        }

        //GET /requests/{id} (Get requests with id)
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            return Ok(await _requestService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Request>> Create([FromBody] RequestDto requestDto)
        {
            var request = _mapper.Map<Request>(requestDto);
            var createdDto = _mapper.Map<RequestDto>(await _requestService.Create(request));

            return CreatedAtAction(
                "GetRequest",
                new { id = createdDto.Id },
                createdDto
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Request>> Update(int id, [FromBody] RequestDto requestDto)
        {
            var request = await _requestService.Get(id);

            if (request == null)
            {
                return NotFound();
            }

            if (id != requestDto.Id)
            {
                return BadRequest();
            }

            var updatedRequest = _mapper.Map<Request>(requestDto);
            var updatedRequestDto = _mapper.Map<RequestDto>(await _requestService.Update(updatedRequest));

            return Ok(updatedRequestDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> Update(int id)
        {
            var request = await _requestService.Get(id);

            if (request == null)
            {
                return NotFound();
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            await _requestService.Delete(id);

            return NoContent();
        }
    }
}