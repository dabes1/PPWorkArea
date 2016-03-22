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
                <asp:ServiceReference Path="~/webservices/WorkArea.asmx" /> 
            </Services>
        </asp:ScriptManager>

        <div>
            <h1>Test input type=file</h1>
        </div>
        <div>
            <input type="file" style="align-items:baseline; text-align:start;" accept="*.xls" value="Connect" onclick="loadfile()" />
        </div>


    </div>
    </form>
</body>
</html>
