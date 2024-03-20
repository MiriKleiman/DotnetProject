using Microsoft.AspNetCore.Mvc;
using Subscriber_CORE.DTO;
using Subscriber_CORE.Interface;
using Subscriber_CORE.Response;
using Subscriber_Data.Entities;
using System;

namespace Subscriber_Service_Bl
{
    public class CardBl: ICardBl
    {
        readonly ICardDal _cardDal;

        public CardBl(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

       
     
        public async Task<BaseResponseGeneral<ClassesResponse>> GetCardById(int id)
        {
            var response = await _cardDal.GetCardById(id);
            if (response.Succssed == false)
                 throw new Exception("error, id doesn't exist");
            return  response;
        }
        public async Task<BaseResponseGeneral<Card_Table>> Login(string email,string password)
        {
            if (await _cardDal.Login(email, password) == null)
                throw new Exception("error");
            return await _cardDal.Login(email, password);
        }
    }
}