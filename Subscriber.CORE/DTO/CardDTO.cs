using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber_CORE.DTO
{
    public class CardDTO
    {
        public int Id { get; set; }
        public DateTime Open { get; set; }
        public double BMI { get; set; }
        public double height { get; set; }
        public DateTime update_Date { get; set; }
    }
}
