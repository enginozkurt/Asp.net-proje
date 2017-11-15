<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Site1.Master" AutoEventWireup="true" CodeBehind="anahtarlar.aspx.cs" Inherits="WebApplication15.admin.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="Panel1" runat="server" Visible="False">
        
        <table>
            <tr>
            
          
                <td align="center"><label>Duzenle:</label></td>
                

                <td style="width:75px" align="center"><label>Kod:</label></td>
                
                <td style="width:210px" align="center"><label>Bölüm:</label></td>
               

            </tr>
    
            <tr>
               
              
                   <td align="center"><a href="anahtarlar.aspx?islem=duzenle&id=<%#Eval("kod")%>"><img src="../images/icons/pencil.png" /></a></td>
               
     

                <td align="center"><label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></label></td>
                
                <td align="center"><label>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    
                    </label></td>
               
               <td><asp:Button ID="btnGuncelle" runat="server" onclick="btnGuncelle_Click" 
                        Text="Güncelle" /></td>




                </tr>
        
        </table>
    
        </asp:Panel>
        <asp:Repeater ID="rptMArkaDuzenleSil" runat="server">
    <HeaderTemplate>
        <table>
            <tr>
            
          
                <td align="center"><label>Duzenle:</label></td>
                

                <td style="width:75px" align="center"><label>Kod:</label></td>
                
                <td style="width:210px" align="center"><label>Bölüm:</label></td>
               

            </tr>
    </HeaderTemplate>
        <ItemTemplate>
            <tr>
               
              
                   <td align="center"><a href="anahtarlar.aspx?islem=duzenle&id=<%#Eval("kod")%>"><img src="../images/icons/pencil.png" /></a></td>
               
     

                <td align="center"><label><%#Eval("kod")%></label></td>
                
                <td align="center"><label><%#Eval("bolum")%></label></td>
               





                </tr>
        </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
    
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    
</asp:Content>
