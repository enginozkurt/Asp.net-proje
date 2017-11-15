<%@ Page Title="" Language="C#"  MasterPageFile="~/admin/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication15.admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../scripts/jquery.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $('.btnonizle').click(function () {
                var dd = $('.txticerik').text();
                $('.dvonizle').html(dd);
                $('.dvonizle').focus();
            });
        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding:10px;">
        <div ><div style="padding:5px;font-size:12px">İçerik Metni &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            İçerik anahtarımız <i><strong>ººº</strong></i> &nbsp;&nbsp;&nbsp; <u>Yani üç adet &nbsp;&nbsp;[&nbsp;<b>Alt + 464</b>]</u></div>  
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" class="txticerik" style="border:3px solid gray;width:1000px;height:600px;"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Güncelle" 
                onclick="Button1_Click" /> <input style="margin-left:820px" class="btnonizle" id="Button2" type="button" value="Ön izle" /><br />
            <div style="font-size:16px;"><asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
            <div class="dvonizle" style="border:solid 2px #d1f1f1;background:white; padding:10px;margin-top:20px;">
            
            </div>
        </div>
     </div>
</asp:Content>
