using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageClient.Models
{
  public class Group
  {
    public int GroupId { get; set; }
    public string Name { get; set; }

    public static List<Group> GetGroups()
    {
      Task<string> apiCallTask = ApiHelper.GetAll("group");
      string result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Group> groupList = JsonConvert.DeserializeObject<List<Group>>(jsonResponse.ToString());

      return groupList;
    }

    public static Group GetDetails(int id)
    {
      Task<string> apiCallTask = ApiHelper.Get("group", id);
      string result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Group group = JsonConvert.DeserializeObject<Group>(jsonResponse.ToString());

      return group;
    }

    public static async Task Post(Group group, string token)
    {
      string jsonGroup = JsonConvert.SerializeObject(group);
      await ApiHelper.Post("group", jsonGroup, token);
    }
  }
}