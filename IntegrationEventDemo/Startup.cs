using ExpressDemo;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationEventDemo
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
            services.AddControllers();

            //注册相关服务
            services.AddMassTransit(config =>
            {

                config.AddConsumers(typeof(OrderPaySuccessEventConsumer).Assembly);

                // 使用RabbitMq作为消息中间件
                config.UsingRabbitMq((context, cfg) =>
                {
                    // 指定对应的主机地址
                    cfg.Host("127.0.0.1", "/", h =>
                    {
                        //指定用户名
                        h.Username("guest");
                        //指定密码
                        h.Password("guest");

                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
