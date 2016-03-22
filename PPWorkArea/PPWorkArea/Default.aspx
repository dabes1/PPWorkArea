<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PPWorkArea.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PayPal Test Application</title>
    <link href="css/StandardStyles.css" rel="stylesheet" type="text/css" />
    <script src="scripts/Default.js" ></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <div>
            <h1>This launches the tester Application for PayPal processing.</h1>
            <input class="buttonStd" type="button" value="Launch" onclick="payWithCreditCard()" />
            <label class="labelStd">Payment with Credit Card</label>
        </div>

        <div>
            <h1>This launches a page to test your current SQL DB connection</h1>
            <div>
                <input class="buttonStd" type="button" value="Launch" onclick="launchSQLConnectionTest()" />
                <label class="labelStd">Test the SQL Connection</label>
            </div>
        </div>

        <div>
            <h1>This launches ASP.NET/HTML WorkArea page</h1>
            <div>
                <input class="buttonStd" type="button" value="Launch" onclick="launchWorkArea()" />
                <label class="labelStd">WorkArea is for testing any kind of stuff!!</label>
            </div>
        </div>


        <div>


        </div>
    
    </div>
    </form>
</body>
</html>
