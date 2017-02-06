<%@ Page Title="" Language="C#" MasterPageFile="~/UserControlPages/CommonPage.Master" AutoEventWireup="true" CodeBehind="RestPasswordPage.aspx.cs" Inherits="DvdShop.UserControlPages.RestPasswordPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <center>
    <div class="jumbotron" id="jumborest">
        <div class="container">
            <div class="row" runat="server">
                <table>
                    <tr>
                        <td>
                            <label for="username" class="col-sm-3 control-label">
                            Username</label>
                        </td>
                        <td>
                            <asp:TextBox ID="Username" class="form-control" runat="server" placeholder="Username" required=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="inputPassword3" class="col-sm-3 control-label">
                            New Password</label>
                        </td>
                        <td>
                            <asp:TextBox ID="passw" class="form-control" runat="server" TextMode="Password" placeholder="Password" required=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="inputPassword4" class="col-sm-3 control-label">
                            Confirm Password</label>
                        </td>
                        <td>
                            <input type="password" class="form-control" id="password1" runat="server" placeholder="Password" required="" />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password dose not match." ControlToCompare="passw" ControlToValidate="password1" required=""></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnreset" class="btn btn-success btn-sm" runat="server" Text="Reset" OnClick="btnreset_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div></center>
</asp:Content>
