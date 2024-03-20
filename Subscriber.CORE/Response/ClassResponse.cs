using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber_CORE.Response
{
    public class ClassesResponse : BaseResponse
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public double? BMI { get; set; } = 0;

        public double? Height { get; set; }

        public double? Weight { get; set; }

       
    }
}
