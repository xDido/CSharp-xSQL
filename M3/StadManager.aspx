<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadManager.aspx.cs" Inherits="M3.StadManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="ViewStadDet" Text="View Stadium Details" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="ViewPenReq" Text="View Pending Requests" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Host Club Name:"></asp:Label>
            <br />
            <asp:TextBox ID="Hname" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Guest Club Name:"></asp:Label>
            <br />
            <asp:TextBox ID="Gname" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Start Time:"></asp:Label>
            <br />
            <asp:TextBox ID="Time" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="AcceptReq" Text="Accept Request" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="RejectReq" Text="Reject Request" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
