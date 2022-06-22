using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using ShopsRUs.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Test
{
    class TestClientProvider
    {
        public HttpClient client { get; set; }
        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            client = server.CreateClient();
            client.BaseAddress = new Uri("http://localhost:61510/");
        }
    }
}
