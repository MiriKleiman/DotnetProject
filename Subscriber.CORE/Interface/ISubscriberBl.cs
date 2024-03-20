using Subscriber_CORE.DTO;
using Subscriber_CORE.Response;
using Subscriber_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber_CORE.Interface
{
    public interface ISubscriberBl
    {

        Task<BaseResponseGeneral<bool>> subscriber(string first_name, string last_name, int id, string password, string email, double height);

    }
}
