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

        #region constructors
        // constructors
        public PaymentWithCreditCard()
            : base()
        {
        }        

        public PaymentWithCreditCard(string inContext)
            : base(inContext)
        {
        }
        #endregion

        #region Functions
        //public new APIContext GetApiContext()
        //{
        //    return base.GetApiContext();
        //}

        public override int ProcessPayment(Transaction inTran, Payer inPayer, Payment inPayment)
        {
            try
            {
                // Track Workflow
                this.flow.AddNewRequest("Payment with a Credit Card", inPayment);

                // Create a payment using a validated APIContext
                var createdTestPayment = PayPal.Api.Payment.Create(GetApiContext(), inPayment);
                var createdPayment = inPayment.Create(GetApiContext());

                // Track Workflow
                this.flow.RecordResponse(createdPayment);

            }
            catch (Exception e)
            {

                return -1;
            }

            return 0;
        }
        #endregion
    }
}