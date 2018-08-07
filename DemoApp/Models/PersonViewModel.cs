using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Models
{
    public class PersonViewModel
    {
        [Required(ErrorMessage = "Please provide name.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "My Age")]
        public int Age { get; set; }
    }
}
