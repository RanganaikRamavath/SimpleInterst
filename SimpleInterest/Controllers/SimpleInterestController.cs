using Microsoft.AspNetCore.Mvc;
using SimpleInterest.Service.Interface;

namespace SimpleInterest.Controllers
{
    [ApiController]
    [Route("api/SimpleInterest")]
    public class SimpleInterestController : ControllerBase
    {
        private readonly ISimpleInterstService _siservice;
        public SimpleInterestController(ISimpleInterstService siservice)
        {
            _siservice = siservice;
        }
        [HttpPost]
        public int Get(SimpleInterestModel model) => _siservice.CalculateSimpleInterest(model);
       
        
        [HttpGet("{irate}")]
        public int GetYearlyInterst(int irate) => _siservice.CalculateSimpleInterestYearly(irate);

    }


}
