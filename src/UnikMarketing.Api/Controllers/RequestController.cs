using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnikMarketing.Domain;

namespace UnikMarketing.Api.Controllers
{
    [Route("requests")]
    public class RequestController : Controller
    {
        private readonly MarketingContext _requestContext;

        public RequestController(MarketingContext context)
        {
            _requestContext = context;
        }

        //GET /requests (Gets all requests)
        [HttpGet]
        public async Task<ActionResult<ICollection<Request>>> GetRequests()
        {
            return Ok(await _requestContext.Requests.ToListAsync());
        }

        //GET /requests/{id} (Get requests with id)
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _requestContext.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }
    }
}