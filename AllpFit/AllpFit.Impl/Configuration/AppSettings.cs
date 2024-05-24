using System.Data.Common;
using System.Net.Security;

namespace AllpFit.Impl.Configuration
{
    public class AppSettings
    {
        public ConnectionString ConnectionStrings { get; set; }
        public Auth AuthSettings { get; set; }

        public class ConnectionString
        {
            public string DefaultConnection { get; set; }
        }

        public class Auth
        {
            public string Key { get; set; }
            public string Issuer { get; set; }
            public string Audience { get; set; }
        }
    }
}
