using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Unik.Marketing.Api.Business;
using Unik.Marketing.Api.Web.Models;

namespace Unik.Marketing.Api.Web.Controllers
{
    [Route("marketingcase")]
    public class MarketingCaseController
    {
        private readonly IMapper _mapper;
        private readonly IRequestService _requestService;

        public MarketingCaseController(IMapper mapper, IRequestService requestService)
        {
            _mapper = mapper;
            _requestService = requestService;
        }

        //GET /requests (Gets all requests)
        [HttpGet]
        public async Task<ActionResult<ICollection<Request>>> GetRequests()
        {
            return Ok(await _requestService.GetAll());
        }

        //GET /requests/{id} (Get requests with id)
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(string id)
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
        public async Task<ActionResult<Request>> Update(string id, [FromBody] RequestDto requestDto)
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
        public async Task<ActionResult<Request>> Update(string id)
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
