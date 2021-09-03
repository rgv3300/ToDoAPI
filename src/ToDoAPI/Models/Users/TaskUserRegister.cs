using System.ComponentModel.DataAnnotations;


namespace ToDoAPI.Models.Users
{
    public class TaskUserRegister
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}