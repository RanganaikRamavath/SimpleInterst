using Microsoft.AspNetCore.Mvc;
using SimpleInterest.Service.Interface;

namespace SimpleInterest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimpleInterestController : ControllerBase
    {
        private readonly ISimpleInterstService _siservice;
        public SimpleInterestController(ISimpleInterstService siservice)
        {
            _siservice = siservice;
        }
        [HttpPost]
        public int Get(SimpleInterestModel model) => _siservice.CalculateSimpleInterest(model);

    }


}
