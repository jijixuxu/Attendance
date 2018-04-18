using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Controllers
{
    public class AttendanceController : Controller
    {
        Business.attendance attendance = new Business.attendance();

        //显示所有数据
        public ActionResult AttendanceList()
        {
            return View(attendance.Get(""));
        }

        //根据ID删除该列数据
        public ActionResult AttendanceDelete(string id)
        {
            attendance.Delete(id);
            Response.Write("<script>alert('删除成功!');location.href='/Attendance/AttendanceList'</script>");
            return null;
        }

        //根据ID导出该列数据
        public ActionResult AttendanceEdit(string id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                MvcModel.attendanceData attendancedata = attendance.SelectData(string.Format(" and id = {0}", id));
                return View(attendancedata);
            }
        }

        //添加或者修改该列数据
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AttendanceEdit(MvcModel.attendanceData attendancedata)
        {
            if (ModelState.IsValid)
            {
                if (attendancedata.Id == 0)
                {
                    attendance.Insert(attendancedata);
                    Response.Write("<script>alert('添加成功!');location.href='/attendance/attendanceList'</script>");
                }
                else
                {
                    attendance.Modify(attendancedata);
                    Response.Write("<script>alert('修改成功!');location.href='/attendance/attendanceList'</script>");
                }

                return null;
            }
            return View(attendancedata);
        }

        //显示所有数据-前台
        public ActionResult HomeAttendanceList()
        {
            return View(attendance.Get(""));
        }

        //根据ID删除该列数据
        public ActionResult HomeAttendanceDelete(string id)
        {
            attendance.Delete(id);
            Response.Write("<script>alert('删除成功!');location.href='/Attendance/HomeAttendanceList'</script>");
            return null;
        }

        //根据ID导出该列数据
        public ActionResult HomeAttendanceEdit(string id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                MvcModel.attendanceData attendancedata = attendance.SelectData(string.Format(" and id = {0}", id));
                return View(attendancedata);
            }
        }

        //添加或者修改该列数据
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult HomeAttendanceEdit(MvcModel.attendanceData attendancedata)
        {
            if (ModelState.IsValid)
            {
                if (attendancedata.Id == null)
                {
                    attendance.Insert(attendancedata);
                    Response.Write("<script>alert('添加成功!');location.href='/Attendance/HomeAttendanceList'</script>");
                }
                else
                {
                    attendance.Modify(attendancedata);
                    Response.Write("<script>alert('修改成功!');location.href='/Attendance/HomeAttendanceList'</script>");
                }

                return null;
            }
            return View(attendancedata);
        }

    }
}
