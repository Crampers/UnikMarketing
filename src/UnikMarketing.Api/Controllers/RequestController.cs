using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnikMarketing.Domain;

namespace UnikMarketing.Api.Controllers
{
    [Route("requests")]
    public class RequestController : Controller
    {
        //GET /requests (Gets all requests)
        [HttpGet]
        public async Task<ActionResult<ICollection<Request>>> GetRequests()
        {
            throw new NotImplementedException();
        }

        //GET /requests/{id} (Get requests with id)
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            throw new NotImplementedException();
        }
    }
}