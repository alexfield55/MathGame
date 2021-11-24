using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Player
    {
        [Key]
        [Required]
        public int id { get; set; }

        public string Name { get; set; }

        public string Age { get; set; }

        public int Score { get; set; }
    }
}
