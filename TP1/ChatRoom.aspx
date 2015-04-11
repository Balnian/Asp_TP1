<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="TP1.ChatRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="panel panel-default">
        <div class="panel-heading">
        </div>
        <div class="panel-body">
            <!-- Room Selection -->
            <div class="col-xs-2">
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
            <!-- Chat -->
            <div class="col-xs-8">
                <asp:UpdatePanel ID="Chat" runat="server">
                        <ContentTemplate>
                            <ul class="nav nav-pills nav-stacked">
                                <li role="presentation" class="active"><a href="#">Convo1</a></li>
                                <li role="presentation"><a href="#">Convo2</a></li>
                                <li role="presentation"><a href="#">Convo3</a></li>
                                <li role="presentation"><a href="#">Convo2</a></li>
                                <li role="presentation"><a href="#">Convo3</a></li>
                                <li role="presentation"><a href="#">Convo2</a></li>
                                <li role="presentation"><a href="#">Convo3</a></li>
                                <li role="presentation"><a href="#">Convo2</a></li>
                                <li role="presentation"><a href="#">Convo3</a></li>
                                <li role="presentation"><a href="#">Convo2</a></li>
                                <li role="presentation"><a href="#">Convo3</a></li>
                                <li role="presentation"><a href="#">Convo2</a></li>
                                <li role="presentation"><a href="#">Convo3</a></li>
                                <li role="presentation"><a href="#">Convo2</a></li>
                                <li role="presentation"><a href="#">Convo3</a></li>

                            </ul>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </div>
            <!-- User -->
            <div class="col-xs-2">
                <asp:UpdatePanel ID="Users" runat="server">
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
