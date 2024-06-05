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
    public interface ICardDal
    {
        Task<BaseResponseGeneral<ClassesResponse>> GetCardById(int id);
        Task<BaseResponseGeneral<Card_Table>> Login(string Email, string Password);

    }
}
