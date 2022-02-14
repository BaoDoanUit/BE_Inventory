using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MineralInventory.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MineralInventory.Auth;
using System.Text;
using DNTCommon.Web.Core;
using MineralInventory.Schedule;

namespace MineralInventory
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly string tokenKey = "STVG_KEY_2021_06_25";

        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(tokenKey);
            services.AddDNTCommonWeb();
            services.AddGrpc(options =>
             {
                 options.EnableDetailedErrors = true;
                 options.MaxReceiveMessageSize = 40 * 1024 * 1024; // 2 MB
                 options.MaxSendMessageSize = 40 * 1024 * 1024; // 4- MB
             });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsGRPCPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding", "Access-Control-Allow-Origin");
                });
            });
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddControllers();
            services.AddSingleton<IJWTAuthenticationManager>(new JWTAuthenticationManager(tokenKey));
            services.AddDNTScheduler(options =>
            {
                options.AddScheduledTask<UpdateCardTask>(
                    runAt: utcNow =>
                    {
                        var now = utcNow.AddHours(7);
                        return (now.Hour == 6 || now.Hour == 14 || now.Hour == 22) && now.Minute == 1 && now.Second == 1;
                        //return now.Second % 10 == 0;
                    },
                    order: 1);
                options.AddScheduledTask<UpdateInventory>(
                runAt: utcNow =>
                {
                    var now = utcNow.AddHours(7);
                    return now.Hour == 6;
                    //return now.Second % 10 == 0;
                },
                order: 1);
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipecode_packing_unit.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseGrpcWeb();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<AccountService>().EnableGrpcWeb().RequireCors("CorsGRPCPolicy");
                endpoints.MapGrpcService<AdministratorService>().EnableGrpcWeb().RequireCors("CorsGRPCPolicy");
                endpoints.MapGrpcService<WareHouseService>().EnableGrpcWeb().RequireCors("CorsGRPCPolicy");
                endpoints.MapGrpcService<CardService>().EnableGrpcWeb().RequireCors("CorsGRPCPolicy");
                endpoints.MapGrpcService<ReportService>().EnableGrpcWeb().RequireCors("CorsGRPCPolicy");
                endpoints.MapGrpcService<RecordConfirmService>().EnableGrpcWeb().RequireCors("CorsGRPCPolicy");
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
