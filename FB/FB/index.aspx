<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FB.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    HTML:<br />
    <asp:TextBox ID="fbMsg" runat="server" /><br />
    <asp:Button ID="btnSubmit" runat="server" OnClick="PostToFaceBook" />
    </div>
    </form>
</body>
</html>
