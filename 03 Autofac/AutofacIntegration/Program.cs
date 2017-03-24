using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace AutofacIntegration
{
    //http://docs.autofac.org/en/latest/integration/webapi.html#owin-integration
    //https://github.com/autofac/Examples/tree/master/src/WebApiExample.OwinSelfHost
    //Install-Package Microsoft.AspNet.WebApi.OwinSelfHost
    //Install-Package Swashbuckle.Core
    //Install-Package Autofac.WebApi2.Owin
    class Program
    {
        static void Main()
        {
            string baseAddress = "http://localhost:9000/";

            // This starts the OWIN host using the application startup
            // logic in the Startup class. See Startup for the example of
            // how to set up OWIN Web API.
            using (WebApp.Start<Startup>(baseAddress))
            {
                // On startup this app will make a request to the self-hosted
                // Web API service. You should see logging statements and results
                // dumped to the console window.
                var client = new HttpClient();
                
                var response = client.GetAsync(baseAddress + "api/test").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine();
            }
        }
    }
}
