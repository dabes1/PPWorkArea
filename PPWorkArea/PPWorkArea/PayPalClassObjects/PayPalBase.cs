using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Added using
using PayPal.Api;
using PayPalUtilityObject;

namespace PayPalClassObjects
{
    public abstract class PayPalBase
    {
        #region Internal Objects
        private readonly string _token = string.Empty;
        private readonly string _clientId = string.Empty;
        private readonly string _clientSecret = string.Empty;
        private readonly APIContext _apiContext = null;
        protected RequestFlow flow;
        #endregion

        #region Constructors
        // constructors
        public PayPalBase()
        {
            if (string.IsNullOrEmpty(_token))
            {
                var config = GetConfig();
                _clientId = config["clientId"];
                _clientSecret = config["clientSecret"];
                _token = config["token"];
                _apiContext = new APIContext(string.IsNullOrEmpty(_token) ? GetAccessToken() : _token);
                _apiContext.Config = GetConfig();

                flow = new RequestFlow();
            }
        }

        public  PayPalBase(string inToken)
            : this()
        {
            _apiContext = null;
            _apiContext = new APIContext(inToken);
            _apiContext.Config = GetConfig();
        }
        #endregion

        // Create the configuration map that contains mode and other optional configuration details.
        public static Dictionary<string, string> GetConfig()
        {
            return ConfigManager.Instance.GetProperties();
        }


        private string GetAccessToken()
        {
            // ###AccessToken
            // Retrieve the access token from
            // OAuthTokenCredential by passing in
            // ClientID and ClientSecret
            // It is not mandatory to generate Access Token on a per call basis.
            // Typically the access token can be generated once and
            // reused within the expiry window                
            string accessToken = new OAuthTokenCredential(_clientId, _clientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }



        protected APIContext GetApiContext()
        {
            return _apiContext;
        }

        #region Common Functions
        public virtual int ProcessPayment(Transaction inTran, Payer inPayer, Payment inPayment)
        {
            return 0;
        }
        #endregion

    }
}