<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="TestCoalis.aspx.cs" Inherits="TP1.TestCoalis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <div class="panel">
            <div class="panel-body"></div>
            <div class="row">
                <asp:UpdatePanel ID="PN_Captcha" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="col-xs-6">
                            <asp:ImageButton ID="RegenarateCaptcha" runat="server"
                                ImageUrl="~/Images/RegenerateCaptcha.png"
                                CausesValidation="False"
                                OnClick="RegenarateCaptcha_Click"
                                ValidationGroup="Subscribe_Validation"
                                Width="48"
                                ToolTip="Regénérer le captcha..."
                                CssClass="pull-right" />
                        </div>
                        <div class="col-xs-6">
                            <asp:Image ID="IMGCaptcha" ImageUrl="~/captcha.png" runat="server" CssClass="center-block" />
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="row">
                <asp:TextBox ID="TB_Captcha" runat="server" MaxLength="5" CssClass="center-block"></asp:TextBox>
            </div>
            <asp:CustomValidator ID="CV_Captcha" runat="server"
                ErrorMessage="Code captcha incorrect!"
                ValidationGroup="Subscribe_Validation"
                Text="!"
                ControlToValidate="TB_Captcha"
                OnServerValidate="CV_Captcha_ServerValidate"
                ValidateEmptyText="True">
            </asp:CustomValidator>
            <div class="row">
                <asp:Button ID="BTN_Submit" runat="server"
                    Text="Soumettre ..."
                    ValidationGroup="Subscribe_Validation"
                    OnClick="BTN_Submit_Click"
                    CssClass="center-block" />
            </div>

        </div>

        <asp:ValidationSummary ID="Subscribe_Validation" runat="server" ValidationGroup="Subscribe_Validation" />
    </div>
</asp:Content>
