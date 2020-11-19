using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ApiRestful.Test
{
    public class TestClientProvider
    {
        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup());

            Client = server.CreateClient();
        }
    }
}
