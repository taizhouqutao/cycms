<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="cycms.Web.admin.top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        ul{float:left;border:solid 0px red; text-indent:0px;}
        li{text-indent:0px;list-style-type:circle; float:left;}
        .a_cancel a,.a_cancel a:visited{color:#ffffff;}
        .a_cancel a:hover{color:#e9af25}
    </style>
</head>
<body style="margin:0px; padding:0px; font-size:12px;">
    <div style=" width:100%; background-image:url(images/topbg.gif); border-width:0px; padding:0px; margin:0px; height:78px;">
        <div style="width:229px; height:78px; background-image:url(images/logo.gif); float:left;"></div> 
        <div id="top-right">
            <div style="height:33px; text-align:right;padding-top:20px;padding-right:20px;"><asp:HyperLink runat="server" Target="_blank"  ID="hlDefault"> 网站首页</asp:HyperLink> | <a href="login.aspx?action=loginout" target="_parent">安全退出</a></div>
                <div style="height:17px;padding-top:5px; color:#ffffff; text-align:left; 
                            border:solid 0px red; padding-right:20px;">                    
                    <div style="float:left;"><asp:Literal runat="server" ID="litMessage"></asp:Literal>
                        <span class="a_cancel"><a href="login.aspx?action=loginout" target="_parent">安全退出</a></span>
                    </div>
                <div style="float:right; border:solid 0px black; "><%=Adapte.sys.webName%>网站管理 版本:chaoyCMS v2.0 beta</div> 
            </div>
        </div>
    </div>
</body>
</html>
