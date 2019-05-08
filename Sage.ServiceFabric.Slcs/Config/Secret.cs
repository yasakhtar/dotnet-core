using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sage.ServiceFabric.Slcs.Config
{
    public class Secret
    {
        public string EncryptedValue { get; set; }
        public string DecryptedValue { get; set; }
    }
}
