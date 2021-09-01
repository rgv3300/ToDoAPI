using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoAPI.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ToDoAPI.Models;
using ToDoAPI.Controllers;



namespace ToDoAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder();
            NpgsqlConnectionStringBuilder userDB = new NpgsqlConnectionStringBuilder();
            userDB.ConnectionString = _configuration.GetConnectionString("UserConnection");
            builder.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            builder.Username = _configuration["UserID"];
            builder.Password = _configuration["Password"];
            services.AddDbContext<TaskContext>(options => options.UseNpgsql(builder.ConnectionString));
            services.AddDbContext<TaskUserContext>(options => options.UseNpgsql(userDB.ConnectionString));
            services.AddIdentity<IdentityUser, IdentityRole>();
            services.AddScoped<ITaskRepo, TaskRepo>();
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
