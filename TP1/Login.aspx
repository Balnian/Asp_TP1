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

                <div class="form-group">
                    <label for="user">Username:</label>
                    <input type="text" class="form-control" id="user" placeholder="Enter username" />
                </div>
                <div class="form-group">
                    <label for="pwd">Password:</label>
                    <input type="password" class="form-control" id="pwd" placeholder="Enter password" />
                </div>
                <div class="form-group">
                    <button type="submit" name="sub" class="btn btn-primary">Submit</button>
                </div>
                <div class="form-group">
                    <button type="submit" name="fmp" class="btn btn-default ">Forgot my password</button>
                </div>

            </div>
            <div class="panel-footer">
                <button type="submit" name="su" class="btn btn-default"><span class="glyphicon glyphicon-user"></span>Sign Up</button>


            </div>
        </div>
    </div>
    <div class="col-xs-0 col-sm-3 col-md-4 col-lg-4"></div>
</asp:Content>
