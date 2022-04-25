using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserManagementSystem.Entities;
using UserManagementSystem.Models;
using UserManagementSystem.ViewModels;

namespace UserManagementSystem.Controllers
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
            //fetching from db
            LuciferContext context = new LuciferContext();
            List<User> users = context.Users.ToList();
            // fetching from  db ends

            IndexViewModel indexVm = new IndexViewModel();


            List<UserViewModel> userViewModelCollection = new List<UserViewModel>();


            //  Viewmodel generation logic starts
            // not so good way
            //listvm.users = users;
            // not so good way ends


            // with a good way
            foreach (User dbuser in users)
            {

                UserViewModel uservm = new UserViewModel();
                uservm.Id = dbuser.Id;
                uservm.Name = dbuser.Name;
                uservm.Age = dbuser.Age;
                uservm.City = dbuser.City;

                userViewModelCollection.Add(uservm);
            }

            indexVm.users = userViewModelCollection;

            // with a good way ends


            return View("Index", indexVm);
        }

        public IActionResult AddUser(UserViewModel userForm)
        {
            LuciferContext context = new LuciferContext();

            if (userForm.Id > 0)
            {
                foreach (User user in context.Users.ToList())
                {
                    if(user.Id == userForm.Id)
                    {
                        user.Name = userForm.Name;
                        user.Age = userForm.Age;
                        user.City= userForm.City;
                    }
                }

                context.SaveChanges();
                ViewData["Message"] = "User Edited";
                return View("CommonMessage");
            }
            else
            {
                User dbuser = new User();
                dbuser.Name = userForm.Name;
                dbuser.City = userForm.City;
                dbuser.Age = userForm.Age;

                context.Users.Add(dbuser);
                context.SaveChanges();
                ViewData["Message"] = "User Added";
                return View("CommonMessage");
            }


           
        }

        public IActionResult Edit(int id)
        {
            LuciferContext context = new LuciferContext();
            User user = context.Users.Where(x => x.Id == id).FirstOrDefault();
            IndexViewModel useredit = new IndexViewModel();
            useredit.user = new UserViewModel();
            if (user != null)
            {
                useredit.user.Id = user.Id;
                useredit.user.Name = user.Name ?? "";
                useredit.user.Age = user.Age ?? "";
                useredit.user.City = user.City ?? "";
            }


            return View("Index", useredit);
        }
        public IActionResult Delete(int id)
        {
            LuciferContext context = new LuciferContext();
            User user = context.Users.Where(x => x.Id == id).FirstOrDefault();
            context.Users.Remove(user);
            context.SaveChanges();

            ViewData["Message"] = "User Deleted";
            return View("CommonMessage");
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
    }
}