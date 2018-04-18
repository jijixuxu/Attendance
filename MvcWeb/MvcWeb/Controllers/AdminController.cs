using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Controllers
{

    public class AdminController : Controller
    {
        Business.users us = new Business.users();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userid, string userpwrd)
        {
            bool b = us.Login(userid, userpwrd);
            if (b)
            {
                Session["UserName"] = us.UserName;
                Session["UserId"] = userid;
                return RedirectToAction("../Users/UpdatePassWord");
            }
            else
            {
                //Response.Write("<script>alert('用户名或者密码错误!');location.href='/Users/Login'</script>");
                @ViewBag.Error = us.ErrMsg;
                return View();
            }
        }
    
    }
}
