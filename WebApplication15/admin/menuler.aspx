<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Site1.Master" AutoEventWireup="true" CodeBehind="menuler.aspx.cs" Inherits="WebApplication15.admin.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server">menü adı ººº</asp:TextBox>   
        <asp:TextBox ID="TextBox2" runat="server">aciklama</asp:TextBox> 
        <asp:Button ID="btnGuncelle" runat="server" onclick="btnGuncelle_Click" 
            Text="Güncelle" Visible="False" Width="77px" />
        <asp:Button ID="Button1"
            runat="server" Text="Ekle" onclick="Button1_Click" /> 
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </div>
    
    <asp:Repeater ID="rptMArkaDuzenleSil" runat="server">
    <HeaderTemplate>
        <table>
            <tr>
            
          
                <td align="center"><label>Duzenle:</label></td>
                <td align="center"><label>Sil:</label></td>

                <td style="width:75px" align="center"><label>Kod:</label></td>
                <td style="width:75px" align="center"><label>Sıra</label></td>
                <td style="width:210px" align="center"><label>Ana Menü Adı:</label></td>
                <td style="width:210px" align="center"><label>Açıklama:</label></td>
                <td style="width:75px" align="center"><label>Tip:</label></td>
                <td style="width:75px" align="center"><label></label></td>

            </tr>
    </HeaderTemplate>
        <ItemTemplate>
            <tr>
               
              
                   <td align="center"><a href="menuler.aspx?islem=duzenle&id=<%#Eval("kod")%>"><img src="../images/icons/pencil.png" /></a></td>
                <td align="center"><a onclick='<%#string.Format("return confirm(\"{0} isimli bölgeyi silmek istediğinize emin misiniz?\")",Eval("ad"))%>' href="menuler.aspx?islem=sil&id=<%#Eval("kod")%>">
                    <img src="../images/icons/cross_circle.png" /></a></td>
     

                <td align="center"><label><%#Eval("kod")%></label></td>
                <td align="center"><label><%#Eval("sira")%></label></td>
                <td align="center"><label><%#Eval("ad")%></label></td>
                <td align="center"><label><%#Eval("Alan1")%></label></td>
                <td align="center"><label><%#Eval("Tip")%></label></td>
                <td align="center"><label> <a href="#" onclick="javascript:window.open('altmenu.aspx?ustmenuid=<%# Eval("kod") %>','altmenuduzenle','toolbar=0,location=0,status=0,menubar=0,width=750px,height=650px')" >Alt menü</a></label></td>






                </tr>
        </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
    




</asp:Content>
