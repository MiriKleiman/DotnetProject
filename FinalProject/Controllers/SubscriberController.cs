using Microsoft.AspNetCore.Mvc;
using Subscriber_CORE.DTO;
using Subscriber_CORE.Interface;
using Subscriber_CORE.Response;
using Subscriber_Data.Entities;
using Subscriber_Service_Bl;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriberController:ControllerBase
    {
        readonly ISubscriberBl _SubscriberBl;

        public SubscriberController(ISubscriberBl subscriberBl)
        {
            _SubscriberBl = subscriberBl;
        }
        [HttpPost("/subscriber")]
        //public BaseResponseGeneral<string> Login([FromRoute] LoginDTO loginModel)
        public async Task<BaseResponseGeneral<bool>> subscriber([FromBody] SubscriberDTO subscriber1)
        {
            return await _SubscriberBl.subscriber(subscriber1.first_name, subscriber1.last_name,subscriber1.Id,subscriber1.password,
                subscriber1.email,subscriber1.height);
        }
    }
}
