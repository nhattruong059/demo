using DemoClient.Models;
using Newtonsoft.Json;
using System.Text;
using System.Xml.Linq;

namespace DemoClient.Services
{
    public class AccountService : IAccountService
    {
        HttpClient client;

        public const string BASE_URL = "http://localhost:5209/api/account";

        public AccountService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<AccountDto?> Login(string email, string password)
        {
            string url = $"{BASE_URL}/{email}/{password}";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var result = await client.SendAsync(request);
            if(result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AccountDto>(json);
            }
            return null;
        }

        public async Task<List<AccountDto>?> FindAll()
        {
            var url = BASE_URL;
            string json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<AccountDto>>(json);
        }

        public async Task<bool> Create(AccountDto acc)
        {
            var url = BASE_URL;
            var json = JsonConvert.SerializeObject(acc);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);
            if(result.IsSuccessStatusCode)
            {
                var json2 = await result.Content.ReadAsStringAsync();
                return Convert.ToBoolean(json2);
            }
            return false;

        }
    }
}
