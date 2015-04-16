<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="TP1.Profil" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="panel panel-default">
            <div class="panel-heading">
            
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-xs-12 col-md-6">

                         <asp:Panel runat="server" ID="namegroup" class="form-group">
                            <label for="user">Full Name:</label>
                            <asp:TextBox runat="server" name="Name" type="text" class="form-control" id="TB_FullName" placeholder="Enter your full name"  />
                            <asp:CustomValidator 
                                ID="FnameVal" 
                                runat="server" 
                                ErrorMessage="Name field is not set!"
                                ControlToValidate="TB_FullName"
                                ValidateEmptyText="true"
                                Display="None"
                                OnServerValidate="CV_Name_IsNotNull"
                                ValidationGroup="Subscribe_Validation"
                                ></asp:CustomValidator> 

                        </asp:Panel>
                        
                        <asp:Panel runat="server" ID="Unamegroup" class="form-group">
                            <label for="user">Username:</label>
                            <asp:TextBox runat="server" name="User" type="text" class="form-control" id="TB_UserName" placeholder="Enter username" />
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
                            <label for="pwd">Password:</label>
                            <asp:TextBox runat="server" name="Pwd" type="password" class="form-control" id="TB_PassWord" placeholder="Enter password" />
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

                        <asp:Panel runat="server" ID="pwdcgroup" class="form-group">
                            <label for="pwd">Confirm Password:</label>
                            <asp:TextBox runat="server" type="password" name="PwdVal" class="form-control" id="TB_ValidPW" placeholder="Confirm password" />
                        <asp:CustomValidator 
                                ID="fpwdcVal" 
                                runat="server" 
                                ErrorMessage="Password fields do not match!"
                                ControlToValidate="TB_ValidPW"                           
                                ValidateEmptyText="true"
                                Display="None"
                                OnServerValidate="CV_pwd_match"
                                ValidationGroup="Subscribe_Validation"
                                ></asp:CustomValidator> 
                        </asp:Panel>
                         
                        <asp:Panel runat="server" ID="eml1group" class="form-group">
                            <label for="pwd">Email:</label>
                            <asp:TextBox runat="server" name="Mail" type="text" class="form-control" id="TB_Email" placeholder="Enter Email" />
                        <asp:CustomValidator 
                                ID="feml1Val" 
                                runat="server" 
                                ErrorMessage="Email field is not valid!"
                                ControlToValidate="TB_Email"                           
                                ValidateEmptyText="true"
                                Display="None"
                                OnServerValidate="CV_email_valid"
                                ValidationGroup="Subscribe_Validation"
                                ></asp:CustomValidator> 
                        </asp:Panel>
                         

                        </div>

                    <div class="col-xs-12 col-md-6">
                        <div class="form-group">
                            
                           <asp:Image id="IMG_Avatar" ClientIDMode="Static" runat="server" CssClass="img-thumbnail center-block" width="200" height="200"  ImageUrl="~/Images/Anonymous.png" />
                            <asp:FileUpload id="FU_Avatar" ClientIDMode="Static" runat="server" CssClass="center-block" onchange="PreLoadImage();" />
                        </div>
                    </div>
                    
                </div>
                <div class="row">
                        <div class="col-xs-12 col-md-6">
                            <div class="form-group">
                               
                                   <asp:Button ID="BTN_Submit" runat="server"
                                Text="Update"
                                ValidationGroup="Subscribe_Validation"
                                OnClick="BTN_Submit_Click"
                                CssClass="btn btn-primary btn-lg center-block" />
                            </div>
                        </div>
                    </div>
                <hr />
                <div class="row">
                    <div class=""></div>
                    <asp:Panel ID="ErrorOverview" CssClass="alert alert-danger alert-dismissible" runat="server" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <asp:ValidationSummary ID="Subscribe_Validation" runat="server" ValidationGroup="Subscribe_Validation" />
                    </asp:Panel>
                </div>
            </div>
        </div>
</asp:Content>