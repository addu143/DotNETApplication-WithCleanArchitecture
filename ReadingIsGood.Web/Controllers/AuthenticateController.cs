using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Core.DBEntities;
using ReadingIsGood.Core.DBEntities.Authentication;
using ReadingIsGood.Core.Interfaces;
using ReadingIsGood.Web.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public AuthenticateController(
            ICustomerService customerService,
            IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register()
        {

            var result = await _customerService.ListOfCustomers();
            List<CustomerModel> userViewModel = _mapper.Map<List<CustomerModel>>(result);

            ApplicationUser user = new ApplicationUser()
            {
                Email = "abc@abc.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "addu14333"
            };

            //var result = await userManager.CreateAsync(user, model.Password);

            //var result = await _authentication.CreateAsync(user, "Pdnan@123");
            //if (result.Succeeded)
            //{
            //    await _customerService.Add(new Customer()
            //    {
            //        ApplicationUser = user,
            //        Name = user.UserName
            //    });
            //}



            return Ok();
        //    var userExists = await userManager.FindByNameAsync(model.Username);
        //    if (userExists != null)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            //    ApplicationUser user = new ApplicationUser()
            //    {
            //        Email = model.Email,
            //        SecurityStamp = Guid.NewGuid().ToString(),
            //        UserName = model.Username
            //    };
            //    var result = await userManager.CreateAsync(user, model.Password);
            //    if (!result.Succeeded)
            //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            //    return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
    }
}
