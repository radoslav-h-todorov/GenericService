using System;

namespace GenericService
{
    // LEGACY

    //public class NtlmSelfHostConfiguration : HttpSelfHostConfiguration
    //{
    //    public NtlmSelfHostConfiguration(string baseAddress)
    //        : base(baseAddress)
    //    { }

    //    public NtlmSelfHostConfiguration(Uri baseAddress)
    //        : base(baseAddress)
    //    { }

    //    protected override BindingParameterCollection OnConfigureBinding(HttpBinding httpBinding)
    //    {
    //        httpBinding.Security.Mode = HttpBindingSecurityMode.TransportCredentialOnly;
    //        httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
    //        return base.OnConfigureBinding(httpBinding);
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var config = new HttpSelfHostConfiguration("http://myComputerName:8080");
    //        config.UseWindowsAuthentication = true;

    //        config.Routes.MapHttpRoute(
    //            "API Default", "api/{controller}/{id}",
    //            new { id = RouteParameter.Optional });

    //        using (HttpSelfHostServer server = new HttpSelfHostServer(config))
    //        {
    //            server.OpenAsync().Wait();

    //            Console.WriteLine("Press Enter to quit.");
    //            Console.ReadLine();
    //        }
    //    }
    //}
}