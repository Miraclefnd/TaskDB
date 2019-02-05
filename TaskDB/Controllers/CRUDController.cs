using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskDB.Migrations;
using TaskDB.Models;

namespace TaskDB.Controllers
{
    public class CRUDController : Controller
    {
        [AllowAnonymous]
        public ActionResult UserList(string searching)
        {
            //UserManager<ApplicationUser> userManager;
            //userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //return View(userManager.Users);
            var context = new Models.ApplicationDbContext();
            return View(/*context.Users.ToList()*/ context.Users.Where(x=>x.Firstname.Contains(searching)||searching==null).ToList());
        }

        [AllowAnonymous]
        public ActionResult UserDelete(string id)
        {
            var context = new Models.ApplicationDbContext();
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult UserDelete(ApplicationUser appuser)
        {
            var context = new Models.ApplicationDbContext();
            var user = context.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
            context.Users.Remove(user);
            context.SaveChanges();
            //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            return RedirectToAction("UserList");
        }

        [AllowAnonymous]
        public ActionResult UserEdit(string id)
        {
            var context = new Models.ApplicationDbContext();
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult UserEdit(ApplicationUser appuser)
        {
            var context = new Models.ApplicationDbContext();
            var user = context.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
            //context.Entry(appuser).State = EntityState.Modified;
            //user.Email = appuser.Email;
            //user.UserName = appuser.UserName;
            //user.PhoneNumber = appuser.PhoneNumber;
            //user.PasswordHash = user.PasswordHash;
            user.Firstname = appuser.Firstname;
            user.Surname = appuser.Surname;
            user.Login = appuser.Login;
            user.Email = appuser.Email;
            user.EmailConfirmed = appuser.EmailConfirmed;
            user.UserName = appuser.UserName;
            context.SaveChanges();
            //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            return RedirectToAction("UserList");
        }


        //public ActionResult Details(ApplicationDbContext context)
        //{
        //    return View(context.Users.ToList());
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(ApplicationUser appuser , RegisterViewModel reg)
        //{
        //    //try
        //    //{
        //    //    using (ApplicationDbContext context = new ApplicationDbContext())
        //    //    {
        //    ApplicationDbContext context = new ApplicationDbContext();
        //    var user = context.Users.FirstOrDefault(u => u.Id == appuser.Id);
        //    reg.Firstname = reg.Firstname;
        //    reg.Surname = reg.Surname;
        //    reg.Login = reg.Login;
        //    reg.Email = reg.Email;
        //    //user.EmailConfirmed = appuser.EmailConfirmed;
        //    reg.Password = reg.Password;
        //    reg.ConfirmPassword = reg.ConfirmPassword;
        //    context.Users.Add(appuser);
          
           
        //        context.SaveChanges();
        //        return RedirectToAction("UserList");
           
        //    //context.SaveChanges();
          
        //}

        ////    }
        ////    return RedirectToAction("UserList");
        ////}
        ////catch
        ////{
        ////    return View();
        ////}
        
    }
}