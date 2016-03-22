using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
// added usings
using System.Web.Script.Services;

namespace PPWorkArea.webservices
{
    /// <summary>
    /// Summary description for WorkAreaWebServices
    /// </summary>
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WorkAreaWebServices : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
