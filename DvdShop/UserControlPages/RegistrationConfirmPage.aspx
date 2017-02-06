<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationConfirmPage.aspx.cs" Inherits="DvdShop.RegistrationConfirmPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Brothers Dvd Shop</title>
    <link href="../Content/login.css" rel="stylesheet" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../scripts/jquery-1.9.1.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
</head>
<body>
    <form runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-7">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2>BROTHERS DVD SHOP</h2>
                            Registration
                        </div>
                        <div class="panel-body">
                            <p>
                                <asp:Label ID="MyName" runat="server" ></asp:Label>,Your registration has been completed.</p>
                            <p>Please go to <a href="../Default.aspx">Login page</a></p>
                        </div>
                        <div class="panel-footer">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>