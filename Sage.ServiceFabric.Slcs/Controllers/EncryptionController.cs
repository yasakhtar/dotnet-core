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
    public class EncryptionController : ControllerBase
    {
        private readonly EncryptionConfig encryptionConfig;
        private readonly SecretsConfig secretsConfig;
        private readonly DecryptedSecrets decryptedSecrets;

        public EncryptionController(IOptions<EncryptionConfig> encryptionConfig, IOptions<SecretsConfig> secretsConfig, IOptions<DecryptedSecrets> decryptedSecrets)
        {
            this.encryptionConfig = encryptionConfig.Value;
            this.secretsConfig = secretsConfig.Value;
            this.decryptedSecrets = decryptedSecrets.Value;
        }

        [HttpGet]
        public async Task<ActionResult<EncryptionConfig>> Get()
        {
            return Ok(new { encryptionConfig, secretsConfig, decryptedSecrets });
        }

    }
}