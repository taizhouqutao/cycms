<%@ Page Language="C#" AutoEventWireup="true" Inherits="Adapte.NormalPage" %>
<%@ Register Src="~/control/Top.ascx" TagName="top" TagPrefix="uc2" %>
<%@ Register Src="~/control/bottom.ascx" TagName="bot" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>搜索文章</title>
    <link href="~/App_Themes/default/css/Global.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/default/css/Showlist.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/fancy-zoom-master/jquery/js/fancyzoom.min.js" type="text/javascript"></script>
    <script src="js/Global.js" type="text/javascript"></script>
    <script src="App_Themes/default/js/ShowArticle.js" type="text/javascript"></script>
</head>
<body>
    <div id="container">
        <div id="header">
            <uc2:top ID="top1" runat="server" />
        </div>
        <div id="middle">
            <div class="linkarea">
                <div class="tablinks">位置：<a href="#">搜索文章</a></div>
            </div>
            <div class="leftimg">
                <div class="leftimgtitle">相关图片<span>》</span></div>
                <%=imageleft %>
                <div class="leftimgbottom">
                </div>
            </div>
            <div class="rightcontent">
                <%=Adapte.sys.getArticleSearch(Request.QueryString["page"], 22, Request.QueryString["kw"], 80, new int[] { 0 }, true)%>  
            </div>
            <div class="leftlink">
                <%--<%=Adapte.sys.showXML("guid2", "imgandtxtlink", MapPath("App_Data/data.xml"))%>--%>
                <ul class="phoneandliuyan">
                    <li>
                        <a class="linkimage_phone" href="<%=Adapte.sys.AppPath %>guestBook.aspx?s=1" target="_blank"></a>
                        <a class="linkname" href="<%=Adapte.sys.AppPath %>guestBook.aspx?s=1" title="联系我们" target="_blank">联系我们</a>
                    </li>
                    <li>
                        <a class="linkimage_liuyan" href="<%=Adapte.sys.AppPath %>aboutus.aspx" target="_blank"></a>
                        <a class="linkname" href="<%=Adapte.sys.AppPath %>aboutus.aspx" title="关于我们" target="_blank">关于我们</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div id="bottom">
        <uc3:bot ID="bot1" runat="server" />
        <input class="hidden" id="directory" value="<%=Adapte.sys.AppPath %>"/>
    </div>
</body>
</html>
