<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubRep.aspx.cs" Inherits="M3.ClubRep" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="ViewClubDet" Text="My Club Details" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="ViewUpMatches" Text="Club's Upcoming Matches" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Stadiums Available on:"></asp:Label>
            <br />
            <asp:TextBox ID="date" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="ViewAvailbleS" Text="Find" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Send a Host Request"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Date and Time of match:"></asp:Label>
            <br />
            <asp:TextBox ID="dateTime" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Stadium name:"></asp:Label>
            <br />
            <asp:TextBox ID="sName" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="HostReq" Text="Send" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
