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
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly ResponseGeneric _responseGeneric;

        public LogController(ILogService logService,
                    ResponseGeneric responseGeneric)
        {
            _logService = logService;
            _responseGeneric = responseGeneric;
            
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Log> listOfLogs = _logService.GetAll().Result;
                return Ok(_responseGeneric.Success(result: listOfLogs));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
