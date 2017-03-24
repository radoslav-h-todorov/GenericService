﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinSelfHostAutofacNTLM
{
    //http://www.sbrickey.com/Tech/Blog/Post/AllowAnonymous_for_OWIN_Katana_self_hosted_WebAPIs_using_Kerberos
    [AllowAnonymous] // calling these APIs doesn't require auth, since it's meant to provide status / debugging info
    public class StatusController : ApiController
    {
        private readonly ILogger _logger;

        public StatusController(ILogger logger)
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

            return "Hello, status!";
        }
    }

}
