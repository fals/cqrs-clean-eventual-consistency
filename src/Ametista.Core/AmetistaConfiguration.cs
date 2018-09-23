using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Core
{
    public class AmetistaConfiguration
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public int? RetryCount { get; set; }
    }

    public class ConnectionStrings
    {
        public string SqlServerConnectionString { get; set; }
        public string MongoConnectionString { get; set; }
        public string MongoDatabase { get; set; }
        public string EventBusHostname { get; set; }
        public string EventBusUsername { get; set; }
        public string EventBusPassword { get; set; }
        public string RedisCache { get; set; }
    }
}
