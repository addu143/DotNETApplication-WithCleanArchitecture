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

namespace ReadingIsGood.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IProductService _productService;
        private readonly ResponseGeneric _responseGeneric;
        private readonly ILogService _logService;

        public ProductController(
            IProductService productService,
            IMapper mapper,
            IConfiguration configuration, 
            ResponseGeneric responseGeneric,
            ILogService logService)
        {
            _productService = productService;
            _mapper = mapper;
            _configuration = configuration;
            _responseGeneric = responseGeneric;
            _logService = logService;
        }

        //[HttpPost("createCategory")]
        //public async Task<IActionResult> CreateCategory([FromBody] CreateProductCategoryRequest productModel)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            ProductCategory projectCategory = _mapper.Map<ProductCategory>(productModel);
        //            var category = await _productService.AddCategoryAsync(projectCategory);

        //            //Logging
        //            var logDetail = _logService.InsertLog(LogLevel.Information, "Category Created").Result;
        //            return Ok(_responseGeneric.Success(result: category, log: logDetail));
        //        }
        //        else
        //        {
        //            return BadRequest(_responseGeneric.Error(result: ModelState));
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //Logging
        //        Log logDetail = _logService.InsertLog(LogLevel.Error, "CreateCategory", ex.ToString()).Result;
        //        return BadRequest(_responseGeneric.Error(result: ex.Message.ToString(), log: logDetail));
        //    }
        //}

        //[HttpPost("createProduct")]
        //public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest productModel)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            //Map and Create Product
        //            Product product = _mapper.Map<Product>(productModel);
        //            product = await _productService.AddAsync(product);
                    
        //            //Logging
        //            Log logDetail = _logService.InsertLog(LogLevel.Information, "Category Created").Result;
        //            return Ok(_responseGeneric.Success(result: product, log: logDetail));
        //        }
        //        else
        //        {
        //            return BadRequest(_responseGeneric.Error(result: ModelState));
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //Logging
        //        Log logDetail = _logService.InsertLog(LogLevel.Error, "CreateProduct", ex.ToString()).Result;
        //        return BadRequest(_responseGeneric.Error(result: ex.Message.ToString(), log: logDetail));
        //    }
        //}

        [HttpGet("getAvailableProducts")]
        public async Task<IActionResult> GetAvailableProducts()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var products = await _productService.GetAllAsync();
                    List<ProductResponse> listOfProducts = _mapper.Map<List<ProductResponse>>(products);

                    //Logging
                    var logDetail = _logService.InsertLog(LogLevel.Information, "GetAvailableProducts").Result;
                    return Ok(_responseGeneric.Success(result: listOfProducts, log: logDetail));
                }
                else
                {
                    return BadRequest(_responseGeneric.Error(result: ModelState));
                }

            }
            catch (Exception ex)
            {
                //Logging
                Log logDetail = _logService.InsertLog(LogLevel.Error, "CreateCategory", ex.ToString()).Result;
                return BadRequest(_responseGeneric.Error(result: ex.Message.ToString(), log: logDetail));
            }
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] CustomerLoginRequest loginModel)
        //{
        //    var user = await _customerService.FindByEmailAsync(loginModel.Email);
        //    if (user != null && await _customerService.CheckPasswordAsync(user, loginModel.Password))
        //    {
        //        var authClaims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Email, user.Email),
        //            new Claim("CustomerID", user.Customer.Id.ToString()),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        };              

        //        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        //        var token = new JwtSecurityToken(
        //            issuer: _configuration["JWT:ValidIssuer"],
        //            audience: _configuration["JWT:ValidAudience"],
        //            expires: DateTime.Now.AddHours(3),
        //            claims: authClaims,
        //            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //            );

        //        return Ok(_responseGeneric.Success(result: new{
        //            token = new JwtSecurityTokenHandler().WriteToken(token),
        //            expiration = token.ValidTo
        //        }));
        //    }
        //    return Unauthorized(_responseGeneric.Error("Wrong credentials"));
        //}
    }
}
