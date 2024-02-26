using GenHTTP.Engine;
using GenHTTP.Modules.IO;
using GenHTTP.Modules.Layouting;
using GenHTTP.Modules.Practices;
using GenHTTP.Modules.Security;
using GenHTTP.Modules.Webservices;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace GenHttpAgain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var PageLayout = Layout.Create()
            .Add(CorsPolicy.Permissive())
            .AddService<Service>("Service");

            Host.Create()
                .Defaults()
                .Console()
                .Bind(System.Net.IPAddress.Any, 8080)
                .Handler(PageLayout)
                .Run();
        }
    }
}
