<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="cycms.Web.admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>管理员登陆</title>
    <style type="text/css">
			BODY { MARGIN: 0px }
			*{font-size:12px;}
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="WIDTH:100%; PADDING-TOP:15px; HEIGHT:100px"></div>
			<table align="center" cellpadding="0" cellspacing="0" border="0" style=" width:400px; height:200px; BORDER-RIGHT:#78bdfa 1px solid; BORDER-TOP:#78bdfa 1px solid; BORDER-LEFT:#78bdfa 1px solid; BORDER-BOTTOM:#78bdfa 1px solid">
				<tr>
					<td height="50" colspan="2" style="background-image:url(images/logintop.gif); background-repeat:no-repeat; background-position:0px 5px;">
					    <span style="font-size:14px; text-indent:36px; font-weight:bold">后台用户登陆</span>
					</td>
				</tr>
				<tr>
					<td height="30" width="45%" align="right">用户名：</td>
					<td><asp:TextBox Runat="server" ID="txtLogin" Width="150"></asp:TextBox></td>
				</tr>
				<tr>
					<td height="30" align="right">密码：</td>
					<td><asp:TextBox Runat="server" ID="txtPwd" TextMode="Password" Width="150"></asp:TextBox></td>
				</tr>
				<tr>
					<td height="30" align="right">验证码：</td>
					<td><asp:TextBox Runat="server" ID="txtCheckCode" Width="150"></asp:TextBox><img src="num.aspx" alt=""/></td>
				</tr>
				<tr>
					<td height="70"  align="center" colspan="2"><asp:ImageButton Runat="server" ID="IbLogin" ImageUrl="images/loginbtnok.gif" OnClick="IbLogin_Click"></asp:ImageButton>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:ImageButton Runat="server" ID="Imagebutton1" ImageUrl="images/btncancel.gif" OnClick="Imagebutton1_Click"></asp:ImageButton></td>
				</tr>
				<tr>
					<td><asp:Label runat="server" ID="lblMessage"></asp:Label></td>
				</tr>
			</table>
    </div>
    </form>
</body>
</html>

