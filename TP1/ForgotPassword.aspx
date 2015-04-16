<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TP1.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="col-xs-6 col-xs-offset-3">
                    <div class="form-group">
                        <label>Enter your Account Name:</label>
                        <asp:TextBox CssClass="form-control" ID="AccName" name="AccName" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Enter your Email:</label>
                        
                            <asp:TextBox CssClass="form-control" ID="EmailTxt" name="EmailTxt" runat="server"></asp:TextBox>
                        </div>
                      <div class="form-group">     
                                <asp:Button ID="Send" CssClass="btn btn-primary" runat="server" Text="Send" />
                            
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
