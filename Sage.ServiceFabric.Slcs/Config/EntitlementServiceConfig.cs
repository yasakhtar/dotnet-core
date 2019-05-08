using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sage.ServiceFabric.Slcs.Config
{
    public class EntitlementServiceConfig
    {
        public string Endpoint { get; set; }
        public string IdentityId { get; set; }
        public string SecretKey { get; set; }
    }
}
