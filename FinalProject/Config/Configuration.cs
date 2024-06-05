using AutoMapper;
using Subscriber_CORE.Interface;
using Subscriber_Service_Bl;
using Subscriber_Service_Dal;
using Subsriber_Service;

namespace FinalProject.Config
{
    public static class ConfigurationService
    {
        /// <summary>
        /// פונקציה הרחבה לSERVICE משמש להזרקת תלויות 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(this IServiceCollection services)
        {
            //הזרקת תלויות 
            services.AddScoped<ICardDal, CardDal>();
            services.AddScoped<ICardBl, CardBl>();
            services.AddScoped<ISubscriberBl, SubscriberBl>();
            services.AddScoped<ISubscriberDal, SubscriberDal>();

            ///mapper אפשרות להמיר בין אוביקט אחד לשני 
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FinalProjectProfil());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
