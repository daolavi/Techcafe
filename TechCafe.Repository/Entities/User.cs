using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechCafe.Repository.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MinLength(6)]
        [MaxLength(20)]
        public string Username { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }
    }
}
