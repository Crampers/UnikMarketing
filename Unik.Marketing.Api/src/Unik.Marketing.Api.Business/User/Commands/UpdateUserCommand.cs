﻿namespace Unik.Marketing.Api.Business.User.Commands
{
    public class UpdateUserCommand : ICommand<Domain.User>
    {
        public UpdateUserCommand(Domain.User user)
        {
            User = user;
        }

        public Domain.User User { get; set; }
    }
}