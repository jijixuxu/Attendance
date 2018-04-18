using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Controllers
{
    public class CouresController : Controller
    {
        Business.coures coures = new Business.coures();

        //显示所有数据
        public ActionResult CouresList()
        {
            return View(coures.Get(""));
        }

        //根据ID删除该列数据
        public ActionResult CouresDelete(string id)
        {
            coures.Delete(id);
            Response.Write("<script>alert('删除成功!');location.href='/Coures/CouresList'</script>");
            return null;
        }

        //根据ID导出该列数据
        public ActionResult CouresEdit(string id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                MvcModel.couresData couresdata = coures.SelectData(string.Format(" and id = {0}", id));
                return View(couresdata);
            }
        }

        //添加或者修改该列数据
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CouresEdit(MvcModel.couresData couresdata)
        {
            if (ModelState.IsValid)
            {
                if (couresdata.Id == 0)
                {
                    coures.Insert(couresdata);
                    Response.Write("<script>alert('添加成功!');location.href='/coures/couresList'</script>");
                }
                else
                {
                    coures.Modify(couresdata);
                    Response.Write("<script>alert('修改成功!');location.href='/coures/couresList'</script>");
                }

                return null;
            }
            return View(couresdata);
        }

        //显示所有数据-前台
        public ActionResult HomeCouresList()
        {
            return View(coures.Get(""));
        }

        //根据ID删除该列数据
        public ActionResult HomeCouresDelete(string id)
        {
            coures.Delete(id);
            Response.Write("<script>alert('删除成功!');location.href='/Coures/HomeCouresList'</script>");
            return null;
        }

        //根据ID导出该列数据
        public ActionResult HomeCouresEdit(string id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                MvcModel.couresData couresdata = coures.SelectData(string.Format(" and id = {0}", id));
                return View(couresdata);
            }
        }

        //添加或者修改该列数据
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult HomeCouresEdit(MvcModel.couresData couresdata)
        {
            if (ModelState.IsValid)
            {
                if (couresdata.Id == null)
                {
                    coures.Insert(couresdata);
                    Response.Write("<script>alert('添加成功!');location.href='/Coures/HomeCouresList'</script>");
                }
                else
                {
                    coures.Modify(couresdata);
                    Response.Write("<script>alert('修改成功!');location.href='/Coures/HomeCouresList'</script>");
                }

                return null;
            }
            return View(couresdata);
        }

    }
}
