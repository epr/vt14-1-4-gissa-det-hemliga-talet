<%@ Page Language="C#" ViewStateMode="Disabled" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NumberGuesser.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Gissa det hemliga talet - Eddy Proca</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <label for="GuessInput">Ange ett tal mellan 1 och 100: </label>
        <asp:TextBox ID="GuessInput" runat="server" autofocus="autofocus" Width="30"></asp:TextBox>
        <asp:Button ID="MakeGuess" runat="server" Text="Skicka gissning" />
    </div>
    </form>
</body>
</html>
