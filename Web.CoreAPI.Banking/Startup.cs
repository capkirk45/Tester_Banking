using Banking.AppCore.Business;
using Banking.AppCore.Business.Interfaces;
using Banking.AppCore.Common.DTOs;
using Banking.AppCore.Common.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace Banking.NETCore.API
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IAccountManager, AccountManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            app.UseStatusCodePages();
            AutoMapper.Mapper.Initialize(m =>
            {
                m.CreateMap<Transaction, TransactionDTO>();
                m.CreateMap<TransactionDTO, Transaction>();
            });
            app.UseMvc();

       
        }
    }
}
