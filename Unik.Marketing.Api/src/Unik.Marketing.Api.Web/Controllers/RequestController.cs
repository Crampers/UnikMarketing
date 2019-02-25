﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Unik.Marketing.Api.Data;
using Unik.Marketing.Api.Data.Request.Queries;
using Unik.Marketing.Api.Domain;
using Unik.Marketing.Api.Domain.Request;
using Unik.Marketing.Api.Domain.Request.Commands;
using Unik.Marketing.Api.Web.Models;

namespace Unik.Marketing.Api.Web.Controllers
{
    [Route("requests")]
    public class RequestController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryProcessor _queryProcessor;
        private readonly IMapper _mapper;

        public RequestController(ICommandBus commandBus, IQueryProcessor queryProcessor, IMapper mapper)
        {
            _commandBus = commandBus;
            _queryProcessor = queryProcessor;
            _mapper = mapper;
        }

        //GET /requests (Gets all requests)
        [HttpGet]
        public async Task<ActionResult<ICollection<Request>>> GetRequests()
        {
            var requests = await _queryProcessor.Process(new GetRequestsQuery());

            return Ok(requests);
        }

        //GET /requests/{id} (Get requests with id)
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(string id)
        {
            var requests = await _queryProcessor.Process(new GetRequestsQuery()
            {
                Ids = {id}
            });

            return Ok(requests.FirstOrDefault());
        }

        [HttpPost]
        public async Task<ActionResult<Request>> Create([FromBody] RequestDto requestDto)
        {
            var request = _mapper.Map<Request>(requestDto);
            var created = await _commandBus.Process(new CreateRequestCommand(request));
            var createdDto = _mapper.Map<RequestDto>(created);

            return CreatedAtAction(
                "GetRequest",
                new { id = createdDto.Id },
                createdDto
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Request>> Update(string id, [FromBody] RequestDto requestDto)
        {
            var requests = await _queryProcessor.Process(new GetRequestsQuery()
            {
                Ids = { id }
            });
            var request = requests.FirstOrDefault();

            if (request == null)
            {
                return NotFound();
            }

            if (id != requestDto.Id)
            {
                return BadRequest();
            }

            var updatingRequest = _mapper.Map<Request>(requestDto);
            var updatedRequest = await _commandBus.Process(new UpdateRequestCommand(updatingRequest));
            var updatedRequestDto = _mapper.Map<RequestDto>(updatedRequest);

            return Ok(updatedRequestDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> Update(string id)
        {
            var requests = await _queryProcessor.Process(new GetRequestsQuery()
            {
                Ids = { id }
            });
            var request = requests.FirstOrDefault();

            if (request == null)
            {
                return NotFound();
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            await _commandBus.Process(new DeleteRequestCommand(id));

            return NoContent();
        }
    }
}