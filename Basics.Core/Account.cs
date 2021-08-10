using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Basics.Core
{

    public class Account
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Citizenship { get; set; }
    }
}
