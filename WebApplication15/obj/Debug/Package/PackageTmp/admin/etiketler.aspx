<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Site1.Master" AutoEventWireup="true" CodeBehind="etiketler.aspx.cs" Inherits="WebApplication15.admin.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   <div>
        <td>
            
            <tr>
                <label>Etiket adi</label>
            </tr>
            <tr>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </tr>
            <tr>
                <asp:Button ID="btnEkle" runat="server" Text="Ekle" 
            onclick="btnEkle_Click" />
            </tr>
        </td>
   
        <asp:Button ID="btnGuncelle" runat="server" onclick="btnGuncelle_Click" 
            Text="Guncelle" Visible="False" />
   
   </div>
   
   
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        <table>
            <tr>
                <td style="width:50px;">
                    <label>Kod</label>
                </td>

                <td style="width:175px;">
                    <label>Etiket</label>
                </td>
                <td style="width:200px;">
                    <label> &nbsp;</label>
                </td>
                
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <label><%#Eval("id")%></label>
                </td>

                <td>
                    <label><%#Eval("etiket")%></label>
                </td>

                <td>
                    <a href="?id=<%#Eval("id") %>&etiket=<%#Eval("etiket") %>&islem=duzenle""><img alt="duzenle" src="../images/icons/pencil.png" /></a>
                    <a href="?id=<%#Eval("id") %>&etiket=<%#Eval("etiket") %>&islem=sil""><img src="../images/icons/cross_circle.png" /></a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        
        </FooterTemplate>
    </asp:Repeater>
    
</asp:Content>
