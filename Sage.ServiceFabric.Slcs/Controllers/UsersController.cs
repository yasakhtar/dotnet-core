using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Sage.ServiceFabric.Slcs.Config;
using Sage.ServiceFabric.Slcs.Models;

namespace Sage.ServiceFabric.Slcs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IOptions<ConfiguredUsers> configuredUsers;

        public UsersController(IOptions<ConfiguredUsers> configuredUsers)
        {
            this.configuredUsers = configuredUsers;
        }

        [HttpGet]
        public async Task<ActionResult<ConfiguredUsers>> Get()
        {
            return Ok(configuredUsers);
        }

    }
}