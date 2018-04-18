using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Controllers
{
    public class UsersController : Controller
    {
        Business.users us = new Business.users();

        //显示所有数据
        public ActionResult UsersList()
        {
            return View(us.Get(""));
        }

        //根据ID删除该列数据
        public ActionResult UsersDelete(string id)
        {
            us.Delete(id);
            Response.Write("<script>alert('删除成功!');location.href='/Users/UsersList'</script>");
            return null;
        }

        //根据ID导出该列数据
        public ActionResult UsersEdit(string id)
        {
            ViewBag.Type = GetTypeList();
            if (id == null)
            {
                return View();
            }
            else
            {
                MvcModel.usersData userdata = us.SelectData(string.Format(" and id = {0}", id));
                return View(userdata);
            }
        }
        public ActionResult UpdatePassWord()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdatePassWord(string password1, string password2)
        {
            if (password1 != password2)
            {
                @ViewBag.Error = "两次密码不一致！";
            }
            else if (password1 == "")
            {
                @ViewBag.Error = "密码不允许为空！";
            }
            else
            {
                us.Update((string)Session["UserId"],password1);
                @ViewBag.Error = "修改成功！";
            }
            return View();
        }

        //添加或者修改该列数据
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UsersEdit(MvcModel.usersData ud)
        {
            if (ModelState.IsValid)
            {
                if (ud.Id == null)
                {
                    us.Insert(ud);
                    Response.Write("<script>alert('添加成功!');location.href='/Users/UsersList'</script>");
                }
                else
                {
                    us.Modify(ud);
                    Response.Write("<script>alert('修改成功!');location.href='/Users/UsersList'</script>");
                }

                return null;
            }
            return View(ud);
        }

        private List<SelectListItem> GetTypeList()
        {
            List<SelectListItem> sList = new List<SelectListItem>();
            sList.Add(new SelectListItem { Text = "管理员", Value = "管理员" });
            sList.Add(new SelectListItem { Text = "普通用户", Value = "普通用户" });
            return sList;
        }

    }
}
