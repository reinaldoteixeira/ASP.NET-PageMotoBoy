<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="MotoBoy.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="Body_Master">

                <div style="width: 1200px; height: 277px;">

                                    <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;<asp:Label class="clstxt" ID="Label2" runat="server" Text="Nome:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Width="219px"></asp:TextBox>
                <br />
                <br />
&nbsp;&nbsp; 
                <asp:Label class="clstxt" ID="Label1" runat="server" Text="Senha:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server" Width="219px" TextMode="Password"></asp:TextBox>
                                    <br />
                                    <br />
                                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Label class="clstxt" ID="lblAviso" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button  ID="bt_Inserir" runat="server" Height="45px" Text="Enter" Width="113px" CssClass="clsbutton" OnClick="bt_Inserir_Click" 
                     /> 


                </div>

         </asp:Content>


