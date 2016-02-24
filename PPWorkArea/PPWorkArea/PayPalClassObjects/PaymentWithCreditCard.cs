using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Added using
using PayPal.Api;

namespace PayPalClassObjects
{
    public class PaymentWithCreditCard : PayPalBase
    {


        // constructor
        public PaymentWithCreditCard(string inContext)
            : base(inContext)
        {
        }

        public new APIContext GetApiContext()
        {
            return base.GetApiContext();
        }

    }
}