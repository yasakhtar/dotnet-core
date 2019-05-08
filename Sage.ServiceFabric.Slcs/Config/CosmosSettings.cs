using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sage.ServiceFabric.Slcs.Config
{
    public class CosmosSettings
    {
        public string DatabaseId { get; set; }
        public string EndpointUrl { get; set; }
        public string PrimaryKey { get; set; }
        public string SecondaryKey { get; set; }
    }
}
