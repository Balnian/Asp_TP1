<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TP1.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="col-xs-6 col-xs-offset-3">
                    <asp:Panel runat="server" ID="Unamegroup" class="form-group">
                        <label>Enter your Account Name:</label>
                        <asp:TextBox CssClass="form-control" ID="AccName" name="AccName" runat="server"></asp:TextBox>
                        <asp:CustomValidator 
                                ID="FunameVal" 
                                runat="server" 
                                ErrorMessage="UserName field is not set!"
                                ControlToValidate="AccName"
                                ValidateEmptyText="true"
                                Display="None"
                                OnServerValidate="CV_uname_IsNotNull"
                                ValidationGroup="Subscribe_Validation"
                                ></asp:CustomValidator> 
                             
                    </asp:Panel>
                    <asp:Panel runat="server" ID="eml1group" class="form-group">
                        <label>Enter your Email:</label>
                        
                        <asp:TextBox CssClass="form-control" ID="EmailTxt" name="EmailTxt" runat="server"></asp:TextBox>
                        <asp:CustomValidator 
                                ID="feml1Val" 
                                runat="server" 
                                ErrorMessage="Email field is not valid!"
                                ControlToValidate="EmailTxt"                           
                                ValidateEmptyText="true"
                                Display="None"
                                OnServerValidate="CV_email_valid"
                                ValidationGroup="Subscribe_Validation"
                                ></asp:CustomValidator> 
                        
                        </asp:Panel>
                      <div class="form-group">     
                                <asp:Button ID="Send" CssClass="btn btn-primary" runat="server" Text="Send" />
                            
                        
                    </div>
                    <hr />
                
                    
                    <asp:Panel ID="ErrorOverview" CssClass="alert alert-danger alert-dismissible" runat="server" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <asp:ValidationSummary ID="Subscribe_Validation" runat="server" ValidationGroup="Subscribe_Validation" />
                    </asp:Panel>
                
                </div>
            </div>
        </div>
    </div>
</asp:Content>
