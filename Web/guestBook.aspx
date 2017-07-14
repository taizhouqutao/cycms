<%@ Page Language="C#" AutoEventWireup="true" Inherits="Adapte.NormalPage" %>
<%@ Register Src="~/control/Top.ascx" TagName="top" TagPrefix="uc2" %>
<%@ Register Src="~/control/bottom.ascx" TagName="bot" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>联系我们</title>
    <link href="~/App_Themes/default/css/Global.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/default/css/guestBook.css" rel="stylesheet" type="text/css" />
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
                <div class="tablinks">位置：<a href="guestBook.aspx?s=1">联系我们</a></div>
            </div>
            <div class="leftimg">
                <div class="leftimgtitle">相关图片<span>》</span></div>
                <%=imageleft %>
                <div class="leftimgbottom">
                </div>
            </div>
            <div class="rightcontent">
                <div class="nopostion">联系我们</div>
                <div class="companyinfo">
                    <p>名称：<%=Adapte.sys.webName %></p>
                    <p>地址：<%=Adapte.sys.workPlace %></p>
                    <p>联系人：<%=Adapte.sys.lianXiren %></p>
                    <p>手机：<%=Adapte.sys.cellPhone %></p>
                    <p>电话：<%=Adapte.sys.workPhone %></p>
                    <p>传真：<%=Adapte.sys.flax %></p>
                    <p>Email：<a href="mailto:<%=Adapte.sys.mailAddress %>"><%=Adapte.sys.mailAddress %></a></p>
                    <p><a href="<%=Adapte.sys.webAddress %>"><%=Adapte.sys.webAddress %></a></p>
                </div>
                <div class="nopostion"><%=nowposition %></div>
                <div style="display:<%=guestBookformShow %>">
                    <form id="guestbookform" onsubmit="return checkguestbookform()" runat="server">
                        <table cellpadding="0" cellspacing="0" border="0" style="clear:both;">
                            <tr>
                                <td class="liuyangname">标题：</td>
                                <td><input id="txtTitle" name="txtTitle" type="text"/>
                                <span id="checktxtTitle" style="color:green;display: none;">请输入标题</span></td>
                            </tr>        
                            <tr>
                                <td class="liuyangname">产品：</td>
                                <td>
                                    <select name="ddlGuestType" id="ddlGuestType">
	                                    <%=guestType %>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="liuyangname">姓名：</td>
                                <td><input id="txtName" name="txtName" type="text"/>
                                    <span id="checktxtName" style="color:green;display: none;">请输入姓名</span></td>
                            </tr>
                            <tr>
                                <td class="liuyangname">性别：</td>
                                <td>
                                    <input id="rbtnSex_0" type="radio" name="rbtnSex" value="男" checked="checked"/><label for="rbtnSex_0">男</label>
                                    <input id="rbtnSex_1" type="radio" name="rbtnSex" value="女"/><label for="rbtnSex_1">女</label>
                                </td>
                            </tr>
                            <tr>
                                <td class="liuyangname">单位：</td>
                                <td>
                                    <input name="txtWorkPlace" type="text" id="txtWorkPlace"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="liuyangname">传真：</td>
                                <td>
                                    <input name="txtChuanZhen" type="text" id="txtChuanZhen"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="liuyangname">手机：</td>
                                <td>
                                    <input name="txtCellphone" type="text" id="txtCellphone"/>*
                                    <span id="checktxtCellphone1" style="color:green;display: none;">请输入手机号</span>
                                    <span id="checktxtCellphone2" style="color:green;display: none;">手机号格式错误</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="liuyangname">邮箱：</td>
                                <td>
                                    <input name="txtEmail" type="text" id="txtEmail"/>*
                                    <span id="checktxtEmail1" style="color:green;display: none;">请输入邮箱地址</span>
                                    <span id="checktxtEmail2" style="color:green;display: none;">邮箱地址格式错误</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="liuyangname">地址：</td>
                                <td>
                                    <input name="txtAddress" type="text" id="txtAddress"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="liuyangname">内容：</td>
                                <td><textarea name="txtContent" rows="2" cols="20" id="txtContent" style="height:113px;width:422px;"></textarea>
                                    <span id="checktxtContent" style="color:Green;display:none;">请输入留言内容</span>
                
                                </td>
                            </tr>            
                            <tr>
                                <td colspan="2"><input id="btnSubmit" type="submit" value="提交" /></td>           
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
            <div class="leftlink">
                <%--<%=Adapte.sys.showXML("guid2", "imgandtxtlink", MapPath("App_Data/data.xml"))%>--%>
                <ul class="phoneandliuyan">
                    <li>
                        <a class="linkimage_phone" href="#" target="_blank"></a>
                        <a class="linkname" href="<%=Adapte.sys.AppPath %>guestBook.aspx?s=1" title="联系我们" target="_blank">联系我们</a>
                    </li>
                    <li>
                        <a class="linkimage_liuyan" href="#" target="_blank"></a>
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
