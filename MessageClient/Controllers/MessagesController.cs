using MessageClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageClient.Controllers
{
  public class MessagesController : Controller
  {
    //GET /messages
    [Route("/messages")]
    public IActionResult Index()
    {
      return RedirectToAction("Index", new {groupId = 0});
    }

    [Route("/messages/{groupId}")]
    public IActionResult Index(int groupId)
    {
      List<Group> groups = Group.GetGroups();

      Dictionary<int, string> groupDic = new Dictionary<int, string>();
      foreach(Group group in groups)
      {
        groupDic.Add(group.GroupId, group.Name);
      }
      ViewBag.groupDictionary = groupDic;

      groups.Insert(0, new Group() { GroupId = 0, Name = "All Groups"});
      ViewBag.groupId = new SelectList(groups, "GroupId", "Name");
      if(groupId > 0)
      {
        return View(Message.GetByGroup(groupId));
      }
      else
      {
        return View(Message.GetMessages());
      }
    }

    //GET /messages/details/5
    public IActionResult Details(int id)
    {
      Message message = Message.GetDetails(id);
      return View(message);
    }

    // GET /messages/create
    public ActionResult Create()
    {
      var token = Request.Cookies["cookieToken"];
      if (token == null)
      {
        return RedirectToAction("Validate", "Login");
      }
      else
      {
        List<Group> groups = Group.GetGroups();
        ViewBag.GroupId = new SelectList(groups, "GroupId", "Name");
        return View();
      }
    }

    // POST /messages/create (Message newMessage)
    [HttpPost]
    public async Task<ActionResult> Create(Message message)
    {
      message.UserName = "Shadow";
      var token = Request.Cookies["cookieToken"];
      if (token == null)
      {
        return RedirectToAction("Validate", "Login");
      }
      else
      {
        await Message.Post(message, token);
        return RedirectToAction("Index");
      }
    }

    // GET /messages/edit/5 (int editId)
    // need cookies

    // POST /messages/edit/5 (Message editMessage)
    // need cookies

    // GET /messages/delete/5

    public ActionResult Delete(int id)
    {
      var token = Request.Cookies["cookieToken"];
      if(token == null)
      {
        return RedirectToAction("Validate", "Login");
      }
      else
      {
        Message message = Message.GetDetails(id);
        return View(message);
      }
    }

    // POST /messages/delete/5 (int deleteId)
    [HttpPost, ActionName("Delete")]
    public async Task<ActionResult> ConfirmDelete(int id)
    {
      var token = Request.Cookies["cookieToken"];
      if(token == null)
      {
        return RedirectToAction("Validate", "Login");
      }
      else
      {
        await Message.Delete(id, token);
        return RedirectToAction("Index");
      }
    }
  }
}