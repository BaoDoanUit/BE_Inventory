using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MineralInventory.Services;
using MineralInventory.Helper;
using Dapper;
using System.Net;


namespace MineralInventory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SqlMapper.AddTypeHandler(new TrimmedStringHandler());
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseKestrel(options =>
                    {
                        //options.Listen(IPAddress.Any, 55001);
                        // options.Listen(IPAddress.Any, 50002, listenOptions =>
                        // {
                        //     listenOptions.UseHttps("stvg.vn.pfx", "stvg");
                        // });
                        // options.Listen(IPAddress.Any, 50002, listenOptions =>
                        // {
                        //     listenOptions.UseHttps("stvg.vn.pfx", "stvg");
                        // });
                        //
                        options.Listen(IPAddress.Any, 50002, listenOptions =>
                        {
                            listenOptions.UseHttps("stvg.vn.pfx", "stvg");
                        });
                    });
                });
    }
}
