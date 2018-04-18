using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Controllers
{
    public class ForleaveController : Controller
    {
        Business.forleave forleave = new Business.forleave();

        //显示所有数据
        public ActionResult ForleaveList()
        {
            return View(forleave.Get(""));
        }

        //根据ID删除该列数据
        public ActionResult ForleaveDelete(string id)
        {
            forleave.Delete(id);
            Response.Write("<script>alert('删除成功!');location.href='/Forleave/ForleaveList'</script>");
            return null;
        }

        //根据ID导出该列数据
        public ActionResult ForleaveEdit(string id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                MvcModel.forleaveData forleavedata = forleave.SelectData(string.Format(" and id = {0}", id));
                return View(forleavedata);
            }
        }

        //添加或者修改该列数据
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ForleaveEdit(MvcModel.forleaveData forleavedata)
        {
            if (ModelState.IsValid)
            {
                if (forleavedata.Id == 0)
                {
                    forleave.Insert(forleavedata);
                    Response.Write("<script>alert('添加成功!');location.href='/forleave/forleaveList'</script>");
                }
                else
                {
                    forleave.Modify(forleavedata);
                    Response.Write("<script>alert('修改成功!');location.href='/forleave/forleaveList'</script>");
                }

                return null;
            }
            return View(forleavedata);
        }

        //显示所有数据-前台
        public ActionResult HomeForleaveList()
        {
            return View(forleave.Get(""));
        }

        //根据ID删除该列数据
        public ActionResult HomeForleaveDelete(string id)
        {
            forleave.Delete(id);
            Response.Write("<script>alert('删除成功!');location.href='/Forleave/HomeForleaveList'</script>");
            return null;
        }

        //根据ID导出该列数据
        public ActionResult HomeForleaveEdit(string id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                MvcModel.forleaveData forleavedata = forleave.SelectData(string.Format(" and id = {0}", id));
                return View(forleavedata);
            }
        }

        //添加或者修改该列数据
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult HomeForleaveEdit(MvcModel.forleaveData forleavedata)
        {
            if (ModelState.IsValid)
            {
                if (forleavedata.Id == null)
                {
                    forleave.Insert(forleavedata);
                    Response.Write("<script>alert('添加成功!');location.href='/Forleave/HomeForleaveList'</script>");
                }
                else
                {
                    forleave.Modify(forleavedata);
                    Response.Write("<script>alert('修改成功!');location.href='/Forleave/HomeForleaveList'</script>");
                }

                return null;
            }
            return View(forleavedata);
        }

    }
}
