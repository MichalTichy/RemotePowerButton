using System.Web.Http;
using RemotePowerButton.IO;

namespace RemotePowerButton.API
{
    public class PowerButtonController : ApiController
    {
        static PowerButton powerButton = new PowerButton();

        [HttpGet]
        [Route("powerButton/short")]
        public void ShortPowerButtonPress()
        {
            powerButton.PressPowerButton();
        }

        [HttpGet]
        [Route("powerButton/long")]
        public void LongPowerButtonPress()
        {
            powerButton.PressPowerButton(10000);
        }
    }
}