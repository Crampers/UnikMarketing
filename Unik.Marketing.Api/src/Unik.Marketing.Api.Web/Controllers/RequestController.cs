using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Unik.Marketing.Api.Data;
using Unik.Marketing.Api.Data.Request.Queries;
using Unik.Marketing.Api.Domain;
using Unik.Marketing.Api.Domain.Request;
using Unik.Marketing.Api.Domain.Request.Commands;
using Unik.Marketing.Api.Web.Models.Request;

namespace Unik.Marketing.Api.Web.Controllers
{
    [Route("requests")]
    public class RequestController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IMapper _mapper;
        private readonly IQueryProcessor _queryProcessor;

        public RequestController(ICommandBus commandBus, IQueryProcessor queryProcessor, IMapper mapper)
        {
            _commandBus = commandBus;
            _queryProcessor = queryProcessor;
            _mapper = mapper;
        }

        //GET /requests (Gets all requests)
        [HttpGet]
        public async Task<ActionResult<ICollection<RequestDto>>> GetRequests()
        {
            var requests = await _queryProcessor.Process(new GetRequestsQuery());
            var requestDtos = _mapper.Map<ICollection<RequestDto>>(requests);

            return Ok(requestDtos);
        }

        //GET /requests/{id} (Get requests with id)
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestDto>> GetRequest(string id)
        {
            var requests = await _queryProcessor.Process(new GetRequestsQuery
            {
                Ids = {id}
            });
            var requestDto = _mapper.Map<RequestDto>(requests.FirstOrDefault());

            return Ok(requestDto);
        }

        [HttpPost]
        public async Task<ActionResult<RequestDto>> Create([FromBody] CreateRequestDto dto)
        {
            var created = await _commandBus.Process(new CreateRequestCommand(dto.Note, dto.UserId));
            var createdDto = _mapper.Map<RequestDto>(created);

            return CreatedAtAction(
                "GetRequest",
                new {id = createdDto.Id},
                createdDto
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RequestDto>> Update(string id, [FromBody] UpdateRequestDto requestDto)
        {
            var updatedRequest = await _commandBus.Process(new UpdateNoteCommand(id, requestDto.Note));
            var updatedRequestDto = _mapper.Map<RequestDto>(updatedRequest);

            return Ok(updatedRequestDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestDto>> Update(string id)
        {
            await _commandBus.Process(new DeleteRequestCommand(id));

            return NoContent();
        }
    }
}