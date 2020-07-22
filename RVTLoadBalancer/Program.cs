using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Net;

namespace RVTLoadBalancer
{
    public class Program
    {
        public static void Main(string[] args)
        {


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureKestrel(o =>
                        {
                            o.ConfigureHttpsDefaults(o => o.ClientCertificateMode =
                                ClientCertificateMode.RequireCertificate);
                            o.Listen(IPAddress.Loopback, 5000);
                            o.Listen(IPAddress.Loopback, 44322,
                                listenOpt =>
                                {
                                listenOpt.UseHttps(Path.Combine("../Certs/loadbalancer.pfx"), "ar4iar4i", opt => opt.AllowAnyClientCertificate());
                                });
                        });

                    
                });
        

    }
}
