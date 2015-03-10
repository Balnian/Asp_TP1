<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="TP1.Profil" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

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

</asp:Content>