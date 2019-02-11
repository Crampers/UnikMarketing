﻿using System.Threading.Tasks;

namespace Unik.Marketing.Api.Data
{
    public interface IDataProcessor
    {
        Task Process(ICommand command);

        Task<TResult> Process<TResult>(ICommand<TResult> command);

        Task<TResult> Process<TResult>(IQuery<TResult> query);
    }
}