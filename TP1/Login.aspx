<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP1.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-0 col-sm-3 col-md-4 col-lg-4"></div>
    <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
        <% if (Request["Error"] == "MustLogin")
           {%>
        <div class="alert alert-danger alert-dismissible" role="alert">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            You <strong>must</strong> be connected to access this website.
        </div>
        <%} %>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h1>Login</h1>
            </div>
            <div class="panel-body">
           
                  <asp:Panel runat="server" ID="Unamegroup" class="form-group">
                            <label for="user">Username:</label>    
                              <asp:TextBox id="TB_UserName" name="User" runat="server" CssClass="form-control" placeholder="Enter username"></asp:TextBox> 
                      <asp:CustomValidator 
                                ID="FunameVal" 
                                runat="server" 
                                ErrorMessage="UserName field is not set!"
                                ControlToValidate="TB_UserName"
                                ValidateEmptyText="true"
                                Display="None"
                                OnServerValidate="CV_uname_IsNotNull"
                                ValidationGroup="Subscribe_Validation"
                                ></asp:CustomValidator>   
                       </asp:Panel>
                        <asp:Panel runat="server" ID="pwd1group" class="form-group">
                            <label  for="pwd">Password:</label>
                              <asp:TextBox id="TB_PassWord"
                                    TextMode="password" name="Pwd" runat="server" CssClass="form-control" placeholder="Enter password"></asp:TextBox> 
                        <asp:CustomValidator 
                                ID="fpwd1Val" 
                                runat="server" 
                                ErrorMessage="Password field is not valid!"
                                ControlToValidate="TB_PassWord"                           
                                ValidateEmptyText="true"
                                Display="None"
                                OnServerValidate="CV_pwd_IsNotNull"
                                ValidationGroup="Subscribe_Validation"
                                ></asp:CustomValidator> 
                             
                        </asp:Panel>
                <div class="form-group">
                    <button type="submit" name="sub" class="btn btn-primary">Connection</button>
                </div>
                <div class="form-group">
                    <a href="ForgotPassword.aspx" type="submit" name="fmp" class="btn btn-default ">Forgot my password</a>
                </div>
                <asp:Panel ID="ErrorOverview" CssClass="alert alert-danger alert-dismissible" runat="server" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <asp:ValidationSummary ID="Subscribe_Validation" runat="server" ValidationGroup="Subscribe_Validation" />
                    </asp:Panel>

            </div>
            <div class="panel-footer">
                <a  href="SignUp.aspx" name="su" class="btn btn-default"><span class="glyphicon glyphicon-user"></span> Sign Up</a>
            </div>
        </div>
    </div>
    <div class="col-xs-0 col-sm-3 col-md-4 col-lg-4"></div>
</asp:Content>
