<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="TP1.ChatRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="panel panel-default" style="max-height:90%">
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
                <div class="row">

                    <asp:UpdatePanel ID="ListeConvo" runat="server">
                        <ContentTemplate>
                         
                            <asp:Panel ID="Thread_Panel" runat="server"></asp:Panel>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <!-- Chat -->
            <div class="col-xs-9 col-md-8">
                <div class="panel panel-default">
                    <div class="panel-body" style="overflow-y:scroll">
                            <asp:Timer runat="server" ID="Timer_Chat" Interval="3000" OnTick="Timer_Chat_Tick"></asp:Timer>
                            <asp:UpdatePanel ID="Chat" runat="server" >
                                 <Triggers>
                                  <asp:AsyncPostBackTrigger ControlID="Timer_Chat" EventName="Tick" />
                             </Triggers>
         
                                <ContentTemplate>
                                    <asp:Panel ID="Message_Panel" runat="server"></asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>                        
                    </div>
                   
                    <!-- Message Input -->
                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-xs-12 col-xs-offset-0 col-md-9 col-md-offset-2">
                                <div class="col-xs-10">
                                    <asp:TextBox CssClass="form-control"  name="text" ClientIDMode="Static" ID="Tb_Message" style="resize:none" MaxLength="1" TextMode="multiline" Columns="40" Rows="5" runat="server" placeholder="Enter Message"></asp:TextBox>

                                </div>
                                <div class="col-xs-2">


                                    <asp:Button ID="Btn_Send" CssClass="btn btn-primary btn-block" runat="server" Text="Send" OnClick="Btn_Send_Click" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- User -->
            <div class="col-xs-3 col-md-2">
                <asp:UpdatePanel ID="Users" runat="server">
                    <ContentTemplate>
                           <asp:Panel ID="User_Panel" runat="server"></asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

    </div>



</asp:Content>
