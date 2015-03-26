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
                           <asp:TextBox ID="TB_FullName" name="Name" runat="server" CssClass="form-control"></asp:TextBox> 
                          
                        </div>

                        <div class="form-group">
                            <label for="user">Username:</label>    
                              <asp:TextBox ID="TB_UserName" name="User" runat="server" CssClass="form-control"></asp:TextBox> 
                        </div>

                        <div class="form-group">
                            <label for="pwd">Password:</label>
                              <asp:TextBox ID="TB_PassWord"  TextMode="password" name="Pwd" runat="server" CssClass="form-control"></asp:TextBox> 
                        </div>
                    
                         <div class="form-group">
                            <label for="pwd">Email:</label>                         
                             <asp:TextBox ID="TB_Email" name="Mail" runat="server" CssClass="form-control"></asp:TextBox>  
                        </div>                      

                    </div>

                    <div class="col-xs-12 col-md-6">
                        <div class="form-group">
                            
                           <asp:Image id="IMG_Avatar" ClientIDMode="Static" runat="server" CssClass="img-thumbnail center-block" width="200" height="200"  ImageUrl="~/Images/Anonymous.png" />
                            <asp:FileUpload ID="FileUpload1" ClientIDMode="Static" runat="server" CssClass="center-block" onchange="PreLoadImage();" />
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