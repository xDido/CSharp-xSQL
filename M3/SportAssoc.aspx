<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SportAssoc.aspx.cs" Inherits="M3.SportAssoc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Add New Match:<br />
            <br />
        </div>
        <asp:Label ID="l1" runat="server" Text="Host Club Name:"></asp:Label>
        <br />
        <asp:TextBox ID="host" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="l2" runat="server" Text="Guest Club Name:"></asp:Label>
        <br />
        <asp:TextBox ID="guest" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="l3" runat="server" Text="Start Date and Time: "></asp:Label>
        <br />
        <asp:TextBox ID="startD" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="l4" runat="server" Text="End Date and Time: "></asp:Label>
        <br />
        <asp:TextBox ID="endD" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="newMatch" runat="server" OnClick="NewMatch" Text="Add Match" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="deletMatch" runat="server" OnClick="DeleteMatch" Text="Delete a Match" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="ViewAllUp"  Text="All Upcoming Matches" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="ViewAllPlayed"  Text="All Played Matches" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="NeverPlayed"  Text=" Clubs never Played Together" />
        <br />
        <br />
    </form>
</body>
</html>
