using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnikMarketing.Business;
using UnikMarketing.Domain;

namespace UnikMarketing.Api.Controllers
{
    [Route("requests")]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
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
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            return Ok(await _requestService.Get(id));
        }
    }
}