using DwitTech.AccountService.Data.Entities;
using DwitTech.AccountService.Core.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DwitTech.AccountService.Core.Interfaces;


namespace DwitTech.AccountService.WebApi.Controllers
{ 
    public class UserController : BaseController
    {
        public static User user = new User();

        private readonly IValidationService _validationService;
        private readonly IActivationService _activationService;

        public UserController(IValidationService validationService, IActivationService activationService)
        {
            _validationService = validationService;
            _activationService = activationService;
        }


        [HttpGet("/Account/Activation/{activationCode}")]
        public IActionResult Get()
        {
            _activationService.GetActivationUrl();
            return Ok();
        }


        [AllowAnonymous]
        [HttpPost("Update status")]
        public IActionResult UpdateStatus(UserStatus status)
        {
            _validationService.UpdateUserStatus(status);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("Send Welcome Email")]
        public IActionResult SendWelcomeEmail([FromBody] UserStatus status)
        {
            _validationService.SendWelcomeEmail();
            return Ok();
        }
            
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ResponseCode()
        {
            if(ModelState.IsValid)
            {
                return this.StatusCode(StatusCodes.Status200OK, "Verified");
            }
            else
            {
                return this.StatusCode(StatusCodes.Status503ServiceUnavailable, "Error message");
            }
        }
        
    }

}
