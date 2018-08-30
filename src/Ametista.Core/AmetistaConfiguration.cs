using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Core
{
    public class AmetistaConfiguration
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string SqlServerConnectionString { get; set; }
        public string MongoConnectionString { get; set; }
        public string MongoDatabase { get; set; }
    }
}
