using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoAPI.Models.Users
{
    public class TaskUser
    {
        public int Id { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Key]
        public string Email { get; set; }
        [JsonIgnore]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
    public class TaskUserContext : IdentityDbContext
    {
        public TaskUserContext(DbContextOptions<TaskUserContext> options) : base(options)
        {

        }
        public DbSet<TaskUser> TaskUsers { get; set; }
    }
}

