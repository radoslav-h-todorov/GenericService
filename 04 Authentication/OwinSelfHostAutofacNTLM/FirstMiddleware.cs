using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace OwinSelfHostAutofacNTLM
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

            // Here we are reading the Identity we got
            WindowsPrincipal user = context.Request.User as WindowsPrincipal;
            if (user?.Identity != null)
            {
                this._logger.Write("My identity is: '" + user.Identity.Name + "'");
            }
            else
            {
                this._logger.Write("This is not 'WindowsPrincipal'");
            }

            await Next.Invoke(context);
        }
    }
}
