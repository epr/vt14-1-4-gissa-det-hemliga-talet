<%@ Page Language="C#" ViewStateMode="Disabled" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NumberGuesser.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Gissa det hemliga talet - Eddy Proca</title>
    <link rel="stylesheet" href="~/screen.css">
</head>
<body>
    <h1>Gissa det hemliga talet</h1>
    <form id="form1" runat="server">
    <div>
        <asp:ValidationSummary ID="ValidationSummary1" CssClass="error" HeaderText="Ett fel inträffade. Korrigera felet och gör ett nytt försök." runat="server" />
        <label for="GuessInput">Ange ett tal mellan 1 och 100: </label>
        <%-- Number input --%>
        <asp:TextBox ID="GuessInput" runat="server" autofocus="autofocus" Width="30"></asp:TextBox>
        <%-- Validation --%>
        <asp:RangeValidator ControlToValidate="GuessInput" MinimumValue="1" MaximumValue="100" Type="Integer" Display="Dynamic" CssClass="error" ID="RangeValidator1" runat="server" ErrorMessage="Ange ett tal mellan 1 och 100." Text="*"></asp:RangeValidator>
        <asp:RequiredFieldValidator ControlToValidate="GuessInput" Display="Dynamic" CssClass="error" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ett tal måste anges." Text="*"></asp:RequiredFieldValidator>
        <%-- Send --%>
        <asp:Button ID="MakeGuess" runat="server" Text="Skicka gissning" OnClick="MakeGuess_Click" />
    </div>
    <div>
        <asp:Label ID="GuessOutcome" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <%-- New game --%>
        <asp:Button ID="NewNumber" runat="server" Text="Slumpa nytt hemligt tal" Visible="false" OnClick="NewNumber_Click" />
    </div>
    </form>
</body>
</html>
