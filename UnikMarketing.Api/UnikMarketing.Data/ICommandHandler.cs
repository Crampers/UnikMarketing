﻿using System.Threading.Tasks;

namespace UnikMarketing.Data
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }

    public interface ICommandHandler<in TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        Task<TResult> Handle(TCommand command);
    }
}