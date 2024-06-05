using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Subscriber_Data.Entities
{
    [Table("subscriber")]
    public class Subscriber
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }

        [RegularExpression("^(07(\\d ?){9})", ErrorMessage = "Invalid Phone Number")]
        public string Email { get; set; }
        public string Password { get; set; }
        public double Height { get; set; }

         



    }
}
