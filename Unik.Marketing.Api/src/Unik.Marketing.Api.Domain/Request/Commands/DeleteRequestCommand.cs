﻿namespace Unik.Marketing.Api.Domain.Request.Commands
{
    public class DeleteRequestCommand : ICommand
    {
        public DeleteRequestCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}