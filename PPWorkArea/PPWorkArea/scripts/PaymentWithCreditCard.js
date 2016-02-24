var submitPayment = function () {
    PPWorkArea.webservices.PayPalWebServices.PaymentWithCreditCard(document.getElementById("inputPayment").value, paymentCallbackfunction);
}

function paymentCallbackfunction(input) {
    alert("Function executed: " + input);
}
