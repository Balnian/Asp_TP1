<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="TP1.Profil" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="panel panel-default">
            <div class="panel-heading">
            
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
                        <div class="form-group">
                            <img src="asd.jpg" id="IMG_Avatar"class="img-thumbnail center-block" width="200" height="200" />
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control center-block" onchange="PreLoadImage();" />
                        </div>
                    </div>
                    
                </div>
                <div class="row">
                        <div class="col-xs-12 col-md-6">
                            <div class="form-group">
                                <button type="submit" name="sub" class="btn btn-primary btn-lg center-block">Update</button>
                            </div>
                        </div>
                    </div>
                <hr />
                <div class="row">
                    <div class=""></div>
                    <div class="alert alert-danger alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        You <strong>must</strong> be connected to access this website.
                    </div>
                </div>
            </div>
        </div>
</asp:Content>