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
    public class SettingsController : ControllerBase
    {
        private readonly AppSettings appSettings;
        private readonly IConfiguration configuration;

        public SettingsController(IOptions<AppSettings> settings, IConfiguration configuration)
        {
            this.appSettings = settings.Value;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<AppSettings>> Get()
        {
            var res = configuration["AzureKeyVaultSecret"];
            return Ok(appSettings);
        }

    }
}