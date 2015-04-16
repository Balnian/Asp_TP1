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

                        <asp:Panel runat="server" ID="namegroup" class="form-group">
                            <label for="user">Full Name:</label>
                            <asp:TextBox runat="server" name="FullName" type="text" class="form-control" id="name" placeholder="Enter your full name"  />
                            <asp:CustomValidator 
                                ID="FnameVal" 
                                runat="server" 
                                ErrorMessage="Name field is not set!"
                                ControlToValidate="name"
                                ValidateEmptyText="true"
                                Display="None"
                                OnServerValidate="CV_Name_IsNotNull"
                                ValidationGroup="Subscribe_Validation"
                                ></asp:CustomValidator> 

                        </asp:Panel>

                        <asp:Panel runat="server" ID="Unamegroup" class="form-group">
                            <label for="user">Username:</label>
                            <asp:TextBox runat="server" name="UserName" type="text" class="form-control" id="user" placeholder="Enter username" />
                        <asp:CustomValidator 
                                ID="FunameVal" 
                                runat="server" 
                                ErrorMessage="UserName field is not set!"
                                ControlToValidate="user"
                                ValidateEmptyText="true"
                                Display="None"
                                OnServerValidate="CV_uname_IsNotNull"
                                ValidationGroup="Subscribe_Validation"
                                ></asp:CustomValidator> 
                             </asp:Panel>

                        <asp:Panel runat="server" ID="pwd1group" class="form-group">
                            <label for="pwd">Password:</label>
                            <asp:TextBox runat="server" name="PassWord" type="password" class="form-control" id="pwd" placeholder="Enter password" />
                       <asp:CustomValidator 
                                ID="fpwd1Val" 
                                runat="server" 
                                ErrorMessage="Password field is not valid!"
                                ControlToValidate="pwd"                           
                                ValidateEmptyText="true"
                                Display="None"
                                OnServerValidate="CV_pwd_IsNotNull"
                                ValidationGroup="Subscribe_Validation"
                                ></asp:CustomValidator> 
                             </asp:Panel>

                        <asp:Panel runat="server" ID="pwdcgroup" class="form-group">
                            <label for="pwd">Confirm Password:</label>
                            <asp:TextBox runat="server" type="password" class="form-control" id="conpwd" placeholder="Confirm password" />
                        <asp:CustomValidator 
                                ID="fpwdcVal" 
                                runat="server" 
                                ErrorMessage="Password fields do not match!"
                                ControlToValidate="conpwd"                           
                                ValidateEmptyText="true"
                                Display="None"
                                OnServerValidate="CV_pwd_match"
                                ValidationGroup="Subscribe_Validation"
                                ></asp:CustomValidator> 
                        </asp:Panel>

                        <asp:Panel runat="server" ID="eml1group" class="form-group">
                            <label for="pwd">Email:</label>
                            <asp:TextBox runat="server" name="Email" type="text" class="form-control" id="mail" placeholder="Enter Email" />
                        <asp:CustomValidator 
                                ID="feml1Val" 
                                runat="server" 
                                ErrorMessage="Email field is not valid!"
                                ControlToValidate="mail"                           
                                ValidateEmptyText="true"
                                Display="None"
                                OnServerValidate="CV_email_valid"
                                ValidationGroup="Subscribe_Validation"
                                ></asp:CustomValidator> 
                        </asp:Panel>

                        <asp:Panel runat="server" ID="emlcgroup" class="form-group">
                            <label for="pwd">Confirm Email:</label>
                            <asp:TextBox runat="server" type="text" class="form-control" id="conmail" placeholder="Confirm Email" />
                        <asp:CustomValidator 
                                ID="femlcVal" 
                                runat="server" 
                                ErrorMessage="Email fields do not match!"
                                ControlToValidate="conmail"                           
                                ValidateEmptyText="true"
                                Display="None"
                                OnServerValidate="CV_email_match"
                                ValidationGroup="Subscribe_Validation"
                                ></asp:CustomValidator> 
                        </asp:Panel>
                    </div>

                    <div class="col-xs-12 col-md-6">
                        <div class="row">
                            <div class="form-group">
                                <div class="thumbnail">
                                    <asp:Image ID="IMG_Avatar" ClientIDMode="Static" runat="server" CssClass="img-thumbnail center-block" Width="200" Height="200" ImageUrl="~/Images/Anonymous.png" />
                                    <asp:FileUpload ID="FU_Avatar" ClientIDMode="Static" runat="server" CssClass="center-block" onchange="PreLoadImage();" />
                                </div>
                            </div>
                        </div>
                        <!-- CAPTCHA -->
                        <div class="row">
                            <div class="form-group">
                                <asp:ScriptManager ID="ScriptManager1" runat="server" />

                                <div class="panel panel-default">

                                    <div class="panel-body">

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
                                                        <asp:Image ID="IMGCaptcha" Width="220px" ImageUrl="~/captcha.png" runat="server" CssClass="img-thumbnail pull-left" />
                                                    </div>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <br />
                                        <div class="row">

                                            <div class="col-xs-5 col-xs-offset-4 pull-left">
                                                <asp:Panel ID="Captcha_Input_Group" runat="server" CssClass="form-group">
                                                    <label class="control-label sr-only" ></label>
                                                    <asp:TextBox ID="TB_Captcha" runat="server" MaxLength="5" CssClass="form-control" placeholder="Enter Captcha"></asp:TextBox>
                                                    <!--<span id="Error_Span_Captcha" class="glyphicon glyphicon-remove form-control-feedback show"></span>-->
                                                    <asp:CustomValidator ID="CV_Captcha" runat="server"
                                                        ErrorMessage="Wrong captcha!"
                                                        ValidationGroup="Subscribe_Validation"
                                                        Text=""
                                                        Display="None"
                                                        ControlToValidate="TB_Captcha"
                                                        OnServerValidate="CV_Captcha_ServerValidate"
                                                        ValidateEmptyText="True"
                                                        >
                                                    </asp:CustomValidator>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <!-- FIN CAPTCHA -->
                    </div>


                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-md-6">
                    <div class="form-group">

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
                <div class="col-xs-12">
                    <asp:Panel ID="ErrorOverview" CssClass="alert alert-danger alert-dismissible" runat="server" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <asp:ValidationSummary ID="Subscribe_Validation" runat="server" ValidationGroup="Subscribe_Validation" />
                    </asp:Panel>
                </div> 
            </div>

        </div>
</asp:Content>
