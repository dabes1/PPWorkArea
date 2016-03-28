<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkArea.aspx.cs" Inherits="PPWorkArea.Pages.WorkArea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Work Area</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager runat="server" ID="scriptManagerWorkArea">
            <Scripts>
                <asp:ScriptReference Path="~/scripts/WorkArea.js" />
            </Scripts>
            <Services>
                <asp:ServiceReference Path="~/webservices/WorkAreaWebServices.asmx" /> 
            </Services>
        </asp:ScriptManager>

        <div>
            <h1>Test input type=file</h1>
        </div>
        <div>
            <input type="file" style="align-items:baseline; text-align:start;" accept="*.xls" value="Connect" onclick="loadfile()" />
        </div>


        <div>
            <h1>Test the external TestClassLibrary dll</h1>
            <div>
                <input type="button"  class="buttonStd" value="Display" onclick="DisplayClientID()" />
                <asp:TextBox runat="server" ID="tbxClientID" Height="20"></asp:TextBox>
             </div>
            <div>
                <input type="button"  class="buttonStd" value="Display" onclick="DisplaySecretID()" />
                <asp:TextBox runat="server" ID="tbxSecretID" Height="20"></asp:TextBox>
            </div>
        </div>

<%--        <iframe height="500" width="500" src="http://www.bengals.com">

        </iframe>--%>

    </div>
    </form>
</body>
</html>
