using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ContactModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string suject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}