﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Senparc.Weixin.MP.Containers;

namespace weixin.mp.wujixiong.com
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //注册微信管理
            AccessTokenContainer.Register(Configuration["weixin_mp_appid"], Configuration["weixin_mp_appsecret"]);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles().UseMvc(
                routes => {
                        routes.MapRoute(
                        name: "area",
                        template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        routes.MapRoute(
                            name: "default",
                            template: "{controller}/{action=Index}/{id?}");
                });
        }
    }
}
