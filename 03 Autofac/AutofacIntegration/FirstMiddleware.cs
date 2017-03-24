﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace AutofacIntegration
{
    public class FirstMiddleware : OwinMiddleware
    {
        private readonly ILogger _logger;

        public FirstMiddleware(OwinMiddleware next, ILogger logger) : base(next)
        {
            this._logger = logger;
        }

        public override async Task Invoke(IOwinContext context)
        {
            this._logger.Write("Inside the 'Invoke' method of the '{0}' middleware.", GetType().Name);
            
            await Next.Invoke(context);
        }
    }
}
