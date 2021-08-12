using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageClient.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string UserName { get; set; }
    public string Content { get; set; }
    public int GroupId { get; set; }
    public DateTime Date { get; set; }

    public static List<Message> GetMessages()
    {
      Task<string> apiCallTask = ApiHelper.GetAll("message");
      string result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Message> messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse.ToString());

      return messageList;
    }

    public static List<Message> GetByGroup(int groupId)
    {
      Task<string> apiCallTask = ApiHelper.GetMessageByGroup(groupId);
      string result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Message> messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse.ToString());

      return messageList;
    }

    public static Message GetDetails(int id)
    {
      Task<string> apiCallTask = ApiHelper.Get("message", id);
      string result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Message message = JsonConvert.DeserializeObject<Message>(jsonResponse.ToString());

      return message;
    }

    public static async Task Post(Message message, string token)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      await ApiHelper.Post("message", jsonMessage, token);
    }

    public static async Task Put(Message message, string token)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      await ApiHelper.Put(message.MessageId, jsonMessage, token);
    }

    public static async Task Delete(int id, string token)
    {
      await ApiHelper.Delete(id, token);
    }
  }
}