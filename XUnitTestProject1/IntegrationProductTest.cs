using ApiRestful.Test.ApiTestDtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace ApiRestful.Test
{
    public class IntegrationProductTest
    {       
        public IntegrationProductTest()
        {

        }

        [Fact]
        public async Task Api_Product_Get_Connection_is_ok()
        {
            using (var client = new TestClientProvider().Client)
            {
                // Act
                HttpResponseMessage response = await client.GetAsync("/api/product");
                response.EnsureSuccessStatusCode();

                // Assert
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Api_Product_Get_Returns_List()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Arrange
                List<ProductDto> sut_list_products;

                // Act
                HttpResponseMessage response = await client.GetAsync("/api/product");
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

        [Theory]
        [InlineData("Bike", "Bike name", "This is the best Bike")]
        [InlineData("Game", "Game name", "This is the best Game")]
        [InlineData("Food", "Food name", "This is the best Food")]
        public async Task Api_Product_Post_Product(string productId, string productName, string productDescription)
        {
            using (var client = new TestClientProvider().Client)
            {
                // Arrange
                Random rand = new Random();
                string id = rand.Next(1,99999).ToString();

                ProductDto newProduct = new ProductDto
                {
                    ProductId = productId + id,
                    ProductName = productName + " " + id,
                    ProductDescription = productDescription + " " + id
                };

                // Act
                string productDtoJsonFormat = JsonSerializer.Serialize(newProduct);
                StringContent stringContent = new StringContent(productDtoJsonFormat, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/api/product", stringContent);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
