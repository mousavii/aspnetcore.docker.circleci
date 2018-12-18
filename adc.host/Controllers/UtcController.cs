using System;
using Microsoft.AspNetCore.Mvc;
using adc.utility;

namespace adc.host.Controllers
{
    [Route("api/[controller]")]
    public class UtcController : Controller
    {
        // GET api/utc
        [HttpGet]
        public DateTime Get()
        {
            return new DateUtil().GetUtc();
        }
    }
}
