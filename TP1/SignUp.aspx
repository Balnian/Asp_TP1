<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="TP1.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h1>Sign Up</h1>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-xs-12 col-md-6">

                        <div class="form-group">
                            <label for="user">Full Name:</label>
                            <input type="text" class="form-control" id="name" placeholder="Enter your full name" />
                        </div>

                        <div class="form-group">
                            <label for="user">Username:</label>
                            <input type="text" class="form-control" id="user" placeholder="Enter username" />
                        </div>

                        <div class="form-group">
                            <label for="pwd">Password:</label>
                            <input type="password" class="form-control" id="pwd" placeholder="Enter password" />
                        </div>

                        <div class="form-group">
                            <label for="pwd">Confirm Password:</label>
                            <input type="password" class="form-control" id="conpwd" placeholder="Confirm password" />
                        </div>

                        <div class="form-group">
                            <label for="pwd">Email:</label>
                            <input type="password" class="form-control" id="mail" placeholder="Enter Email" />
                        </div>

                        <div class="form-group">
                            <label for="pwd">Confirm Email:</label>
                            <input type="password" class="form-control" id="conmail" placeholder="Confirm Email" />
                        </div>

                    </div>

                    <div class="col-xs-12 col-md-6">
                        <div class="row">
                            <div class="form-group">
                                <img src="asd.jpg" class="img-thumbnail center-block" width="200" height="200" />
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="center-block" />
                            </div>
                        </div>

                        <!-- CAPTCHA -->
                        <div class="row">
                            <div class="form-group">
                                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                                
                                <div class="panel panel-default">
                                   
                                    <div class="panel-body">
                                    <div class="container-fluid">
                                    <div class="row">
                                        <asp:UpdatePanel ID="PN_Captcha" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>

                                                <div class="col-xs-4">
                                                    <asp:ImageButton ID="RegenarateCaptcha" runat="server"
                                                        ImageUrl="~/Images/RegenerateCaptcha.png"
                                                        CausesValidation="False"
                                                        OnClick="RegenarateCaptcha_Click"
                                                        ValidationGroup="Subscribe_Validation"
                                                        Width="48"
                                                        ToolTip="Regénérer le captcha..."
                                                        CssClass="pull-right" />
                                                </div>
                                                <div class="col-xs-8">
                                                    <asp:Image ID="IMGCaptcha" ImageUrl="~/captcha.png" runat="server" CssClass="pull-left" />
                                                </div>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                        <br />
                                        <div class="row">
                                    <div class="form-group">
                                        
                                            <asp:TextBox ID="TB_Captcha" runat="server" MaxLength="5" CssClass="form-control col-xs-8 col-xs-offset-4 pull-left"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                    </div>
                                    </div>
                            </div>
                        </div>
                        <!-- FIN CAPTCHA -->

                    </div>


                </div>
                <div class="row">
                    <div class="col-xs-12 col-md-6">
                        <div class="form-group">
                            <asp:CustomValidator ID="CV_Captcha" runat="server"
                                ErrorMessage="Code captcha incorrect!"
                                ValidationGroup="Subscribe_Validation"
                                Text="!"
                                ControlToValidate="TB_Captcha"
                                OnServerValidate="CV_Captcha_ServerValidate"
                                ValidateEmptyText="True">
                            </asp:CustomValidator>
                            <div class="row">
                                <asp:Button ID="BTN_Submit" runat="server"
                                    Text="Submit"
                                    ValidationGroup="Subscribe_Validation"
                                    OnClick="BTN_Submit_Click"
                                    CssClass="btn btn-primary btn-lg center-block" />
                            </div>

                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class=""></div>
                    <div class="alert alert-danger alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <asp:ValidationSummary ID="Subscribe_Validation" runat="server" ValidationGroup="Subscribe_Validation" />
                    </div>
                </div>

            </div>
</asp:Content>
