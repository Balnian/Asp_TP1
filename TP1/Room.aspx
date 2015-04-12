<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="TP1.Room" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <div class="panel panel-default">
  <div class="panel-heading"><h4>Users</h4></div>
  <div class="panel-body">
       <asp:Timer runat="server" ID="Timer" Interval="1000" OnTick="Timer_Tick"></asp:Timer>
       <asp:UpdatePanel ID="UPN_Time" runat="server">
           <Triggers>
               <asp:AsyncPostBackTrigger ControlID="Timer" EventName="Tick" />
               </Triggers>
           <ContentTemplate>
             <asp:Panel id="PN_GridView" runat="server"></asp:Panel>
               </ContentTemplate>
           </asp:UpdatePanel>
  </div>
</div>
</asp:Content>
