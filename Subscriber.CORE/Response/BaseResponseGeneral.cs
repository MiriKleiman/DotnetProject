using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber_CORE.Response
{
    public class BaseResponseGeneral<T> : BaseResponse
    {
        public T Response { get; set; }
    }
}
