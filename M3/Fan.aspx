<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fan.aspx.cs" Inherits="M3.Fan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="ViewAvaMatches" Text="Available Matches" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Host Club Name:"></asp:Label>
            <br />
            <asp:TextBox ID="host" runat="server" ></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Guest Club Name:"></asp:Label>
            <br />
            <asp:TextBox ID="guest" runat="server" ></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Start date and Time:"></asp:Label>
            <br />
            <asp:TextBox ID="date" runat="server" ></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Purchase" Text="Purchase Ticket" />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
