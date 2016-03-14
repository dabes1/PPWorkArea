using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
// added using
using System.Data;
using PPWorkArea.ClassObjects;
using System.Web.Script.Services;

//namespace SQLDataBase.webservices
namespace PPWorkArea.webservices
//namespace PPWorkArea.SQLDB.webservices
{
    /// <summary>
    /// Summary description for SQLDatabaseServices
    /// </summary>
    [ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    public class SQLDatabaseServices : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }



        [WebMethod(EnableSession = true)]
        public int ConnectToSQLDB()
        {
            Class1 cls = new Class1();
            DataTable dt = cls.RetrieveData();

            return 0;
        }

    }
}
