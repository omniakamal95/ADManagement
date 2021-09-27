using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ADController : ControllerBase
    {
        private readonly IADService _adService;
        public ADController(IADService adService)
        {
            _adService = adService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var result = _adService.GetAllUsers();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult SearchADUsers(string name)
        {
            var result = _adService.SearchActiveDirectory(name);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult CreateUser(string name, string accountName)
        {
            var result = _adService.CreateUser(name, accountName);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }

}
