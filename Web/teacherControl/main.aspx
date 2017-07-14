<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="cycms.Web.teacherControl.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../admin/css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .thetitle{height:24px; padding-left:20px; font-weight:bold;font-size:14px;background-image:url(../admin/images/title.gif);color:#3165AD;padding-top:4px;}
        .divrow{padding-left:20px;}
    </style>
</head>
<body style="background-color:#D4E4F6;">
    <div class="divmain">
          <div class="top" style="height:auto;">
                    <div class="row rowtitle">欢迎进入<%=Adapte.sys.webName %>办公网</div>     
                    <asp:Panel runat="server" ID="Panel1">   
                        <div class="row">当前软件版本: chaoyCMS v2.0 beta </div>
                        <div class="row">软件更新日期: 2013年05月19日</div>
                        <div class="row">系统当前状态: <asp:Literal runat="server" ID="litSysIsRunning"></asp:Literal></div>                         
                    </asp:Panel>
                    <asp:Literal runat="server" ID="litMessage"></asp:Literal>
            </div>
    </div>
</body>
</html>
