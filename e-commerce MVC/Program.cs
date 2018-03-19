using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace e_commerce_MVC
{   //komy
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args) //setup environment - kestrel / ISS integration
                .UseStartup<Startup>() 
                .Build();
    }
}
