using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sage.ServiceFabric.Slcs.Services
{
    public interface IEncryptionService
    {
        string Encrypt(string value);
        string Decrypt(string encryptedValue);
    }
}
