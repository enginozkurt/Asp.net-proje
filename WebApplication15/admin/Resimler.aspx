<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Site1.Master" AutoEventWireup="true" CodeBehind="Resimler.aspx.cs" Inherits="WebApplication15.admin.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="pnlResimListe" runat="server">
        <asp:Repeater ID="rptResimler" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                     <img width="150px" height="125px" src='../images/<%#Eval("ad") %>' />
                    </td>
                   
                    <td>
                         <a href='resimler.aspx?id=<%#Eval("id") %>'> <img src="../images/icons/cross_circle.png" /></a>
                    </td>
               </tr>
              </ItemTemplate>

        </asp:Repeater>

    </asp:Panel>
         <td>
            <tr>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </tr>
            
            <tr style="width:75px;">
                &nbsp
            </tr>
            
            <tr>
                <asp:Button ID="Kaydet" runat="server" Text="Kaydet" 
        onclick="Kaydet_Click" />
            </tr>
         
         </td>

    <asp:Panel ID="ekle" runat="server">
        <asp:Image ID="Image2" runat="server" />
        


    </asp:Panel>

</asp:Content>
