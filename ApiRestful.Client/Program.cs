using ApiRestful.Client.ClientDtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiRestful.Client
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private const string apiUrl = "https://localhost:44312/api/";

        static async Task Main(string[] args)
        {
            //var repositories = await ProcessRepositories();

            //foreach (var repo in repositories)
            //{
            //    Console.WriteLine(repo.Name);
            //    Console.WriteLine(repo.Description);
            //    Console.WriteLine(repo.GitHubHomeUrl);
            //    Console.WriteLine(repo.Homepage);
            //    Console.WriteLine(repo.Watchers);
            //    Console.WriteLine(repo.LastPush);
            //    Console.WriteLine();
            //}

            //var products = await ProcessApiProducts();
        }

        private static async Task<List<Repository>> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
            return repositories;
        }

        private static async Task<List<ApiClientDtoProduct>> ProcessApiProducts()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync(apiUrl + "product/");
            var repositories = await JsonSerializer.DeserializeAsync<List<ApiClientDtoProduct>>(await streamTask);
            return repositories;
        }
    }
}
