using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class TodoModel
    {
        public int id { get; set; }
        [Required]
        public string task { get; set; }
        [Required]
        public bool status { get; set; }
    }
}
