using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Business
{

public class coures
{public bool Insert(MvcModel.couresData datcoures)
{
int iRel = -1;
bool bRel = false;
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
try
{
objDB.OpenConnection();
string strSql =" insert into coures (coursename,theter,theaddress,thetime,thexs,thexf,memos)  values (@coursename,@theter,@theaddress,@thetime,@thexs,@thexf,@memos) ";
objDB.Command.CommandType = System.Data.CommandType.Text;
objDB.Command.CommandText = strSql;
objDB.Command.Parameters.AddWithValue("@coursename",datcoures.coursename);
objDB.Command.Parameters.AddWithValue("@theter",datcoures.theter);
objDB.Command.Parameters.AddWithValue("@theaddress",datcoures.theaddress);
objDB.Command.Parameters.AddWithValue("@thetime",datcoures.thetime);
objDB.Command.Parameters.AddWithValue("@thexs",datcoures.thexs);
objDB.Command.Parameters.AddWithValue("@thexf",datcoures.thexf);
objDB.Command.Parameters.AddWithValue("@memos",datcoures.memos);
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
public bool Modify(MvcModel.couresData datcoures)
{
int iRel = -1;
bool bRel = false;
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
try { objDB.OpenConnection();
string strSql = "update coures set coursename=@coursename,theter=@theter,theaddress=@theaddress,thetime=@thetime,thexs=@thexs,thexf=@thexf,memos=@memos where Id = @Id";
objDB.Command.CommandType = System.Data.CommandType.Text;
objDB.Command.CommandText = strSql;
objDB.Command.Parameters.AddWithValue("@coursename",datcoures.coursename);
objDB.Command.Parameters.AddWithValue("@theter",datcoures.theter);
objDB.Command.Parameters.AddWithValue("@theaddress",datcoures.theaddress);
objDB.Command.Parameters.AddWithValue("@thetime",datcoures.thetime);
objDB.Command.Parameters.AddWithValue("@thexs",datcoures.thexs);
objDB.Command.Parameters.AddWithValue("@thexf",datcoures.thexf);
objDB.Command.Parameters.AddWithValue("@memos",datcoures.memos);
objDB.Command.Parameters.AddWithValue("@Id", datcoures.Id);
iRel = objDB.Command.ExecuteNonQuery(); //返回受影响的行数
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
string strSql = "delete from coures where Id=" + Id + "";
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

public MvcModel.couresData[] Select(string casestr)
{
int iRel = -1;
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
MvcModel.couresData[] datcoures = new MvcModel.couresData[1];
string sql = "select * from coures where 1= 1  ";
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
datcoures = new MvcModel.couresData[nRow];
for (int i = 0; i < nRow; i++)
{
datcoures[i] = new MvcModel.couresData();
datcoures[i].coursename = ds.Tables[0].Rows[i]["coursename"].ToString();
datcoures[i].theter = ds.Tables[0].Rows[i]["theter"].ToString();
datcoures[i].theaddress = ds.Tables[0].Rows[i]["theaddress"].ToString();
datcoures[i].thetime = ds.Tables[0].Rows[i]["thetime"].ToString();
datcoures[i].thexs = ds.Tables[0].Rows[i]["thexs"].ToString();
datcoures[i].thexf = ds.Tables[0].Rows[i]["thexf"].ToString();
datcoures[i].memos = ds.Tables[0].Rows[i]["memos"].ToString();
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
return datcoures;
}
public MvcModel.couresData SelectData(string casestr)
{
int iRel = -1;
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
MvcModel.couresData datcoures = new MvcModel.couresData();
string sql = "select * from coures where 1= 1  ";
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
datcoures.coursename = ds.Tables[0].Rows[i]["coursename"].ToString();
datcoures.theter = ds.Tables[0].Rows[i]["theter"].ToString();
datcoures.theaddress = ds.Tables[0].Rows[i]["theaddress"].ToString();
datcoures.thetime = ds.Tables[0].Rows[i]["thetime"].ToString();
datcoures.thexs = ds.Tables[0].Rows[i]["thexs"].ToString();
datcoures.thexf = ds.Tables[0].Rows[i]["thexf"].ToString();
datcoures.memos = ds.Tables[0].Rows[i]["memos"].ToString();
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
return datcoures;
}
public DataTable Get(string casestr)
{
DataTable dt = new DataTable();
DataAccess.CommonDB objDB = new DataAccess.CommonDB();
string sql = "select * from coures where 1 = 1 ";
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
string sql = "select count (1)  from coures where id > 0";
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
sql = "select top " + pagesize + " * from coures where id > 0 " + casestr + " order by id desc";
}
else
{
sql = "select top " + pagesize + " * from coures where id not in (select top " + (pageindex - 1) * pagesize + " id from coures order by id desc) " + casestr + " order by id desc";
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
