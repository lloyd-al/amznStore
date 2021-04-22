using amznStore.Basket.Api.Extensions;
using amznStore.Common.Infrastructure.Extensions;
using amznStore.Services.Basket.Api.GrpcServices;
using amznStore.Services.Basket.Core.Interfaces;
using amznStore.Services.Basket.Infrastructure;
using amznStore.Services.Basket.Infrastructure.Repositories;
using amznStore.Services.Discount.Grpc.Protos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amznStore.Services.Basket.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Startup));
            services.ConfigureExtensions();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("Redis");
            });
            services.AddTransient<IBasketRepository, BasketRepository>();

            // Grpc Configuration
            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
                        (o => o.Address = new Uri(Configuration["GrpcSettings:DiscountUrl"]));
            services.AddScoped<DiscountGrpcService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerExtension(provider);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
