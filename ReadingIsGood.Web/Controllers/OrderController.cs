using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReadingIsGood.Core.DBEntities;
using ReadingIsGood.Core.Interfaces;
using ReadingIsGood.Web.EnpointModel;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ResponseGeneric _responseGeneric;
        

        public OrderController(        
            IMapper mapper,
            IConfiguration configuration,
            ResponseGeneric responseGeneric,
            IProductService productService,
            IOrderService orderService,
            ILogService logService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _responseGeneric = responseGeneric;
            _productService = productService;
            _orderService = orderService;
            _logService = logService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] OrderNewRequest orderRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    #region VALIDATIONS
                    //Group the records and sum quantity if dupplicate                    
                    var groupedRequestData = orderRequest.Products.ToList()
                        .GroupBy(m => m.ProductId)
                        .Select(m => new {
                            ProductId = m.Key,
                            Quantity = m.Sum(x => x.Quantity)
                        });

                    List<Product> listOfSelectedProducts = new List<Product>();
                    foreach (var item in groupedRequestData)
                    {
                        //Verify product exist
                        var product = await _productService.GetByIdAsync(item.ProductId);
                        if (product == null) 
                            return BadRequest(_responseGeneric.Error("Product not exist"));

                        //Quantity Check
                        if (product.AvailableQuantity <= 0) 
                            return BadRequest(_responseGeneric.Error("Sold out, Check back later"));

                        listOfSelectedProducts.Add(product);
                    }
                    #endregion

                    #region OPERATIONS
                    //Map and Create Product

                    //TODO real CustomerID
                    Order order = new Order();
                    order.CustomerId = 1;
                    order.OrderItems = new List<OrderItem>();

                    foreach (Product prod in listOfSelectedProducts)
                    {
                        var requestData = groupedRequestData.Where(m => m.ProductId == prod.Id).FirstOrDefault();
                        OrderItem orderItem = new OrderItem() { 
                            Price = prod.Price,
                            Product = prod,
                            Quantity = requestData.Quantity,
                            SKU = prod.SKU                            
                        };
                        order.OrderItems.Add(orderItem);
                    }
                    
                    //Save to DB:
                    _orderService.AddAsync(order).GetAwaiter().GetResult();

                    //Update Product Quantity
                    foreach (Product prod in listOfSelectedProducts)
                    {
                        var requestData = groupedRequestData.Where(m => m.ProductId == prod.Id).FirstOrDefault();
                        prod.Sold += requestData.Quantity;
                        await _productService.UpdateAsync(prod);
                    }
                    #endregion

                    //Logging
                    var logDetail = _logService.InsertLog(LogLevel.Information, "CreateOrder").Result;
                    return Ok(_responseGeneric.Success(log: logDetail));
                }
                else
                {
                    return BadRequest(_responseGeneric.Error(result: ModelState));
                }

            }
            catch (Exception ex)
            {
                //Logging
                Log logDetail = _logService.InsertLog(LogLevel.Error, "CreateOrder", ex.ToString()).Result;
                return BadRequest(_responseGeneric.Error(result: ex.Message.ToString(), log: logDetail));
            }
        }

        //    [HttpPost("create")]
        //    public async Task<IActionResult> Create([FromBody] OrderNewRequest Model)
        //    {
        //        try
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                #region VALIDATIONS
        //                var isAlreadyExist = await _customerService.FindByEmailAsync(cusModel.Email) != null;
        //                if (isAlreadyExist)
        //                {
        //                    return BadRequest(_responseGeneric.Error("User already exist"));
        //                }
        //                #endregion

        //                #region OPERATIONS
        //                ApplicationUser user = new ApplicationUser()
        //                {
        //                    Email = cusModel.Email,
        //                    UserName = cusModel.Email,
        //                    SecurityStamp = Guid.NewGuid().ToString()                        
        //                };

        //                var result = await _customerService.CreateAsync(user, cusModel.Password);
        //                if (!result.Succeeded)
        //                {
        //                    List<string> errors = new List<string>();
        //                    if (result.Errors != null)
        //                    {
        //                        foreach (var error in result.Errors)
        //                        {
        //                            errors.Add(error.Description.ToString());
        //                        }
        //                    }

        //                    return BadRequest(_responseGeneric.Error(result: errors));

        //                }

        //                //Create an entry in Customer Table along with ASPNET Identity tables:
        //                await _customerService.AddAsync(new Customer()
        //                {
        //                    ApplicationUser = user,
        //                    Name = cusModel.Name
        //                });

        //                return Ok(_responseGeneric.Success());
        //                #endregion
        //            }
        //            else
        //            {
        //                return BadRequest(_responseGeneric.Error(result: ModelState));

        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest();
        //        }
        //    }

        //    [HttpPost]
        //    [Route("login")]
        //    public async Task<IActionResult> Login([FromBody] CustomerLoginRequest loginModel)
        //    {
        //        var user = await _customerService.FindByEmailAsync(loginModel.Email);
        //        if (user != null && await _customerService.CheckPasswordAsync(user, loginModel.Password))
        //        {
        //            var authClaims = new List<Claim>
        //            {
        //                new Claim(ClaimTypes.Email, user.Email),
        //                new Claim("CustomerID", user.Customer.Id.ToString()),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //            };              

        //            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        //            var token = new JwtSecurityToken(
        //                issuer: _configuration["JWT:ValidIssuer"],
        //                audience: _configuration["JWT:ValidAudience"],
        //                expires: DateTime.Now.AddHours(3),
        //                claims: authClaims,
        //                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //                );

        //            return Ok(_responseGeneric.Success(result: new{
        //                token = new JwtSecurityTokenHandler().WriteToken(token),
        //                expiration = token.ValidTo
        //            }));
        //        }
        //        return Unauthorized(_responseGeneric.Error("Wrong credentials"));
        //    }
    }
}
