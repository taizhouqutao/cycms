<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPassword.aspx.cs" Inherits="cycms.Web.admin.admin.adminPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>管理员密码</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="divmain">
     <div class="top">
                <div class="row rowtitle">管理员密码编辑</div>
                <div class="row"> 您现在的位置：管理员密码编辑
                </div>
            </div>
        <div style="text-align:left;">
        <table cellpadding="0" cellspacing="0" class="tableMain" align="center" style="width:350px;">
            <tr>
                <td class="tableLeft">用户名：</td>
                <td style="width: 280px"><asp:TextBox runat="server" ID="txtUserName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入用户名" ControlToValidate="txtUserName" Display="Dynamic"></asp:RequiredFieldValidator></td>
            </tr>
             <tr>
                <td class="tableLeft">密码：</td>
                <td style="width: 380px"><asp:TextBox runat="server" ID="txtPassword1" TextMode="Password" Width="127px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入密码" ControlToValidate="txtPassword1" Display="Dynamic"></asp:RequiredFieldValidator></td>
            </tr>
             <tr>
                <td class="tableLeft" style="height: 30px">确认密码：</td>
                <td style="width: 380px; height: 30px;"><asp:TextBox runat="server" ID="txtPassword2" TextMode="Password" Width="126px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword2"
                        ErrorMessage="请输入确认密码" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword1"
                        ControlToValidate="txtPassword2" ErrorMessage="两次输入密码不一致" Display="Dynamic"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td colspan="2" style="background-color:#ccffff"><asp:Literal runat="server" ID="lblMessage"></asp:Literal></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center"  class="lastrow"><asp:Button runat="server" ID="btnAdd" Text="添加管理员" style="width:82px; height:20px;" OnClick="btnAdd_Click" />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" id="btnCancel" value="返回" style="width:82px; height:20px;" onclick="javascript:window.location.href='adminList.aspx'"  />                 
                </td>
            </tr>
        </table>
        </div>
    </div>
    </form>
</body>
</html>
