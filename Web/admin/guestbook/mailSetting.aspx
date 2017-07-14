<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mailSetting.aspx.cs" Inherits="cycms.Web.admin.guestbook.mailSetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>邮件发送设置</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="divmain">
     <div class="top">
                <div class="row rowtitle">邮件发送设置</div>
                <div class="row"> 您现在的位置：邮件发送设置
                </div>
            </div>
        <div style="text-align:left;">
        <table cellpadding="0" cellspacing="0" class="tableMain" align="center" style="line-height:25px; width:500px;">
            <tr>
                <td class="tableLeft">邮件服务器：</td>
                <td><asp:TextBox runat="server" ID="txtsmtpServer"></asp:TextBox></td>
            </tr>
             <tr>
                <td class="tableLeft">邮箱地址：</td>
                <td><asp:TextBox runat="server" ID="txtmailAddress"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">邮箱用户名：</td>
                <td><asp:TextBox runat="server" ID="txtmailName"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">邮箱密码：</td>
                <td><asp:TextBox runat="server" ID="txtmailPwd"></asp:TextBox></td>
            </tr>                 
            <tr>
                <td colspan="2" style="text-align: center; height: 21px;"  class="lastrow">
                    <asp:Button runat="server" ID="btnSubmit" Text="保存" OnClick="btnSubmit_Click" Width="69px" />
                </td>
            </tr>
        </table>
        </div>
    </div>
    </form>
</body>
</html>
