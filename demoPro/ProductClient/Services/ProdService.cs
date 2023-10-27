using Newtonsoft.Json;
using ProductClient.Models;
using System.Text;

namespace ProductClient.Services
{
    public class ProdService : IProdService
    {
        HttpClient client;

        public const string BASE_URL = "http://localhost:5228/api/product";
        public ProdService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<ProductDto>?> FindAll()
        {
            string url = BASE_URL;

            string json = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<List<ProductDto>>(json);
        }

        /*public async Task<ProductDto?> FindById(string id)
        {
            string url = $"{BASE_URL}/{id}";

            string json = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<ProductDto>(json);
        }

        public async Task<ProductDto?> FindByName(string name)
        {
            string url = $"{BASE_URL}/{name}";

            string json = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<ProductDto>(json);
        }*/

        public async Task<int> Create(ProductDto prod)
        {
            int result = 0;
            string url = BASE_URL;

            var json = JsonConvert.SerializeObject(prod);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(url, content);

            if (res.IsSuccessStatusCode)
            {
                var resJson = await res.Content.ReadAsStringAsync();
                result = Convert.ToInt32(resJson);
            }
            return result;
        }

        public async Task<List<ProductDto>?> Search(string name)
        {
            string url = $"BASE_URL/search/{name}";

            string json = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<List<ProductDto>>(json);
        }
    }
}
