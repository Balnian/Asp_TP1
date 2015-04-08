<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="TP1.ChatRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
        </div>
        <div class="panel-body">
            <div class="row">
                <asp:UpdatePanel ID="ListeConvo" runat="server">
                    <ContentTemplate>
                        <ul class="nav nav-pills nav-stacked">
                            <li role="presentation" class="active"><a href="#">Convo1</a></li>
                            <li role="presentation"><a href="#">Convo2</a></li>
                            <li role="presentation"><a href="#">Convo3</a></li>
                        </ul>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
