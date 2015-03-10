<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="TestCoalis.aspx.cs" Inherits="TP1.TestCoalis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
        <div>
            <table>
                <tr>    
                    <td colspan="2">
                        <asp:UpdatePanel ID="PN_Captcha" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton    ID="RegenarateCaptcha" runat="server" 
                                                        ImageUrl="~/Images/RegenerateCaptcha.png" 
                                                        CausesValidation="False" 
                                                        onclick="RegenarateCaptcha_Click" 
                                                        ValidationGroup="Subscribe_Validation" 
                                                        width="48"
                                                        ToolTip="Regénérer le captcha..." />  
                                    </td>
                                    <td>
                                        <asp:Image ID="IMGCaptcha" imageurl="~/captcha.png" runat="server" />
                                    </td>
                                </tr>
                        </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>      
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TB_Captcha" runat="server" MaxLength="5" ></asp:TextBox>
                        <asp:CustomValidator    ID="CV_Captcha" runat="server" 
                                                ErrorMessage="Code captcha incorrect!" 
                                                ValidationGroup="Subscribe_Validation"
                                                Text="!" 
                                                ControlToValidate="TB_Captcha" 
                                                onservervalidate="CV_Captcha_ServerValidate" 
                                                ValidateEmptyText="True">
                                                </asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="BTN_Submit" runat="server"
                                    Text="Soumettre ..."
                                    ValidationGroup="Subscribe_Validation"
                                    OnClick="BTN_Submit_Click" />
                </tr>
            </table>
        </div>
        <asp:ValidationSummary ID="Subscribe_Validation" runat="server" ValidationGroup="Subscribe_Validation" />

</asp:Content>
