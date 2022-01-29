using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Core.DBEntities.Authentication;
using ReadingIsGood.Core.Interfaces;
using System.Security.Claims;

namespace ReadingIsGood.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public BaseController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        protected ApplicationUser GetCurrentUser()
        {
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            var email = claimsIdentity.FindFirst(ClaimTypes.Email)?.Value;
            return _customerService.FindByEmailAsync(email).Result;

        }
    }
}
