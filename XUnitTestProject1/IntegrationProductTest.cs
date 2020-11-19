using ApiRestful.Service;
using ApiRestful.Test.ApiTestDtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace ApiRestful.Test
{
    //https://www.youtube.com/watch?v=p5l7x_pFjmI
    //https://docs.microsoft.com/es-es/aspnet/core/test/integration-tests?view=aspnetcore-5.0
    //https://docs.microsoft.com/es-es/dotnet/architecture/microservices/multi-container-microservice-net-applications/test-aspnet-core-services-web-apps
    public class IntegrationProductTest
    {
        private readonly TestServer _server;        
        private readonly HttpClient _client;
        private List<ProductDto> sut_list_products;

        public IntegrationProductTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                   .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Api_Product_Get_Coneection_is_ok()
        {
            // Act            
            var response = await _client.GetAsync("/api/product");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            sut_list_products = await JsonSerializer.DeserializeAsync<List<ProductDto>>(responseStream, jsonSerializerOptions);

            // Assert
            Assert.True(sut_list_products.Count > 0);
        }

        [Fact]
        public async Task Api_Product_Get_Returns_List()
        {
            // Act            
            var response = await _client.GetAsync("/api/product");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            sut_list_products = await JsonSerializer.DeserializeAsync<List<ProductDto>>(responseStream, jsonSerializerOptions);

            // Assert
            Assert.True(sut_list_products.Count > 0);
        }

        [Fact]
        public async Task Api_Product_Post_Product()
        {
            // Act            
            var response = await _client.GetAsync("/api/product");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            sut_list_products = await JsonSerializer.DeserializeAsync<List<ProductDto>>(responseStream, jsonSerializerOptions);

            // Assert
            Assert.True(sut_list_products.Count > 0);
        }
    }
}
