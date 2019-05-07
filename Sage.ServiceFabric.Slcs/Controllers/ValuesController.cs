using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sage.ServiceFabric.Slcs.Models;
using Sage.ServiceFabric.Slcs.Services;

namespace Sage.ServiceFabric.Slcs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesService _valuesService;
        private readonly ILogger _logger;

        public ValuesController(IValuesService valuesService, ILogger<ValuesController> logger)
        {
            this._valuesService = valuesService;
            this._logger = logger;

        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            try
            {
                _logger.Information($"Getting all values 8");
                var values = await _valuesService.GetValues();

                return Ok(values);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting values", ex);
                return StatusCode(500);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
