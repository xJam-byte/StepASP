using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public async Task GetUsers() {
      string content = @"
          <form method = 'post'>
          <label>User name: </label><br/>          
          <input name='username' /><br/>
          <label>Age: </label><br/>  
          <input name='age' type='number'/> 
          <input type='submit' value='Send'/>"; 
    
      Response.ContentType = "text/html;charset=utf-8";
      await Response.WriteAsync(content);
    }
    
    [HttpPost]
    public string PostUsers(string username, int age) {
      return $"{username}:{age}";      
    }

  }
}