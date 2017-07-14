<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="cycms.Web.admin._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=Adapte.sys.webName%>--后台管理</title>
</head>
    <frameset rows="80,*,0" border="0" frameborder="0" framespacing="0">
        <frame src="top.aspx" noresize="noresize" scrolling="no" />
        <frameset cols="210,*" border="0" frameborder="0" framespacing="0">
            <frame src="toolbar.aspx" noresize="noresize" name="toolbar" id="toolbar" />
            <frame src="main.aspx" id="main" name="main" noresize="noresize" />
        </frameset>
        <frame src="bottom.htm" noresize="noresize" scrolling="no" />
    </frameset>
    <body></body>
</html>
