<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DvdShop.LoginPage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Brothers Dvd Shop</title>
    <link href="Content/login.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="scripts/jquery-1.9.1.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-7">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h2>BROTHERS DVD SHOP</h2>
                        <span class="glyphicon glyphicon-lock"></span>Login
                    </div>
                    <div class="panel-body">
                        <form class="form-horizontal" role="form" runat="server">
                            <div class="form-group">
                                <label for="username" class="col-sm-3 control-label">
                                    Username</label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="username" runat="server" placeholder="Username"/>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="username" runat="server" ErrorMessage="Please fill out this field." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group" id="pass">
                                <label for="inputPassword3" class="col-sm-3 control-label">
                                    Password</label>
                                <div class="col-sm-9">
                                    <input type="password" class="form-control" id="password" runat="server" placeholder="Password"/>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="password" runat="server" ErrorMessage="Please fill out this field." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group last">
                                <div class="col-sm-offset-3 col-sm-9" id="sign">
                                    <asp:Button ID="signin" class="btn btn-success btn-sm" runat="server" Text="Sign in" OnClick="signin_Click" />
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class="panel-footer">
                        Not Registred? <a href="UserControlPages/RegistrationPage.aspx">Register Here</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
