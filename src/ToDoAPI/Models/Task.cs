using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Models
{
    public class Task
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateDue { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
    }


}
