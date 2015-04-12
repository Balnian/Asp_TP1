<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="TP1.ThreadsManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:Panel ID="Pn_Threads" runat="server">

          <div class="col-xs-7 col-md-3" >
                <label for="user">Thread Name:</label>    
                <asp:TextBox id="TB_ThreadName" name="Thread" runat="server" CssClass="form-control" placeholder="Enter Thread Name"></asp:TextBox>            
              <asp:Panel   ID="Pn_Users" runat="server">           
             </asp:Panel>
          </div>
    </asp:Panel>

</asp:Content>
