using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unik.Marketing.Api.Domain;
using Unik.Marketing.Api.Domain.MarketingCase;
using Unik.Marketing.Api.Domain.MarketingCase.Commands;
using Unik.Marketing.Api.Web.Models;

namespace Unik.Marketing.Api.Web.Controllers
{
    [Route("marketingcase")]
    public class MarketingCaseController : Controller
    {
        private readonly ICommandBus _commandBus;

        public MarketingCaseController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        //POST /marketingcase
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] MarketingCaseDto marketingCaseDto)
        {
            var command = new CreateMarketingCaseCommand(
                marketingCaseDto.RentalObjectId,
                marketingCaseDto.Titel,
                marketingCaseDto.Description,
                marketingCaseDto.Deposit,
                marketingCaseDto.PrepaidRent,
                marketingCaseDto.LinkToProspect,
                marketingCaseDto.FromDate,
                marketingCaseDto.ToDate,
                marketingCaseDto.AvailableFromDate,
                marketingCaseDto.ShowOnSite,
                marketingCaseDto.AppartmentComment,
                marketingCaseDto.StatusProved,
                marketingCaseDto.StatusApprovedInitials,
                marketingCaseDto.StatusApprovedDate,
                marketingCaseDto.StatusProspectUpToDate,
                marketingCaseDto.Address1,
                marketingCaseDto.Address2
            );
            await _commandBus.Process(command);
            return Ok();
        }
    }
}
