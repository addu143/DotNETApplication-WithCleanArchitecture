using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReadingIsGood.Core.DBEntities;
using ReadingIsGood.Core.DBEntities.Authentication;
using ReadingIsGood.Core.Interfaces;
using ReadingIsGood.Web.EnpointModel;
using ReadingIsGood.Web.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
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
        private readonly IConfiguration _configuration;
        private ResponseGeneric _responseGeneric = new ResponseGeneric();
        public CustomerController(
            ICustomerService customerService,
            IMapper mapper,
            IConfiguration configuration)
        {
            _customerService = customerService;
            _mapper = mapper;
            _configuration = configuration;
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CustomerRegisterRequest cusModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    #region VALIDATIONS
                    var isAlreadyExist = await _customerService.FindByEmailAsync(cusModel.Email) != null;
                    if (isAlreadyExist)
                    {
                        return BadRequest(_responseGeneric.Error("User already exist"));
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

                        return BadRequest(_responseGeneric.Error(result: errors));
                        
                    }

                    //Create an entry in Customer Table along with ASPNET Identity tables:
                    await _customerService.AddAsync(new Customer()
                    {
                        ApplicationUser = user,
                        Name = cusModel.Name
                    });

                    return Ok(_responseGeneric.Success());
                    #endregion
                }
                else
                {
                    return BadRequest(_responseGeneric.Error(result: ModelState));

                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] CustomerLoginRequest loginModel)
        {
            var user = await _customerService.FindByEmailAsync(loginModel.Email);
            if (user != null && await _customerService.CheckPasswordAsync(user, loginModel.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("CustomerID", user.Customer.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };              

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(_responseGeneric.Success(result: new{
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                }));
            }
            return Unauthorized(_responseGeneric.Error("Wrong credentials"));
        }
    }
}
