using JobVisionTest.Domain.DTOs;
using JobVisionTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace JobVisionTest.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserConfig _userConfig;
        public AccountController(IUserConfig userConfig)
        {
            _userConfig = userConfig;
        }

        public ActionResult Index()
        {
            return View("/Presentation/Views/Index.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserDTO user)
        {
            if(ModelState.IsValid)
            {
                
               var Result =  await _userConfig.AddUser(user);
                if (Result)
                 return Redirect("Index");
                
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            return Redirect("Feild");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                var Result = await _userConfig.RemoveUser(user);
                if (Result)
                    return Redirect("/Presentation/Controllers/Index");
            }
            return Redirect("/Presentation/Controllers/Feild");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                var Result = await _userConfig.UpdateUser(user);
                 if(Result)
                    return Redirect("/Presentation/Controllers/Index");

            }
            return Redirect("/Presentation/Controllers/Feild");
        }
    }
}
