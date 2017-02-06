<%@ Page Title="" Language="C#" MasterPageFile="~/UserControlPages/CommonPage.Master" AutoEventWireup="true" CodeBehind="UserProfilePage.aspx.cs" Inherits="DvdShop.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/Profile.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 136px;
        }
        .auto-style2 {
            width: 727px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <center>
        <div id="Row" class="row" runat="server">
            
        </div>
    </center>
</asp:Content>
