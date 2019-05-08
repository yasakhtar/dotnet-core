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
    public class CosmosController : ControllerBase
    {
        private readonly CosmosSettings cosmosSettings;

        public CosmosController(IOptions<CosmosSettings> cosmosSettings)
        {
            this.cosmosSettings = cosmosSettings.Value;
        }

        [HttpGet]
        public async Task<ActionResult<AppSettings>> Get()
        {
            return Ok(cosmosSettings);
        }
    }
}