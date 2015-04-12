<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="TP1.ChatRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="panel panel-default">
        <div class="panel-heading">
            <!-- header -->
            <!--Big-->
            <h1 class="hidden-sm hidden-xs">Chat Room</h1>
            <!--Small/Room Selection-->
            <select class="form-control input-lg visible-xs visible-sm" id="sel1">
                <asp:UpdatePanel ID="ListeConvoSmall" runat="server">
                    <ContentTemplate>
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                        <option>4</option>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </select>
        </div>
        <div class="panel-body">
            <!-- Room Selection -->
            <div class="col-xs-2 hidden-sm hidden-xs">
                <div class="row">plu
                    <asp:UpdatePanel ID="ListeConvo" runat="server">
                        <ContentTemplate>
                            <ul class="nav nav-pills nav-stacked">
                                <li role="presentation" class="active"><a href="#">1</a></li>
                                <li role="presentation"><a href="#">Convo2</a></li>
                                <li role="presentation"><a href="#">Convo3</a></li>
                            </ul>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <!-- Chat -->
            <div class="col-xs-9 col-md-8">
                <table class="table table-responsive" style="word-wrap: break-word">
                    <asp:UpdatePanel ID="Chat" runat="server">
                        <ContentTemplate>
                            <tr><td class="col-xs-2"><img src="Captcha.png" class="img-responsive"  /></td><td class="col-xs-2"><div class="row">Date/heure</div><div class="row"><strong>Alias de l'usager</strong></div></td><td class="col-xs-8" style="word-wrap:break-word!important">sadsda asdasdsadasdas asdasdsadsa asdsadsa asdasdasds asddsdaa asddsas asdddas asddsadaas asdsadsadas asdsadsassss assddddffddf 555555555555555555555555555555555555555 55555555555555555555555555555555 55555555555555555555555555555 555555555555555555555555555</td></tr>
                            <tr><td><img src="" class="img-responsive"  /></td><td><div class="row">Date/heure</div><div class="row"><strong>Alias de l'usager</strong></div></td><td>Le message...</td></tr>
                            <tr><td><img src="" class="img-responsive"  /></td><td><div class="row">Date/heure</div><div class="row"><strong>Alias de l'usager</strong></div></td><td>Le message...</td></tr>
                            <tr><td><img src="" class="img-responsive"  /></td><td><div class="row">Date/heure</div><div class="row"><strong>Alias de l'usager</strong></div></td><td>Le message...</td></tr>
                            <tr><td><img src="" class="img-responsive"  /></td><td><div class="row">Date/heure</div><div class="row"><strong>Alias de l'usager</strong></div></td><td>Le message...</td></tr>
                            <tr><td><img src="" class="img-responsive"  /></td><td><div class="row">Date/heure</div><div class="row"><strong>Alias de l'usager</strong></div></td><td>Le message...</td></tr>
                            <tr><td><img src="" class="img-responsive"  /></td><td><div class="row">Date/heure</div><div class="row"><strong>Alias de l'usager</strong></div></td><td>Le message...</td></tr>
                            <tr><td><img src="" class="img-responsive"  /></td><td><div class="row">Date/heure</div><div class="row"><strong>Alias de l'usager</strong></div></td><td>Le message...</td></tr>
                            <tr><td><img src="" class="img-responsive"  /></td><td><div class="row">Date/heure</div><div class="row"><strong>Alias de l'usager</strong></div></td><td>Le message...</td></tr>
                            <tr><td><img src="" class="img-responsive"  /></td><td><div class="row">Date/heure</div><div class="row"><strong>Alias de l'usager</strong></div></td><td>Le message...</td></tr>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </table>
            </div>
            <!-- User -->
            <div class="col-xs-3 col-md-2">
                <asp:UpdatePanel ID="Users" runat="server">
                    <ContentTemplate>
                        <ul class="nav nav-pills nav-stacked">
                            <li role="presentation" class="active"><a href="#">3</a></li>
                            <li role="presentation"><a href="#">Convo2</a></li>
                            <li role="presentation"><a href="#">Convo3</a></li>
                        </ul>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>


</asp:Content>
