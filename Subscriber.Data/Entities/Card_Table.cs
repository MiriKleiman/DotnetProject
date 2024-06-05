using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscriber_Data.Entities;
namespace Subscriber_Data.Entities
{
    [Table("Card_Table")]
    public class Card_Table
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey (nameof(Id))]
        public Subscriber SId { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:dd/mm/yyyy ")]
        public DateTime Open { get; set; }
        public double BMI { get; set; }
        public double Weight { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:dd/mm/yyyy ")]
        public DateTime update_Date { get; set; }
    }
}
