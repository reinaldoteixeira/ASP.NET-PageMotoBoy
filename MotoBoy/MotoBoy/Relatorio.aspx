<%@ Page Title="" Language="C#" MasterPageFile="~/Home2.Master" AutoEventWireup="true" CodeBehind="Relatorio.aspx.cs" Inherits="MotoBoy.Relatorio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="Body_Master">
                <div style="width: 1200px; height: 797px;">

                <asp:Label class="clstxt" ID="lblAviso" runat="server"></asp:Label>

                    <br />

                    <br />
                    <br />
            <asp:Label ID="Label3" runat="server" class="clstxt" Text="Solicitações Abertas : "></asp:Label>
                    <br />
            <asp:GridView ID="dgvSolicitacao" runat="server" ValidateRequestMode="Enabled" ViewStateMode="Enabled" OnSelectedIndexChanged="dgvSolicitacao_SelectedIndexChanged">
            </asp:GridView>
                    <br />
                    <br />
            <asp:Label ID="Label4" runat="server" class="clstxt" Text="Solicitações Em Andamento : "></asp:Label>
                    <br />
            <asp:GridView ID="dgvSolicitacao0" runat="server" ValidateRequestMode="Enabled" ViewStateMode="Enabled">
            </asp:GridView>
                    <br />
                    <br />
            <asp:Label ID="Label5" runat="server" class="clstxt" Text="Concluidas :"></asp:Label>
            &nbsp;<br />
                    <br />
            <asp:GridView ID="dgvSolicitacao1" runat="server" ValidateRequestMode="Enabled" ViewStateMode="Enabled">
            </asp:GridView>

                </div>

         </asp:Content>

