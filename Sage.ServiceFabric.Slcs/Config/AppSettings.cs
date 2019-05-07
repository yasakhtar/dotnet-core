using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sage.ServiceFabric.Slcs.Config
{
    public class AppSettings
    {
        public bool? SwaggerUIAuthorisation { get; set; }
        public bool EnableSwagger { get; set; }
        public string AzureKeyVaultSecret { get; set; }
        public GeneralSettings Settings { get; set; }
        public UrlSettings Urls { get; set; }
    }
}
