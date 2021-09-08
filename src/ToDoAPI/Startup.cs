using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoAPI.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ToDoAPI.Models;
using ToDoAPI.Models.Users;



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
            NpgsqlConnectionStringBuilder userDB = new NpgsqlConnectionStringBuilder();
            userDB.ConnectionString = _configuration.GetConnectionString("UserConnection");

            services.AddDbContext<TaskContext>();
            services.AddDbContext<TaskUserContext>(options => options.UseNpgsql(userDB.ConnectionString));
            services.AddScoped<ITaskRepo, TaskRepo>();
            services.AddControllers().AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
