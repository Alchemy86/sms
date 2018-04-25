using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SmsApi.Controllers
{
    [Route("")]
    public class SmsController : Controller
    {
        [Route("sms")]
        public async Task<IActionResult> IndexAsync([FromBody] string message)
        {
            var accountSid = "AC2fe108f2552f831edcac826acd2f7fc3";
            var authToken = "f87e35e52ecdabd96218a7e34a097c29";

            TwilioClient.Init(accountSid, authToken);

            var result = await MessageResource.CreateAsync(
                to: new PhoneNumber("+447889876774"),
                from: new PhoneNumber("+441322252272"),
                body: message);

            return Ok(result.Sid);
        }
    }
}