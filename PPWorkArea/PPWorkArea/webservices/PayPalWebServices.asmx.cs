using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
// added using
using PayPal.Api;
using System.Web.Script.Services;
using PayPalClassObjects;
using PayPalCommonObject;

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
            var transaction = new Transaction()
            {
                amount = new Amount()
                {
                    currency = "USD",
                    total = "7",
                    details = new Details()
                    {
                        shipping = "1",
                        subtotal = "5",
                        tax = "1"
                    }
                },
                description = "This is the payment transaction description.",
                item_list = new ItemList()
                {
                    items = new List<Item>()
                    {
                        new Item()
                        {
                            name = "Item Name",
                            currency = "USD",
                            price = "1",
                            quantity = "5",
                            sku = "sku"
                        }
                    },
                    shipping_address = new ShippingAddress
                    {
                        city = "Johnstown",
                        country_code = "US",
                        line1 = "52 N Main ST",
                        postal_code = "43210",
                        state = "OH",
                        recipient_name = "Joe Buyer"
                    }
                },
                invoice_number = Common.GetRandomInvoiceNumber()

            };

            // A resource representing a Payer that funds a payment.
            var payer = new Payer()
            {
                payment_method = "credit_card",
                funding_instruments = new List<FundingInstrument>()
                {
                    new FundingInstrument()
                    {
                        credit_card = new CreditCard()
                        {
                            billing_address = new Address()
                            {
                                city = "Johnstown",
                                country_code = "US",
                                line1 = "52 N Main ST",
                                postal_code = "43210",
                                state = "OH"
                            },
                            cvv2 = "874",
                            expire_month = 12,
                            expire_year = 2019,
                            first_name = "Joe",
                            last_name = "Shopper",
                            number = "4032034110301861",
                            type = "visa"
                        }
                    }
                },
                payer_info = new PayerInfo
                {
                    email = "williamclaytonrose-buyer@gmail.com"            // NOT SURE WHICH TO USE
//                    email = "williamclaytonrose-facilitator@gmail.com"      // NOT SURE WHICH TO USE
                }
            };

            // A Payment resource; create one using the above types and intent as `sale` or `authorize`
            var payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = new List<Transaction>() { transaction }
            };

            #region Original attempt from PayPal sample
            //string rtnMsg = "Payment with a Credit Card of the amount: " + inAmt;
            //PaymentWithCreditCard payPalPmt = new PaymentWithCreditCard();

            //if (payPalPmt.ProcessPayment(transaction, payer, payment) != 0)
            //    rtnMsg = "Error processing PayPal Payment with Credit Card";

            //return rtnMsg;
            #endregion

            #region 2nd Attempt from the following URL: https://github.com/paypal/PayPal-NET-SDK/wiki/Make-Your-First-Call
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);
            apiContext.Config = ConfigManager.Instance.GetProperties();
            apiContext.Config["connectionTimeout"] = "1000";

            if (apiContext.HTTPHeaders == null)
            {
                apiContext.HTTPHeaders = new Dictionary<string, string>();
            }

            apiContext.HTTPHeaders["PmtWithCreditCard"] = "Payment With Credit Card";
            var paymenttest = Payment.Get(apiContext, "PAY-0XL713371A312273YKE2GCNI");
            return string.Empty;
            #endregion
        }
        #endregion
    }
}
