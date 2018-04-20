using System;
using System.ComponentModel.DataAnnotations; //验证js
namespace MvcModel
{
public class attendanceData
{
private int m_Id;
private string m_userid;
private string m_checktime;
private string m_checkaddress;
private string m_checktype;

public int Id
{
get { return this.m_Id; }
set { this.m_Id = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string userid
{
get { return this.m_userid ;}
set { this.m_userid = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string checktime
{
get { return this.m_checktime ;}
set { this.m_checktime = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string checkaddress
{
get { return this.m_checkaddress ;}
set { this.m_checkaddress = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string checktype
{
get { return this.m_checktype ;}
set { this.m_checktype = value; }
}
}}
