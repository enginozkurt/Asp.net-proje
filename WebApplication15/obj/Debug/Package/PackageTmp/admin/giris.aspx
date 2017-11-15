<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="giris.aspx.cs" Inherits="WebApplication15.admin.giris" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: #858585;
width: 450px;
margin: 100px auto;
padding: 10px;
color: white;
border: dashed 2px #E0E0E0;
"><h2>Giriş Yap</h2>
    <table align="center">
    <tbody><tr>
    <td>Kullanıcı Girişi</td><td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Şifre</td><td>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr>
    <td colspan="2">

        <asp:Button ID="Button1" runat="server" Text="Tamam" onclick="Button1_Click" />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </td>
    </tr>
    
    
    </tbody></table>
    
    </div>
    </form>
</body>
</html>
