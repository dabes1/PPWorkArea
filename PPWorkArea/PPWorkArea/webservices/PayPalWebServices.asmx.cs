using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
// added using
using System.Web.Script.Services;
using PayPalClassObjects;

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


        #region Payment With Credit Card
        
        [WebMethod(EnableSession = true)]
        public string PaymentWithCreditCard(string inAmt)
        {
            PaymentWithCreditCard payPalPmt = new PaymentWithCreditCard("Tester");
            var apiContext = payPalPmt.GetApiContext();
 

            return "Payment with a Credit Card of the amount: " + inAmt;
        }
        #endregion
    }
}
