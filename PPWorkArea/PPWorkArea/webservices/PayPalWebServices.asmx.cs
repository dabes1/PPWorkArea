using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
// added using
using System.Web.Script.Services;

namespace PPWorkArea.webservices
{
    /// <summary>
    /// Summary description for PayPalWebServices
    /// </summary>
    [ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    public class PayPalWebServices : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession = true)]
        public string PaymentWithCreditCard(string inAmt)
        {
            return "Payment with a Credit Card of the amount: " + inAmt;
        }
    }
}
