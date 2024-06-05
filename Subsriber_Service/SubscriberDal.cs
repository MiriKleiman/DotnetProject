using Subscriber_CORE.Interface;
using Subscriber_CORE.Response;
using Subscriber_Data;
using Subscriber_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber_Service_Dal
{
    public class SubscriberDal : ISubscriberDal
    {
        readonly Weight_Watchers_Context _weight_Watchers_Context;

        public SubscriberDal(Weight_Watchers_Context weight_Watchers_Context)
        {
            _weight_Watchers_Context = weight_Watchers_Context;
        }

        public async Task<BaseResponseGeneral<bool>> subscriber(string first_name, string last_name, int id, string password, string email, double height)
        {
            try
            {
                //Subscriber subscribernew = new Subscriber();
                //subscribernew.Id = id;
                //subscribernew.First_name = first_name;
                //subscribernew.Last_name = last_name;
                //subscribernew.Password = password;
                //subscribernew.Email = email;
                //subscribernew.Height = height;
                //BaseResponseGeneral<bool> response = new BaseResponseGeneral<bool>();

                Subscriber subscrib = _weight_Watchers_Context.Subscriber.Where(t => t.Email == email).FirstOrDefault();
                BaseResponseGeneral<bool> res = new BaseResponseGeneral<bool>();
                if (subscrib != null)
                    res.Response = false;
                else
                {
                    res.Response = true;
                    Subscriber subscribernew = new Subscriber();
                    subscribernew.Id = id;
                    subscribernew.First_name = first_name;
                    subscribernew.Last_name = last_name;
                    subscribernew.Password = password;
                    subscribernew.Email = email;
                    subscribernew.Height = height;
                    // BaseResponseGeneral<bool> response = new BaseResponseGeneral<bool>();

                    //Subscriber subscrib = _weight_Watchers_Context.Subscriber.Where(t => t.Email == email).FirstOrDefault();
                    //  response.Succssed = false;
                    //if (subscrib == null)
                    //    return await response;
                    //_weightWatchersContext.Cards.AddAsync(defaultCard);
                    //await _weightWatchersContext.SaveChangesAsync();
                     _weight_Watchers_Context.Subscriber.AddAsync(subscribernew);
                    await _weight_Watchers_Context.SaveChangesAsync();

                }
                //if (subscrib == null)
                //    response.Response = false;
                //else
                //    response.Response = true;

                return res;
                    //_weight_Watchers_Context.Subscriber.Add(subscribernew);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public  void add(string first_name, string last_name, int id, string password, string email, double height)
        {
            try
            {
                Subscriber subscribernew = new Subscriber();
                subscribernew.Id = id;
                subscribernew.First_name = first_name;
                subscribernew.Last_name = last_name;
                subscribernew.Password = password;
                subscribernew.Email = email;
                subscribernew.Height = height;
                // BaseResponseGeneral<bool> response = new BaseResponseGeneral<bool>();

                //Subscriber subscrib = _weight_Watchers_Context.Subscriber.Where(t => t.Email == email).FirstOrDefault();
                //  response.Succssed = false;
                //if (subscrib == null)
                //    return await response;
                //_weightWatchersContext.Cards.AddAsync(defaultCard);
                //await _weightWatchersContext.SaveChangesAsync();
                _weight_Watchers_Context.Subscriber.AddAsync(subscribernew);
                 _weight_Watchers_Context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }

        }

       
        //public Task<BaseResponseGeneral<bool>> subscriber(string first_name, string last_name, int id, string password, string email, double height)
        //{
        //    Subscriber subscribernew = new Subscriber();
        //    subscribernew.Id = id;
        //    return _weight_Watchers_Context.Add(subscribernew);
        //}
    }
}
