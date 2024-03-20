using Subscriber_CORE.Interface;
using Subscriber_CORE.Response;
using Subscriber_Data;
using Subscriber_Data.Entities;
using System.Linq;

namespace Subsriber_Service
{
    public class CardDal : ICardDal
    {
        readonly Weight_Watchers_Context _weight_Watchers_Context;

        public CardDal(Weight_Watchers_Context weight_Watchers_Context)
        {
            _weight_Watchers_Context = weight_Watchers_Context;
        }

        public async Task<BaseResponseGeneral<ClassesResponse>> GetCardById(int id)
        {
            try
            {
                Subscriber subscriber = _weight_Watchers_Context.Subscriber.Where(s => s.Id == id).FirstOrDefault();
                Card_Table card = _weight_Watchers_Context.Card_Table.Where(c => c.Id == id).FirstOrDefault();
                BaseResponseGeneral<ClassesResponse> response = new BaseResponseGeneral<ClassesResponse>();
                if (subscriber != null && card != null)
                {
                    response.Succssed = true;
                    response.Response = new ClassesResponse();
                    response.Response.Weight = card.Weight;
                    response.Response.Height = subscriber.Height;
                    response.Response.BMI = card.BMI;
                    response.Response.FirstName = subscriber.First_name;
                    response.Response.LastName = subscriber.Last_name;
                    return response;
                }
                else
                {
                    response.Succssed = false;
                    return response;
                    // response.Response = "failed";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: not exsits");
            }
        }

        public async Task<BaseResponseGeneral<Card_Table>> Login(string Email, string Password)
        {
            try
            {
                Subscriber subscriber = _weight_Watchers_Context.Subscriber.Where(t => t.Email.Equals(Email) && t.Password.Equals(Password)).FirstOrDefault();
                BaseResponseGeneral<Card_Table> response = new BaseResponseGeneral<Card_Table>();
                response.Response = _weight_Watchers_Context.Card_Table.Where(x => x.Id == subscriber.Id).FirstOrDefault();
                return response;
            }
            catch (Exception ex)
            {
                throw new MyException(400, "Error", ex.Message);
            }
        }

    }
}