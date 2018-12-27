using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using serviceTest;
using Sygole;

namespace serviceTest
{
    public class Person
    {
        public string Name { get; set; }
    }
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    /// 
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        //这种方式获取的是soap格式的内容
        [WebMethod]
        public string HelloWorld()
        {
            //return new ServiceTest().helloWorld();
            return "receive msg";
        }

        [WebMethod(Description = "测试方法")]
        public string ProcessPersonalInfo(string name, int age)
        {
            return "my name " + name +" my age " + age;
        }

        [WebMethod]
        public void getJson()
        {
            Context.Response.Charset = "utf-8"; //设置字符集类型  
            Context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Context.Response.Write("{hello: 123}");
            Context.Response.End();
        }

        //C#动态库调用32/64？
        [WebMethod]
        public string ModubusRead()
        {
            bool result = new Sygole.HFModbus.ModbusAPI().CreateMast("192.168.1.8:200", 115200);
            return result.ToString();
        }

        //C++动态库调用
        [WebMethod]
        public string add()
        {
            int result = CPlusFunc.add(123, 456);
            return result.ToString();
        }
    }
}
