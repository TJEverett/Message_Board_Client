using RestSharp;
using System.Threading.Tasks;

namespace MessageClient.Models
{
  class ApiHelper
  {
    private static string apiRoute = "http://localhost:5000/api";

    public static async Task<string> GetAll(string type)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"{type}s", Method.GET);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetMessageByGroup(int groupId)
    {
      System.Console.WriteLine(groupId);
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"messages?groupid={groupId}", Method.GET);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    
    public static async Task<string> Get(string type, int id)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"{type}s/{id}", Method.GET);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string type, string newEntry, string token)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"{type}s", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"Bearer {token}");
      request.AddJsonBody(newEntry);
      IRestResponse response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(int id, string newEntry, string token)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"messages/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"Bearer {token}");
      request.AddJsonBody(newEntry);
      IRestResponse response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id, string token)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"messages/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"Bearer {token}");
      IRestResponse response = await client.ExecuteTaskAsync(request);
    }

    public static async Task<string> Login(string userInfo)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"login", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(userInfo);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}