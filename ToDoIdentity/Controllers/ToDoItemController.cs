using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoIdentity.Data;
using ToDoIdentity.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoIdentity.Controllers
{
    [Authorize]
    public class ToDoItemController : Controller
    {
        private readonly ToDoContext context;
        private readonly UserManager<IdentityUser> userManager;

        public ToDoItemController(ToDoContext _context,
            UserManager<IdentityUser> _userManger)
        {
            context = _context;
            userManager = _userManger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var toDoItems = context.ToDoItems.Where(i => i.UserId == userManager.GetUserId(User));
            var model = new ViewModel()
            {
                UserName = userManager.GetUserName(User),
                Items = toDoItems.ToArray()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create([FromForm]string toDoName)
        {
            var newItem = new ToDoItem()
            {
                UserId = userManager.GetUserId(User),
                ToDo = toDoName
            };
            context.ToDoItems.Add(newItem);
            context.SaveChanges();

            return Redirect("/ToDoItem/Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = context.ToDoItems.FirstOrDefault(i => i.Id == id);
            context.ToDoItems.Remove(item);
            context.SaveChanges();

            return Redirect("/ToDoItem/Index");
        }
    }
}
