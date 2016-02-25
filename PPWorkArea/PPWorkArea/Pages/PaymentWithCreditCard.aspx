<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentWithCreditCard.aspx.cs" Inherits="PPWorkArea.Pages.PaymentWithCreditCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment With A Credit Card</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server" ID="scriptManager">
            <Scripts>
                <asp:ScriptReference Path="~/scripts/PaymentWithCreditCard.js" />
            </Scripts>
            <Services>
                <asp:ServiceReference Path="~/webservices/PayPalWebServices.asmx" />
            </Services>
        </asp:ScriptManager>

        <div>
            <h1>Payment with Credit Card</h1>
        </div>
        <div>
            <p style="display:inline">Enter Payment Amount:</p>
            <input id="inputPayment" type="text" class="inputTextStd" style="display:inline" />
            <input type="button" class="buttonStd" value="Submit" onclick="submitPayment()" />
        </div>

    </form>
</body>
</html>
