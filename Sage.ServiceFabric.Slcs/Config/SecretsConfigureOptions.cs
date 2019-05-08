using Microsoft.Extensions.Options;
using Sage.ServiceFabric.Slcs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sage.ServiceFabric.Slcs.Config
{
    public class DecryptedSecretsConfig : IConfigureOptions<DecryptedSecrets>
    {
        private readonly IEncryptionService encryptionService;
        private readonly SecretsConfig encryptedSecrets;

        public DecryptedSecretsConfig(IEncryptionService encryptionService, IOptions<SecretsConfig> encryptedSecrets)
        {
            this.encryptionService = encryptionService;
            this.encryptedSecrets = encryptedSecrets.Value;
        }

        public void Configure(DecryptedSecrets options)
        {
            options.Secret1 = encryptionService.Decrypt(encryptedSecrets.SecretKey1);
            options.Secret2 = encryptionService.Decrypt(encryptedSecrets.SecretKey2);
        }
    }
}
