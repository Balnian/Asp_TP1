<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="TP1.ThreadsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading"></div>
            <div class="panel-body">
                <asp:Panel ID="Pn_Threads"  runat="server">
                    <div class="col-xs-5 col-md-9">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-xs-12 col-md-6">
                                            <asp:Button ID="Update" runat="server"
                                                Text="Update"
                                                ValidationGroup="Subscribe_Validation"
                                                OnClick="Update_Click"
                                                CssClass="btn btn-warning btn-block" />
                                        </div>
                                        <div class="col-xs-12 col-md-6">
                                            <asp:Button ID="Delete" runat="server"
                                                Text="Delete"
                                                ValidationGroup="Subscribe_Validation"
                                                OnClick="Delete_Click"
                                                CssClass="btn btn-danger btn-block" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body" style="max-height:400px;height:400px;overflow-y:auto;">
                                <asp:Panel ID="Pn_Thread" runat="server">
                                </asp:Panel>
                            </div>
                        </div>
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
                                            CssClass="btn btn-primary " />
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <asp:Panel ID="Pn_Users" runat="server" style="max-height:400px;height:400px;overflow-y:auto;">
                            </asp:Panel>
                        </div>


                    </div>

                </asp:Panel>
            </div>
        </div>
    </div>



</asp:Content>
