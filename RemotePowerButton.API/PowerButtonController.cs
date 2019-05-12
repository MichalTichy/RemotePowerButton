using System.Web.Http;
using System.Web.Http.Results;
using RemotePowerButton.IO;

namespace RemotePowerButton.API
{
    public class PowerButtonController : ApiController
    {
        static PowerButton powerButton = new PowerButton();
        static TokenValidator tokenValidator=new TokenValidator();

        [HttpPost]
        [Route("powerButton/short")]
        public IHttpActionResult ShortPowerButtonPress([FromUri]string token)
        {
            if (!tokenValidator.IsValid(token))
                return Unauthorized();

            powerButton.PressPowerButton();

            return Ok();
        }

        [HttpPost]
        [Route("powerButton/long")]
        public IHttpActionResult LongPowerButtonPress([FromUri]string token)
        {
            if (!tokenValidator.IsValid(token))
                return Unauthorized();

            powerButton.PressPowerButton(10000);
            return Ok();
        }

        [HttpGet]
        [Route("status")]
        public IHttpActionResult GetStatus()
        {
            return Ok();
        }
    }
}