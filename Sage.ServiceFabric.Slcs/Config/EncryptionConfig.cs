using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sage.ServiceFabric.Slcs.Config
{
    public class EncryptionConfig
    {
        public string StoreLocation { get; set; }
        public string StoreName { get; set; }
        public string CertificateFindType { get; set; }
        public string CertificateThumbprint { get; set; }
        public string EncryptionKey { get; set; }
    }
}
