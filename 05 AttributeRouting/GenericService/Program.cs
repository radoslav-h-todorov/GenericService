using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace GenericService
{
    //http://docs.autofac.org/en/latest/integration/webapi.html#owin-integration
    //https://github.com/autofac/Examples/tree/master/src/WebApiExample.OwinSelfHost
    //Install-Package Microsoft.AspNet.WebApi.OwinSelfHost (LEGACY package: Microsoft.AspNet.WebApi.SelfHost)
    //Install-Package Swashbuckle.Core
    //Install-Package Autofac.WebApi2.Owin
    class Program
    {
        static void Main()
        {
            //http://stackoverflow.com/questions/777607/the-remote-certificate-is-invalid-according-to-the-validation-procedure-using
            //Warning: do not use this in production code!
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate,
                         X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };

            //http://blog.boxofbolts.com/ssl/windows/owin/guide/2015/06/29/https-self-hosted-windows/
            //AND
            //https://pfelix.wordpress.com/2012/02/26/enabling-https-with-self-hosted-asp-net-web-api/
            //Setup SSL connection for the API
            string baseAddress = "https://localhost:4443/";

            // This starts the OWIN host using the application startup
            // logic in the Startup class. See Startup for the example of
            // how to set up OWIN Web API.
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("=========================");

                // On startup this app will make a request to the self-hosted
                // Web API service. You should see logging statements and results
                // dumped to the console window.
                var client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/status").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.ReadLine();

                Console.WriteLine("=========================");

                response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.ReadLine();

                Console.WriteLine("=========================");

                //http://www.diogonunes.com/blog/webclient-vs-httpclient-vs-httpwebrequest/
                var client2 = new WebClient();

                // Here is how we pass the credentials for NT authentication
                client2.UseDefaultCredentials = true;

                var response2 = client2.DownloadString(baseAddress + "api/test");

                Console.WriteLine(response2);

                Console.WriteLine("=========================");

                var response3 = client2.DownloadString(baseAddress + "customers/1/orders");

                Console.WriteLine(response3);

                Console.WriteLine("=========================");

                Console.ReadLine();
            }
        }
    }
}
