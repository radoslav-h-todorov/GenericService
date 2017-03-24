using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinSelfHostAutofacNTLM
{
    public class TestController : ApiController
    {
        private readonly ILogger _logger;

        public TestController(ILogger logger)
        {
            this._logger = logger;
        }

        public string Get()
        {
            this._logger.Write("Inside the 'Get' method of the '{0}' controller.", GetType().Name);

            // Here we are reading the Identity we got
            WindowsPrincipal user = this.RequestContext.Principal as WindowsPrincipal;
            if (user?.Identity != null)
            {
                this._logger.Write("My identity is: '" + user.Identity.Name + "'");
            }
            else
            {
                this._logger.Write("This is not 'WindowsPrincipal'");
            }

            return "Hello, world!";
        }
    }
}
