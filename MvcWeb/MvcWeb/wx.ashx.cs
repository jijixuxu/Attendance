using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;


namespace MvcWeb
{
    /// <summary>
    /// wx 的摘要说明
    /// </summary>
    public class wx : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string opt = HttpContext.Current.Request.Params["opt"];
            switch (opt)
            {
                case "Login": getLogin(HttpContext.Current.Request.Params["userid"], HttpContext.Current.Request.Params["userpwrd"]); break;//获取单个用户
                case "Users": getUsers(HttpContext.Current.Request.Params["id"]); break;//获取单个用户
                case "UsersList": getUsersList(); break;//根据条件获取用户列表
                case "UsersEdit": getUsersEdit(HttpContext.Current.Request.Params["Id"], HttpContext.Current.Request.Params["userid"], HttpContext.Current.Request.Params["userpwrd"], HttpContext.Current.Request.Params["username"], HttpContext.Current.Request.Params["usertype"]); break;// 操作用户信息
                case "UsersDelete": getUsersDelete(HttpContext.Current.Request.Params["id"]); break;//删除用户信息
                case "Attendance": getAttendance(HttpContext.Current.Request.Params["timestamp"], HttpContext.Current.Request.Params["checkType"], HttpContext.Current.Request.Params["location"], HttpContext.Current.Request.Params["address"], HttpContext.Current.Request.Params["user"], HttpContext.Current.Request.Params["geo"]); break;//签到
                case "AttendanceList": getAttendanceList(HttpContext.Current.Request.Params["userid"]); break;//根据条件获取签到列表
                case "Forleave": getForleave(HttpContext.Current.Request.Params["user"], HttpContext.Current.Request.Params["date"], HttpContext.Current.Request.Params["reason"], HttpContext.Current.Request.Params["time"], HttpContext.Current.Request.Params["memo"]); break;//获取单个用户
                case "ForleaveList": getForleaveList(HttpContext.Current.Request.Params["userid"]); break;//根据条件获取用户列表
                case "CouresList": getCouresList(); break;//根据条件获取用户列表

            }

        }

        public void getLogin(string userid, string userpwrd)
        {
            string strJson;
            Business.users us = new Business.users();
            bool b = us.Login(userid, userpwrd);
            if (b)
            {
                strJson = "{\"status\":0}";
            }
            else
            {
                strJson = "{\"status\":" + us.ErrMsg + "}";
            }
            HttpContext.Current.Response.Write(strJson);
            HttpContext.Current.Response.End();
        }

        public void getUsers(string id)
        {
            Business.users us = new Business.users();
            string strJson = GetJson(us.Select(string.Format(" and id ={0}", id)));
            strJson = strJson.Substring(1, strJson.Length - 2);
            HttpContext.Current.Response.Write(strJson);
            HttpContext.Current.Response.End();
        }

        public void getAttendance(string timestamp, string checkType, string location, string address, string user, string geo)
        {
            Business.attendance attendance = new Business.attendance();
            MvcModel.attendanceData ad = new MvcModel.attendanceData();
            ad.userid = user;
            ad.checktime = timestamp;
            ad.checktype = checkType;
            ad.checkaddress = address;
            attendance.Insert(ad);

            string strJson;
            strJson = "{\"status\":0}";
            HttpContext.Current.Response.Write(strJson);
            HttpContext.Current.Response.End();
        }

        public void getForleave(string user, string date, string reason, string time, string memo)
        {
            Business.forleave forleave = new Business.forleave();
            MvcModel.forleaveData fd = new MvcModel.forleaveData();

            //userid,thetime,starttime,endtime,thetype,memos,status
            fd.userid = user;
            fd.thetime = date;
            fd.starttime = time;
            fd.endtime = time;
            fd.thetype = reason;
            fd.memos = memo;
            fd.status = "申请中";
            forleave.Insert(fd);

            string strJson;
            strJson = "{\"status\":0}";
            HttpContext.Current.Response.Write(strJson);
            HttpContext.Current.Response.End();
        }


        public void getUsersList()
        {
            Business.users us = new Business.users();
            string strJson = ConvertJson.ToJson(us.Get(""));
            HttpContext.Current.Response.Write(strJson);
            HttpContext.Current.Response.End();
        }

        public void getCouresList()
        {
            Business.coures us = new Business.coures();
            string strJson = ConvertJson.ToJson(us.Get(""));
            HttpContext.Current.Response.Write(strJson);
            HttpContext.Current.Response.End();
        }

        public void getAttendanceList(string userid)
        {
            Business.attendance us = new Business.attendance();
            string strJson = ConvertJson.ToJson(us.Get(string.Format(" and userid ='{0}'", userid)));
            HttpContext.Current.Response.Write(strJson);
            HttpContext.Current.Response.End();
        }

        public void getForleaveList(string userid)
        {
            Business.forleave us = new Business.forleave();
            string strJson = ConvertJson.ToJson(us.Get(string.Format(" and userid ='{0}'", userid)));
            HttpContext.Current.Response.Write(strJson);
            HttpContext.Current.Response.End();
        }


        public void getUsersEdit(string Id, string userid, string userpwrd, string username, string usertype)
        {
            Business.users us = new Business.users();
            MvcModel.usersData ud = new MvcModel.usersData();
            if (Id != null && Id != "")
            {
                ud.Id = Id;
                ud.userid = userid;
                ud.userpwrd = userpwrd;
                ud.username = username;
                ud.usertype = usertype;
                us.Modify(ud);
            }
            else
            {
                ud.userid = userid;
                ud.userpwrd = userpwrd;
                ud.username = username;
                ud.usertype = usertype;
                us.Insert(ud);
            }

            string strJson = "{\"status\":0}";
            HttpContext.Current.Response.Write(strJson);
            HttpContext.Current.Response.End();
        }

        public void getUsersDelete(string id)
        {
            Business.users us = new Business.users();
            us.Delete(id);
            string strJson = ConvertJson.ToJson(us.Get(""));
            HttpContext.Current.Response.Write(strJson);
            HttpContext.Current.Response.End();
        }

        public void postMessage()
        {
            string strJson = "{\"status\":0}";
            HttpContext.Current.Response.Write(strJson);
            HttpContext.Current.Response.End();
        }

        #region  把对象序列化 JSON 字符串
        /// <summary>
        /// 把对象序列化 JSON 字符串 
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">对象实体</param>
        /// <returns>JSON字符串</returns>
        public static string GetJson<T>(T obj)
        {
            //记住 添加引用 System.ServiceModel.Web 
            /**
             * 如果不添加上面的引用,System.Runtime.Serialization.Json; Json是出不来的哦
             * */
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                json.WriteObject(ms, obj);
                string szJson = Encoding.UTF8.GetString(ms.ToArray());
                return szJson;

            }

        }
        #endregion


        #region  DataSet Datatable转换为Json

        public static class ConvertJson
        {
            #region  DataSet转换为Json

            /// <summary>           
            /// DataSet转换为Json     
            /// </summary>       
            /// <param name="dataSet">DataSet对象</param>
            /// <returns>Json字符串</returns>  
            public static string ToJson(DataSet dataSet)
            {
                string jsonString = "{\"status\":0,";
                foreach (DataTable table in dataSet.Tables)
                {
                    jsonString += "\"" + table.TableName + "\":" + ToJson(table) + ",";
                }
                jsonString = jsonString.TrimEnd(',');
                return jsonString + "}";
            }
            #endregion

            #region Datatable转换为Json

            /// <summary>   
            /// Datatable转换为Json 
            /// </summary>      
            /// <param name="table">Datatable对象</param>
            /// <returns>Json字符串</returns>    
            public static string ToJson(DataTable dt)
            {
                StringBuilder jsonString = new StringBuilder();
                jsonString.Append("[");
                DataRowCollection drc = dt.Rows;
                for (int i = 0; i < drc.Count; i++)
                {
                    jsonString.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string strKey = dt.Columns[j].ColumnName;
                        string strValue = drc[i][j].ToString();
                        Type type = dt.Columns[j].DataType;
                        jsonString.Append("\"" + strKey + "\":");
                        strValue = StringFormat(strValue, type);
                        if (j < dt.Columns.Count - 1)
                        {
                            jsonString.Append(strValue + ",");
                        }
                        else
                        {
                            jsonString.Append(strValue);
                        }
                    }
                    jsonString.Append("},");
                }
                jsonString.Remove(jsonString.Length - 1, 1);
                jsonString.Append("]");
                return jsonString.ToString();
            }

            /// <summary>  
            /// DataTable转换为Json 
            /// </summary>    
            public static string ToJson(DataTable dt, string jsonName)
            {
                StringBuilder Json = new StringBuilder();
                if (string.IsNullOrEmpty(jsonName))
                    jsonName = dt.TableName;
                Json.Append("{\"" + jsonName + "\":[");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Json.Append("{");
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            Type type = dt.Rows[i][j].GetType();
                            Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + StringFormat(dt.Rows[i][j].ToString(), type));
                            if (j < dt.Columns.Count - 1)
                            {
                                Json.Append(",");
                            }
                        }
                        Json.Append("}");
                        if (i < dt.Rows.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                }
                Json.Append("]}");
                return Json.ToString();
            }

            #endregion

            /// <summary>     
            /// 格式化字符型、日期型、布尔型 
            /// </summary>     
            /// <param name="str"></param>   
            /// <param name="type"></param> 
            /// <returns></returns>     
            private static string StringFormat(string str, Type type)
            {
                if (type == typeof(string))
                {
                    str = String2Json(str);
                    str = "\"" + str + "\"";
                }
                else if (type == typeof(DateTime))
                {
                    str = "\"" + str + "\"";
                }
                else if (type == typeof(bool))
                {
                    str = str.ToLower();
                }
                else if (type != typeof(string) && string.IsNullOrEmpty(str))
                {
                    str = "\"" + str + "\"";
                }
                return str;
            }

            #region 私有方法
            /// <summary>     
            /// 过滤特殊字符    
            /// </summary>    
            /// <param name="s">字符串</param> 
            /// <returns>json字符串</returns> 
            private static string String2Json(String s)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < s.Length; i++)
                {
                    char c = s.ToCharArray()[i];
                    switch (c)
                    {
                        case '\"':
                            sb.Append("\\\""); break;
                        case '\\':
                            sb.Append("\\\\"); break;
                        case '/':
                            sb.Append("\\/"); break;
                        case '\b':
                            sb.Append("\\b"); break;
                        case '\f':
                            sb.Append("\\f"); break;
                        case '\n':
                            sb.Append("\\n"); break;
                        case '\r':
                            sb.Append("\\r"); break;
                        case '\t':
                            sb.Append("\\t"); break;
                        default:
                            sb.Append(c); break;
                    }
                }
                return sb.ToString();
            }
            #endregion
        }
        #endregion


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}