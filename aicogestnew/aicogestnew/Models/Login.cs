using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace aicogestnew.Models
{
    public class Login
    {
        [Required, MaxLength(20), EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
