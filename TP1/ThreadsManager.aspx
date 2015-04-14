<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="TP1.ThreadsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading"></div>
            <div class="panel-body">
                <asp:Panel ID="Pn_Threads" runat="server">
                    <div class="col-xs-5 col-md-">
                        <asp:Panel ID="Pn_Thread" runat="server">
                        </asp:Panel>

                    </div>
                    <div class="col-xs-7 col-md-3">
                        <div class="row">
                            <div class="form-group">
                                <label for="user">Thread Name:</label>
                                <div class="input-group">
                                    <asp:TextBox ID="TB_ThreadName" name="Thread" runat="server" CssClass="form-control" placeholder="Enter Thread Name"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button ID="BTN_Create" runat="server"
                                            Text="Create"
                                            ValidationGroup="Subscribe_Validation"
                                            OnClick="BTN_Create_Click"
                                            CssClass="btn btn-primary" />
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <asp:Panel ID="Pn_Users" runat="server">
                            </asp:Panel>
                        </div>


                    </div>

                </asp:Panel>
            </div>
        </div>
    </div>



</asp:Content>
