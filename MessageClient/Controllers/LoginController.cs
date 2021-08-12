using Microsoft.AspNetCore.Mvc;
using MessageClient.Models;
using RestSharp;
using System;
using Microsoft.AspNetCore.Http;

namespace MessageClient.Controllers
{
  public class LoginController : Controller
  {
    [HttpGet]
    [Route("/Login")]
    public IActionResult Validate()
    {
      return View();
    }

    [HttpPost]
    [Route("/Login")]
    public IActionResult Validate(Login userInfo)
    {
      string token = Login.GetToken(userInfo);

      if(token == null)
      {
        System.Console.WriteLine("token null");
        return RedirectToAction("Validate");
      }
      else
      {
        System.Console.WriteLine("Baking Cookies");
        System.Console.WriteLine("Token:" + token);
        
        //Delete existing cookie
        Response.Cookies.Delete("cookieToken");

        //Save new cookie
        Response.Cookies.Append(
          "cookieToken",
          token,
          new CookieOptions()
          {
            Path = "/",
            Expires = DateTime.Now.AddHours(2),
            HttpOnly = false,
            Secure = false
          }
        );

        return RedirectToAction("Index", "Home");
      }
    }
  }
}