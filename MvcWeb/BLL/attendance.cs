using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Business
{

public class attendance
{public bool Insert(MvcModel.attendanceData datattendance)
{
int iRel = -1;
bool bRel = false;
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
try
{
objDB.OpenConnection();
string strSql =" insert into attendance (userid,checktime,checkaddress,checktype)  values (@userid,@checktime,@checkaddress,@checktype) ";
objDB.Command.CommandType = System.Data.CommandType.Text;
objDB.Command.CommandText = strSql;
objDB.Command.Parameters.AddWithValue("@userid",datattendance.userid);
objDB.Command.Parameters.AddWithValue("@checktime",datattendance.checktime);
objDB.Command.Parameters.AddWithValue("@checkaddress",datattendance.checkaddress);
objDB.Command.Parameters.AddWithValue("@checktype",datattendance.checktype);
iRel = objDB.Command.ExecuteNonQuery();
}
 catch (Exception ex)
{
   iRel = -1;
}
 objDB.CloseConnection();
objDB.Dispose();
objDB = null;
bRel = (iRel.Equals(1) ? true : false);
return bRel;
}
public bool Modify(MvcModel.attendanceData datattendance)
{
int iRel = -1;
bool bRel = false;
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
try { objDB.OpenConnection();
string strSql = "update attendance set userid=@userid,checktime=@checktime,checkaddress=@checkaddress,checktype=@checktype where Id = @Id";
objDB.Command.CommandType = System.Data.CommandType.Text;
objDB.Command.CommandText = strSql;
objDB.Command.Parameters.AddWithValue("@userid",datattendance.userid);
objDB.Command.Parameters.AddWithValue("@checktime",datattendance.checktime);
objDB.Command.Parameters.AddWithValue("@checkaddress",datattendance.checkaddress);
objDB.Command.Parameters.AddWithValue("@checktype",datattendance.checktype);
objDB.Command.Parameters.AddWithValue("@Id", datattendance.Id);
iRel = objDB.Command.ExecuteNonQuery();
}
catch (Exception ex)
{iRel = -1;}
objDB.CloseConnection();
objDB.Dispose();
objDB = null;
bRel = (iRel.Equals(1) ? true : false);return bRel;
}
public bool Delete(string Id)
{
int iRel = -1;
bool bRel = false;
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
try
{
objDB.OpenConnection();
string strSql = "delete from attendance where Id=" + Id + "";
objDB.Command.CommandType = System.Data.CommandType.Text;
objDB.Command.CommandText = strSql;
iRel = objDB.Command.ExecuteNonQuery();
}
catch (Exception ex)
 {
iRel = -1;
}
objDB.CloseConnection();
objDB.Dispose();
objDB = null;
bRel = (iRel.Equals(1) ? true : false);
return bRel;
}

public MvcModel.attendanceData[] Select(string casestr)
{
int iRel = -1;
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
MvcModel.attendanceData[] datattendance = new MvcModel.attendanceData[1];
string sql = "select * from attendance where 1= 1  ";
sql += casestr;
try
{
objDB.OpenConnection();
DataSet ds = objDB.QueryData(sql, "departmentinfo");
if (ds.Tables.Count > 0)
{
long nRow = ds.Tables[0].Rows.Count;
if (nRow > 0)
{
datattendance = new MvcModel.attendanceData[nRow];
for (int i = 0; i < nRow; i++)
{
datattendance[i] = new MvcModel.attendanceData();
datattendance[i].userid = ds.Tables[0].Rows[i]["userid"].ToString();
datattendance[i].checktime = ds.Tables[0].Rows[i]["checktime"].ToString();
datattendance[i].checkaddress = ds.Tables[0].Rows[i]["checkaddress"].ToString();
datattendance[i].checktype = ds.Tables[0].Rows[i]["checktype"].ToString();
}
}
}
}
catch (Exception ex)
{
iRel = -1;
}
objDB.CloseConnection();
objDB.Dispose();
objDB = null;
return datattendance;
}
public MvcModel.attendanceData SelectData(string casestr)
{
int iRel = -1;
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
MvcModel.attendanceData datattendance = new MvcModel.attendanceData();
string sql = "select * from attendance where 1= 1  ";
sql += casestr;
try
{
objDB.OpenConnection();
DataSet ds = objDB.QueryData(sql, "departmentinfo");
if (ds.Tables.Count > 0)
{
long nRow = ds.Tables[0].Rows.Count;
if (nRow > 0)
{
for (int i = 0; i < nRow; i++)
{
datattendance.userid = ds.Tables[0].Rows[i]["userid"].ToString();
datattendance.checktime = ds.Tables[0].Rows[i]["checktime"].ToString();
datattendance.checkaddress = ds.Tables[0].Rows[i]["checkaddress"].ToString();
datattendance.checktype = ds.Tables[0].Rows[i]["checktype"].ToString();
}
}
}
}
catch (Exception ex)
{
iRel = -1;
}
objDB.CloseConnection();
objDB.Dispose();
objDB = null;
return datattendance;
}
public DataTable Get(string casestr)
{
DataTable dt = new DataTable();
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
string sql = "select * from attendance where 1 = 1 ";
sql += casestr;
objDB.OpenConnection();
dt = objDB.QueryDataTable(sql, "tabname");
objDB.CloseConnection();
objDB.Dispose();
objDB = null;
return dt;
}
public int CalcCountSearch(string casestr)
{
DataTable dt = new DataTable();
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
string sql = "select count (1)  from attendance where id > 0";
sql += casestr;
objDB.OpenConnection();
dt = objDB.QueryDataTable(sql, "tabname");
objDB.CloseConnection();
objDB.Dispose();
objDB = null;
return (dt == null) ? 0 : int.Parse(dt.Rows[0][0].ToString());
}
public DataTable SelectAllFenyeSearch(int pagesize, int pageindex, string casestr)
{
DataTable dt = new DataTable();
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
string sql = "";
if ((pageindex - 1) * pagesize == 0)
{
sql = "select top " + pagesize + " * from attendance where id > 0 " + casestr + " order by id desc";
}
else
{
sql = "select top " + pagesize + " * from attendance where id not in (select top " + (pageindex - 1) * pagesize + " id from attendance order by id desc) " + casestr + " order by id desc";
}
objDB.OpenConnection();
dt = objDB.QueryDataTable(sql, "tabname");
objDB.CloseConnection();
objDB.Dispose();
objDB = null;
return dt;
}
}
}
