<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="TP1.ThreadsManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:Panel ID="Pn_Threads" runat="server">

          <div class="col-xs-7 col-md-3" >
                <label for="user">Thread Name:</label>    
                <asp:TextBox id="TB_ThreadName" name="Thread" runat="server" CssClass="form-control" placeholder="Enter Thread Name"></asp:TextBox>            
              <asp:Panel   ID="Pn_Users" runat="server">           
             </asp:Panel>
               <div class="col-xs-7 col-md-3">
                               
             <asp:Button ID="BTN_Create" runat="server"
                 Text="Create"
                 ValidationGroup="Subscribe_Validation"
                 OnClick="BTN_Create_Click"
                 CssClass="btn btn-primary btn-lg center-block" />
               </div>
          </div>
        <div>
             <asp:Panel   ID="Pn_Thread" runat="server">           
             </asp:Panel>

        </div>
    </asp:Panel>

</asp:Content>
