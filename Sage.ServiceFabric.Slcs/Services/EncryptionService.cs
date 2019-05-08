using Microsoft.Extensions.Options;
using Sage.ServiceFabric.Slcs.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sage.ServiceFabric.Slcs.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly EncryptionConfig encryptionConfig;

        public EncryptionService(IOptions<EncryptionConfig> encryptionConfig)
        {
            this.encryptionConfig = encryptionConfig.Value;
        }

        public string Decrypt(string encryptedValue)
        {
            return $"Decrypted: {encryptedValue}";
        }

        public string Encrypt(string value)
        {
            return $"Encrypted: {value}";
        }
    }
}
