using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Business
{

public class forleave
{public bool Insert(MvcModel.forleaveData datforleave)
{
int iRel = -1;
bool bRel = false;
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
try
{
objDB.OpenConnection();
string strSql =" insert into forleave (userid,thetime,starttime,endtime,thetype,memos,status)  values (@userid,@thetime,@starttime,@endtime,@thetype,@memos,@status) ";
objDB.Command.CommandType = System.Data.CommandType.Text;
objDB.Command.CommandText = strSql;
objDB.Command.Parameters.AddWithValue("@userid",datforleave.userid);
objDB.Command.Parameters.AddWithValue("@thetime",datforleave.thetime);
objDB.Command.Parameters.AddWithValue("@starttime",datforleave.starttime);
objDB.Command.Parameters.AddWithValue("@endtime",datforleave.endtime);
objDB.Command.Parameters.AddWithValue("@thetype",datforleave.thetype);
objDB.Command.Parameters.AddWithValue("@memos",datforleave.memos);
objDB.Command.Parameters.AddWithValue("@status",datforleave.status);
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
public bool Modify(MvcModel.forleaveData datforleave)
{
int iRel = -1;
bool bRel = false;
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
try { objDB.OpenConnection();
string strSql = "update forleave set userid=@userid,thetime=@thetime,starttime=@starttime,endtime=@endtime,thetype=@thetype,memos=@memos,status=@status where Id = @Id";
objDB.Command.CommandType = System.Data.CommandType.Text;
objDB.Command.CommandText = strSql;
objDB.Command.Parameters.AddWithValue("@userid",datforleave.userid);
objDB.Command.Parameters.AddWithValue("@thetime",datforleave.thetime);
objDB.Command.Parameters.AddWithValue("@starttime",datforleave.starttime);
objDB.Command.Parameters.AddWithValue("@endtime",datforleave.endtime);
objDB.Command.Parameters.AddWithValue("@thetype",datforleave.thetype);
objDB.Command.Parameters.AddWithValue("@memos",datforleave.memos);
objDB.Command.Parameters.AddWithValue("@status",datforleave.status);
objDB.Command.Parameters.AddWithValue("@Id", datforleave.Id);
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
string strSql = "delete from forleave where Id=" + Id + "";
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

public MvcModel.forleaveData[] Select(string casestr)
{
int iRel = -1;
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
MvcModel.forleaveData[] datforleave = new MvcModel.forleaveData[1];
string sql = "select * from forleave where 1= 1  ";
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
datforleave = new MvcModel.forleaveData[nRow];
for (int i = 0; i < nRow; i++)
{
datforleave[i] = new MvcModel.forleaveData();
datforleave[i].userid = ds.Tables[0].Rows[i]["userid"].ToString();
datforleave[i].thetime = ds.Tables[0].Rows[i]["thetime"].ToString();
datforleave[i].starttime = ds.Tables[0].Rows[i]["starttime"].ToString();
datforleave[i].endtime = ds.Tables[0].Rows[i]["endtime"].ToString();
datforleave[i].thetype = ds.Tables[0].Rows[i]["thetype"].ToString();
datforleave[i].memos = ds.Tables[0].Rows[i]["memos"].ToString();
datforleave[i].status = ds.Tables[0].Rows[i]["status"].ToString();
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
return datforleave;
}
public MvcModel.forleaveData SelectData(string casestr)
{
int iRel = -1;
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
MvcModel.forleaveData datforleave = new MvcModel.forleaveData();
string sql = "select * from forleave where 1= 1  ";
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
datforleave.userid = ds.Tables[0].Rows[i]["userid"].ToString();
datforleave.thetime = ds.Tables[0].Rows[i]["thetime"].ToString();
datforleave.starttime = ds.Tables[0].Rows[i]["starttime"].ToString();
datforleave.endtime = ds.Tables[0].Rows[i]["endtime"].ToString();
datforleave.thetype = ds.Tables[0].Rows[i]["thetype"].ToString();
datforleave.memos = ds.Tables[0].Rows[i]["memos"].ToString();
datforleave.status = ds.Tables[0].Rows[i]["status"].ToString();
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
return datforleave;
}
public DataTable Get(string casestr)
{
DataTable dt = new DataTable();
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
string sql = "select * from forleave where 1 = 1 ";
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
string sql = "select count (1)  from forleave where id > 0";
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
sql = "select top " + pagesize + " * from forleave where id > 0 " + casestr + " order by id desc";
}
else
{
sql = "select top " + pagesize + " * from forleave where id not in (select top " + (pageindex - 1) * pagesize + " id from forleave order by id desc) " + casestr + " order by id desc";
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
