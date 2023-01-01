using DataPassingTechnique.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DataPassingTechnique.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel userViewModel)
        {
            if (ModelState.IsValid) {
                if (userViewModel.Email=="user@gmail.com" && userViewModel.Password=="User@123")
                {
                    TempData["Msg"] = "WelcomeBack";
                    string user = JsonSerializer.Serialize(userViewModel);
                    TempData["User"] = user;
                    


                    return RedirectToAction("HomePage");
                }
                else
                {
                    ViewData["Error"] = "User Doesn't Exist";
                    return View();
                }
            
            }
            return View();
        }

        public IActionResult HomePage()
        {
            string userName= TempData["Msg"].ToString();
            string user = (string)TempData.Peek("User");
            UserViewModel model = JsonSerializer.Deserialize<UserViewModel>(user);


            


            return View();
        }

        public IActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("Login");
        }
    }
}
