using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Added using
using PayPal.Api;

namespace PayPalClassObjects
{
    public abstract class PayPalBase
    {
        // private internal objects
        protected readonly string _accessToken = string.Empty;
        protected readonly APIContext _apiContext = null;

        // constructor
        public PayPalBase(string inContext)
        {
            if (string.IsNullOrEmpty(_accessToken))
            {
            }
        }

        protected APIContext GetApiContext()
        {
            return _apiContext;
        }

    }
}