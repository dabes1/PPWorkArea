<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConnectToSQL.aspx.cs" Inherits="PPWorkArea.Pages.ConnectToSQL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="scriptManager2">
            <Scripts>
                <asp:ScriptReference Path="~/scripts/ConnectToSQL.js" />
            </Scripts>
            <Services>
                <asp:ServiceReference Path="~/webservices/SQLDatabaseServices.asmx" /> 
            </Services>
        </asp:ScriptManager>

        <div>
            <h1>Test Connection to SQL Server</h1>
        </div>
        <div>
            <input type="button" class="buttonStd" value="Connect" onclick="connectToSQLDB()" />
        </div>

    </form>
</body>
</html>
