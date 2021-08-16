using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Models
{
    public class Task
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateDue { get; set; }
    }


}
