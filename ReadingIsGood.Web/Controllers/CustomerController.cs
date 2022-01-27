using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Core.DBEntities;
using ReadingIsGood.Core.DBEntities.Authentication;
using ReadingIsGood.Core.Interfaces;
using ReadingIsGood.Web.EnpointModel;
using ReadingIsGood.Web.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadingIsGood.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService,
            IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        // GET: api/<CustomerController>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]CustomerRegisterRequest cusModel)
        {
            try
            {
                ResponseGeneric response = new ResponseGeneric();
                if (ModelState.IsValid)
                {
                    #region VALIDATIONS
                    var isAlreadyExist = await _customerService.FindByEmailAsync(cusModel.Email) != null;
                    if (isAlreadyExist)
                    {
                        return BadRequest(response.Error("User already exist"));
                    }
                    #endregion

                    #region OPERATIONS
                    ApplicationUser user = new ApplicationUser()
                    {
                        Email = cusModel.Email,
                        UserName = cusModel.Email,
                        SecurityStamp = Guid.NewGuid().ToString()                        
                    };

                    var result = await _customerService.CreateAsync(user, cusModel.Password);
                    if (!result.Succeeded)
                    {
                        List<string> errors = new List<string>();
                        if (result.Errors != null)
                        {
                            foreach (var error in result.Errors)
                            {
                                errors.Add(error.Description.ToString());
                            }
                        }

                        return BadRequest(response.Error(result: errors));
                        
                    }

                    //Create an entry in Customer Table along with ASPNET Identity tables:
                    await _customerService.Add(new Customer()
                    {
                        ApplicationUser = user,
                        Name = cusModel.Name
                    });

                    return Ok(response.Success());
                    #endregion
                }
                else
                {
                    return BadRequest(response.Error(result: ModelState));

                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            

        }

      
    }
}
