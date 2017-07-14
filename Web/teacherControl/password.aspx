<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="password.aspx.cs" Inherits="cycms.Web.teacherControl.password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
<style type="text/css">
body {
	font-family: Arial, Helvetica, sans-serif;
	font-size:12px;
	color:#666666;
	background:#fff;
	text-align:center;

}
ul{
    text-decoration:none;
}

* {
	margin:0;
	padding:0;
}

a {
	color:#1E7ACE;
	text-decoration:none;	
}

a:hover {
	color:#000;
	text-decoration:underline;
}
h3 {
	font-size:14px;
	font-weight:bold;
}

pre,p {
	color:#1E7ACE;
	margin:4px;
}
input, select,textarea {
	padding:1px;
	margin:2px;
	font-size:11px;
}
.buttom{
	padding:1px 10px;
	font-size:12px;
	border:1px #1E7ACE solid;
	background:#D0F0FF;
}
#formwrapper {
	width:720px;
	margin:10px auto;
	padding:15px;
	text-align:left;
	border:1px #1E7ACE solid;
}

fieldset {
    width:700px;
	padding:10px;
	margin-top:5px;
	border:1px solid #1E7ACE;
	background:#fff;
}

fieldset legend {
	color:#1E7ACE;
	font-weight:bold;
	padding:3px 20px 3px 20px;
	border:1px solid #1E7ACE;	
	background:#fff;
}
fieldset div{   
    float:left;
    margin-top:8px;
}
fieldset label {
	float:left;
	width:120px;
	text-align:right;
	padding:4px;
	margin:1px;
}

.enter{ text-align:center;}
.clear {
	clear:both;
}
</style>
</head>
<body>
<form id="form1" runat="server">
    <div id="formwrapper">
	<fieldset>
		<legend>修改密码</legend>
        <div>
            <ul>
                <li>用&nbsp;&nbsp;户&nbsp;&nbsp;名：<asp:TextBox ID="u_name" runat="server" ></asp:TextBox></li>
                <li>原始密码：<asp:TextBox ID="old_pwd" runat="server" TextMode="Password" Width="124"></asp:TextBox></li>
                <li>新&nbsp;&nbsp;密&nbsp;&nbsp;码：<asp:TextBox ID="new_pwd" runat="server" TextMode="Password" Width="124"></asp:TextBox></li>
                <li>重复密码：<asp:TextBox ID="re_pwd" runat="server" TextMode="Password" Width="124"></asp:TextBox></li>
            </ul>
        </div>
	</fieldset>
    <div style="width:100%; text-align:left;"><asp:Button ID="saveBtn" runat="server" CssClass="buttom" Text="保存修改" OnClick="saveBtn_Click" /></div>
</div>
</form>
</body>
</html>

