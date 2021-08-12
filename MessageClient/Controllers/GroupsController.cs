using MessageClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageClient.Controllers
{
  public class GroupsController : Controller
  {
    //GET /groups
    public IActionResult Index()
    {
      List<Group> allGroups = Group.GetGroups();
      return View(allGroups);
    }

    //GET /groups/details/5
    public IActionResult Details(int id)
    {
      Group group = Group.GetDetails(id);
      return View(group);
    }

    // GET /groups/create
    public ActionResult Create()
    {
      var token = Request.Cookies["cookieToken"];
      if (token == null)
      {
        return RedirectToAction("Validate", "Login");
      }
      else
      {
        return View();
      }
    }

    // POST /groups/create (Group newGroup)
    [HttpPost]
    public async Task<ActionResult> Create(Group group)
    {
      var token = Request.Cookies["cookieToken"];
      if (token == null)
      {
        return RedirectToAction("Validate", "Login");
      }
      else
      {
        await Group.Post(group, token);
        return RedirectToAction("Index");
      }
    }
  }
}