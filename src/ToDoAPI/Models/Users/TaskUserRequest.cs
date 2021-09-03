using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models.Users
{
    public class TaskUserRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}