﻿namespace Blorc.PatternFly
{
    using System.Threading.Tasks;

    using Blorc.PatternFly.Components.Modal;
    using Blorc.Services;

    using Microsoft.AspNetCore.Components;

    public class PleaseWaitModalExecutionService : IExecutionService
    {
        public ComponentBase Component { get; set; }

        public async Task ExecuteAsync(object state = null)
        {
            await ((PleaseWaitModal)Component).ExecuteAsync(state);
        }
    }
}
