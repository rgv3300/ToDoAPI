using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoAPI.Models
{
    public class TaskUser
    {
        [Required]

        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Key]
        public string Email { get; set; }
    }
    public class TaskUserContext : DbContext
    {
        public TaskUserContext(DbContextOptions<TaskUserContext> options) : base(options)
        {

        }
        public DbSet<TaskUser> TaskUsers { get; set; }
    }
}

