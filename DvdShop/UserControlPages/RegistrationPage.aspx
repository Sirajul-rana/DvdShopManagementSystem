<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="DvdShop.RegistrationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Brothers Dvd Shop</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../scripts/jquery-1.9.1.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <link href="../Content/Registration.css" rel="stylesheet" />
    <link href="../Content/datepicker.css" rel="stylesheet" />
    <script src="../Content/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(function() {
            $('.datepicker').datepicker();
        })
    </script>
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-md-4 col-sm-offset-2 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-heading">
                            <h2>BROTHERS DVD SHOP</h2>
                            Registration
                        </div>
                    </div>
                    <div class="panel-body">
                        <form role="form" runat="server">
                            <div class="row">
                                <div class="col-xs-6 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>Name</label>
                                        <input type="text" name="name" id="name" class="form-control input-sm" placeholder="Name" required="" />
                                    </div>
                                </div>
                                <div class="col-xs-6 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>Username</label>
                                        <input type="text" name="username" id="username" class="form-control input-sm" placeholder="Username" required="" />
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>Email address</label>
                                <input type="email" name="email" id="email" class="form-control input-sm" placeholder="Email Address" required=""/>
                            </div>
                            
                            <div class="row">
                                <div class="col-xs-6 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>Password</label>
                                        <input type="password" name="password" id="password" class="form-control input-sm" placeholder="Password" runat="server" required=""/>
                                    </div>
                                </div>
                                <div class="col-xs-6 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>Confirm password</label>
                                        <input type="password" name="password_confirmation" id="password_confirmation" class="form-control input-sm" runat="server" placeholder="Confirm Password" />
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password dose not match." ControlToCompare="password" ControlToValidate="password_confirmation" required="" ForeColor="Red"></asp:CompareValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>Adress</label>
                                <input type="text" name="address" id="address" class="form-control input-sm" placeholder="Address" required=""/>
                            </div>

                            <div class="form-group">
                                <label>Phone</label>
                                <input type="tel" name="phone" id="phone" class="form-control input-sm" placeholder="Phone Number" required=""/>
                            </div>



                            <div class="row">
                                <div class="col-xs-6 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>Gender</label>
                                        <asp:DropDownList ID="DropDownListGender" name="gender" class="form-control input-sm" runat="server">
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-xs-6 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>City</label>
                                        <input type="text" name="city" id="city" class="form-control input-sm" placeholder="City" required=""/>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="col-xs-6 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>Country</label>
                                        <asp:DropDownList ID="DropDownListCountry" name="country" class="form-control input-sm" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-xs-6 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <label>Date of Birth</label>
                                        <input type="date" name="dob" id="dob" class="form-control input-sm" placeholder="Date of Birth" required=""/>    
                                    </div>
                                </div>
                            </div>
                            <asp:Button ID="ButtonRegister" runat="server" Text="Register" class="btn btn-info btn-block" OnClick="ButtonRegister_Click"/>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
