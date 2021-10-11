using System.IO;
using Microsoft.Extensions.Configuration;

namespace TheTopPost
{
    public static class ConnectionManager
    {
        public static IConfiguration ConnectionConfiguration { get; }

        static ConnectionManager()
        {
            ConnectionConfiguration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("connectionsdata.json")
                    .Build();
        }
    }
}