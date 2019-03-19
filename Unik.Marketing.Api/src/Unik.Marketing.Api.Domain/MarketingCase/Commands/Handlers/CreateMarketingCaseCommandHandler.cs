using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.MarketingCase.Commands.Handlers
{
    public class CreateMarketingCaseCommandHandler : ICommandHandler<CreateMarketingCaseCommand>
    {
        private readonly IRepository<MarketingCase> _repository;

        public CreateMarketingCaseCommandHandler(IRepository<MarketingCase> repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateMarketingCaseCommand command)
        {
            var marketingCase = new MarketingCase(
                command.RentalObjectId,
                command.Titel,
                command.Description,
                command.Deposit,
                command.PrepaidRent,
                command.LinkToProspect,
                command.FromDate,
                command.ToDate,
                command.AvailableFromDate,
                command.ShowOnSite,
                command.AppartmentComment,
                command.StatusProved,
                command.StatusApprovedInitials,
                command.StatusApprovedDate,
                command.StatusProspectUpToDate,
                command.Address1,
                command.Address2
            );

            return _repository.Save(marketingCase);
        }
    }
}
