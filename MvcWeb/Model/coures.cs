using System;
using System.ComponentModel.DataAnnotations;
namespace MvcModel
{
public class couresData
{
private int m_Id;
private string m_coursename;
private string m_theter;
private string m_theaddress;
private string m_thetime;
private string m_thexs;
private string m_thexf;
private string m_memos;

public int Id
{
get { return this.m_Id; }
set { this.m_Id = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string coursename
{
get { return this.m_coursename ;}
set { this.m_coursename = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string theter
{
get { return this.m_theter ;}
set { this.m_theter = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string theaddress
{
get { return this.m_theaddress ;}
set { this.m_theaddress = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string thetime
{
get { return this.m_thetime ;}
set { this.m_thetime = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string thexs
{
get { return this.m_thexs ;}
set { this.m_thexs = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string thexf
{
get { return this.m_thexf ;}
set { this.m_thexf = value; }
}
[DisplayFormat(ConvertEmptyStringToNull = false)]
public string memos
{
get { return this.m_memos ;}
set { this.m_memos = value; }
}
}}
