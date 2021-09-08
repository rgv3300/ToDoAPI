using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;


namespace ToDoAPI.Data
{
    public class TaskContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public TaskContext(DbContextOptions<TaskContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder();
            builder.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            builder.Username = _configuration["UserID"];
            builder.Password = _configuration["Password"];

            options.UseNpgsql(builder.ConnectionString);
        }
        public DbSet<Tasks> Tasks { get; set; }
    }
}