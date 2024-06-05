using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Subscriber_CORE.DTO;
using Subscriber_CORE.Interface;
using Subscriber_CORE.Response;
using Subscriber_Data.Entities;

namespace FinalProject.Controllers
{

    [Route("api/[controller]")]

    [ApiController]
    public class CardController : ControllerBase
    {
        readonly ICardBl _cardBl;
        readonly IMapper _mapper;
        public CardController(ICardBl cardBl, IMapper mapper)
        {
            _cardBl = cardBl;
            _mapper = mapper;
        }

        // [HttpGet]
        //public bool Exist(int id)
        //{
        //    return _cardBl.Exist(id);
        //}

        [HttpGet]
        [Route("cardById/{id}")]
        public async Task<BaseResponseGeneral<ClassesResponse>> GetCardById([FromRoute] int id)
        {
            //_mapper.Map<ClassesResponse>(id);
            return await _cardBl.GetCardById(id);
        }

        [HttpPost("/login")]
        //public BaseResponseGeneral<string> Login([FromRoute] LoginDTO loginModel)
        public async Task<BaseResponseGeneral<Card_Table>> Login(LoginDTO loginModel)
        {
            BaseResponseGeneral<Card_Table> c1 = await _cardBl.Login(loginModel.Email, loginModel.Password);
            return _mapper.Map <BaseResponseGeneral<Card_Table>>(c1);

        }


    }
}
