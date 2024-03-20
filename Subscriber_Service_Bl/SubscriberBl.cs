using Microsoft.AspNetCore.Mvc;
using Subscriber_CORE.DTO;
using Subscriber_CORE.Interface;
using Subscriber_CORE.Response;
using Subscriber_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber_Service_Bl
{
    public class SubscriberBl:ISubscriberBl
    {
        readonly ISubscriberDal _SubscriberDal;

        public SubscriberBl(ISubscriberDal subscriberDal)
        {
            _SubscriberDal = subscriberDal;
        }


        public async Task<BaseResponseGeneral<bool>> subscriber(string first_name, string last_name, int id, string password, string email, double height)
        {
            //if (await _SubscriberDal.subscriber(first_name, last_name, id, password, email, height)==null)
            //{
            //    BaseResponseGeneral<bool> r = new BaseResponseGeneral<bool>();
            //    r.Response = false;
            //    return r;
            //}
            //throw new Exception("error, id doesn't exist");

           // BaseResponseGeneral<bool> b = await _SubscriberDal.subscriber(first_name, last_name, id, password, email, height);
           // BaseResponseGeneral<bool> r = new BaseResponseGeneral<bool>();

            //if (b.Response == true)
            //{
            //     _SubscriberDal.add(first_name, last_name, id, password, email, height);
            //    //throw new Exception("Sucseed");
            //    r.Response = true;
            //}
            //else
            //{
            //       r.Response = false;
            //}
            //return r;
            return await _SubscriberDal.subscriber(first_name, last_name, id, password, email, height);


        }
    }
}
