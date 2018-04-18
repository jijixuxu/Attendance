using System;
using System.ComponentModel.DataAnnotations;
namespace MvcModel
{
public class forleaveData
{
private int m_Id;
private string m_userid;
private string m_thetime;
private string m_starttime;
private string m_endtime;
private string m_thetype;
private string m_memos;
private string m_status;

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
public string thetime
{
get { return this.m_thetime ;}
set { this.m_thetime = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string starttime
{
get { return this.m_starttime ;}
set { this.m_starttime = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string endtime
{
get { return this.m_endtime ;}
set { this.m_endtime = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string thetype
{
get { return this.m_thetype ;}
set { this.m_thetype = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string memos
{
get { return this.m_memos ;}
set { this.m_memos = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string status
{
get { return this.m_status ;}
set { this.m_status = value; }
}
}}
