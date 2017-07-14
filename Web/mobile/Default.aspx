<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="cycms.Web.mobile.Default" %>
<%@ Register Src="~/control/mobile_bottom.ascx" TagName="bottom" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no"/>
    <link href="../js/jquery.mobile-1.3.2/jquery.mobile-1.3.2.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../js/jquery.mobile-1.3.2/jquery.mobile-1.3.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        #default .productimg
        {
            width:70px;
            height:70px;
            -moz-border-radius: 8px;      /* Gecko browsers */
            -webkit-border-radius: 8px;   /* Webkit browsers */
            border-radius:8px;    
            margin-top:5px;
            margin-left:5px;
        }
        .product_pinfo img
        {
            max-width:250px;
        }
        .guestBook_info strong
        {
            font-size:14px;
            line-height:1.5;
        }
        #articleContainer {
            text-align: left;
            line-height: 150%;
        }
        #articleContainer .content .ui-li-desc,.product_pinfo .ui-li-desc
        {
            white-space:normal;
            overflow:auto;
        }
        #articleContainer .title {
            height: 46px;
            line-height: 46px;
            text-align: center;
            width: 100%;
            font-size: 16px;
            font-weight: 600;
            overflow:hidden;
        }
        #articleContainer .otherInfo {
            clear: both;
            float: right;
            width: 210px;
            font-size:14px;
        }
        #articleContainer .otherInfo ul {
            width: auto;
            padding: 0px;
            margin: 0px;
        }
        #articleContainer .otherInfo ul li {
            list-style-image: none;
            width: 100%;
            float: none;
            padding: 0px;
            margin: 0px;
            border-width: 0px;
        }
        .clear{ clear:both;}
    </style>
    <script type="text/javascript">
        Date.prototype.format = function (format) {
            var o = {
                "M+": this.getMonth() + 1, //month 
                "d+": this.getDate(), //day 
                "h+": this.getHours(), //hour 
                "m+": this.getMinutes(), //minute 
                "s+": this.getSeconds(), //second 
                "q+": Math.floor((this.getMonth() + 3) / 3), //quarter 
                "S": this.getMilliseconds() //millisecond 
            }
            if (/(y+)/.test(format)) {
                format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
            }
            for (var k in o) {
                if (new RegExp("(" + k + ")").test(format)) {
                    format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
                }
            }
            return format;
        } 
        function Add_guestBook() {
            if ($("#txtTitle").val() == "") {
                alert("请输入标题");
                return;
            }
            else if ($("#txtName").val() == "") {
                alert("请输入姓名");
                return;
            }
            else if ($("#txtCellphone").val() == "") {
                alert("请输入手机");
                return;
            }
            else if ($("#txtEmail").val() == "") {
                alert("请输入邮箱");
                return;
            }
            else if ($("#txtContent").val() == "") {
                alert("请输入留言内容");
                return;
            }
            if ($("#txtCellphone").val() != "") {
                var myreg = /^[1][0-9]{10}$/;
                if (!myreg.test($("#txtCellphone").val())) {
                    alert("手机号格式错误");
                    return;
                }
            }
            if ($("#txtEmail").val() != "") {
                var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
                if (!myreg.test($("#txtEmail").val())) {
                    alert("邮箱地址格式错误");
                    return;
                }
            }
            $.ajax({
                type: 'post',
                url: 'server.ashx',
                async: false,
                data: 'type=AddGuestBook&title=' + $("#txtTitle").val() + '&name=' + $("#txtName").val() + '&cellphone=' + $("#txtCellphone").val() + '&content=' + $("#txtContent").val() + '&email=' + $("#txtEmail").val() + '&guesttype=' + $('#ddlGuestType').val() + '&sex=' + $("input[name='rbtnSex']:checked").val() + '&workplace=' + $('#WorkPlace').val() + '&chuanzhen=' + $('#txtChuanZhen').val() + '&address=' + $('#txtAddress').val(),
                success: function (result) {
                    alert("留言成功，我们会尽快回复到您的邮箱，请注意查收");
                    $("#txtTitle").val('');
                    $("#txtContent").val('');
                }
            });
        }
        function showDetail(val) {
            $.ajax({
                type: 'post',
                url: 'server.ashx',
                async: false,
                data: 'type=ShowDetail&id=' + val,
                success: function (result) {
                    $("#Detail_header,#Detail_title").html(result.split('$')[0]);
                    $("#Detail_content").html(result.split('$')[1]);
                    $('#Detail').page();
                    $('#news_info').listview('refresh');
                    $.mobile.changePage("#Detail", { transition: "slide" });
                }
            })
        }
        function showlistMore() {
            var nowpage = parseInt($('#hidPageNow_list').val());
            var pagecount = parseInt($('#hidPagecount_list').val());
            if (nowpage == pagecount) {
                $('#listMore .ui-btn-text').html("没有更多内容了");
                return;
            }
            $('#hidPageNow_list').val(nowpage + 1);
            if ($('#hidPageNow_list').val() == $('#hidPagecount_list').val()) {
                $('#listMore .ui-btn-text').html("没有更多内容了");
            }
            search_list(nowpage);
        }
        function search_list(nowpage) {
            $.ajax({
                type: 'post',
                url: 'server.ashx',
                async: false,
                data: 'type=GetListByPage&page=' + (nowpage + 1),
                success: function (result) {
                    $('#newslist').append(result);
                    $('#newslist').listview('refresh');
                }
            })
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div data-role="page" id="default" data-theme="b">
        <div data-role="header" data-position="fixed">
            <a href="#default" data-transition="fade" data-icon="home" data-role="button">首页</a>
            <h1><%=Adapte.sys.webName %></h1>
            <a href="#showlist" data-transition="fade" data-icon="info" data-role="button">最新资讯</a>
        </div>
        <div data-role="content">
            <img src="../App_Themes/default/images/logo.png" alt="<%=Adapte.sys.webName %>" style="max-width:300px"/>
            <ul data-role="listview" data-inset="true" data-theme="c">
                <li data-role="divider">产品介绍</li>
                <%=CPJS %>
            </ul>
            <ul data-role="listview" data-inset="true" data-theme="c">
                <li data-role="divider">经典案例</li>
                <%=JDAL %>
            </ul>
        </div>
        <uc2:bottom ID="bottom1" runat="server" />
    </div>
    <div data-role="page" id="product1" data-theme="b">
        <div data-role="header" data-position="fixed">
            <a href="#default" data-transition="fade" data-icon="home" data-role="button">首页</a>
            <h1><%=Product1.P_Name %></h1>
            <a href="#showlist" data-transition="fade" data-icon="info" data-role="button">最新资讯</a>
        </div>
        <div data-role="content">
            <img src="../App_Themes/default/images/logo.png" alt="<%=Adapte.sys.webName %>" style="max-width:300px"/>
            <ul data-role="listview" data-inset="true" data-theme="c">
                <li data-role="divider"><%=Product1.P_Name %></li>
                <li class="product_pinfo">
                    <%=Product1.P_Info %>
                </li>
            </ul>
        </div>
        <uc2:bottom ID="bottom2" runat="server" />
    </div>
    <div data-role="page" id="product2" data-theme="b">
        <div data-role="header" data-position="fixed">
            <a href="#default" data-transition="fade" data-icon="home" data-role="button">首页</a>
            <h1><%=Product2.P_Name %></h1>
            <a href="#showlist" data-transition="fade" data-icon="info" data-role="button">最新资讯</a>
        </div>
        <div data-role="content">
            <img src="../App_Themes/default/images/logo.png" alt="<%=Adapte.sys.webName %>" style="max-width:300px"/>
            <ul data-role="listview" data-inset="true" data-theme="c">
                <li data-role="divider"><%=Product2.P_Name %></li>
                <li class="product_pinfo">
                    <%=Product2.P_Info %>
                </li>
            </ul>
        </div>
        <uc2:bottom ID="bottom3" runat="server" />
    </div>
    <div data-role="page" id="product3" data-theme="b">
        <div data-role="header" data-position="fixed">
            <a href="#default" data-transition="fade" data-icon="home" data-role="button">首页</a>
            <h1><%=Product3.P_Name %></h1>
            <a href="#showlist" data-transition="fade" data-icon="info" data-role="button">最新资讯</a>
        </div>
        <div data-role="content">
            <img src="../App_Themes/default/images/logo.png" alt="<%=Adapte.sys.webName %>" style="max-width:300px"/>
            <ul data-role="listview" data-inset="true" data-theme="c">
                <li data-role="divider"><%=Product3.P_Name %></li>
                <li class="product_pinfo">
                    <%=Product3.P_Info %>
                </li>
            </ul>
        </div>
        <uc2:bottom ID="bottom4" runat="server" />
    </div>
    <div data-role="page" id="guestBook" data-theme="b">
        <div data-role="header" data-position="fixed">
            <a href="#default" data-transition="fade" data-icon="home" data-role="button">首页</a>
            <h1><%=Product3.P_Name %></h1>
            <a href="#showlist" data-transition="fade" data-icon="info" data-role="button">最新资讯</a>
        </div>
        <div data-role="content">
            <img src="../App_Themes/default/images/logo.png" alt="<%=Adapte.sys.webName %>" style="max-width:300px"/>
            <ul data-role="listview" data-inset="true" data-theme="c">
                <li data-role="divider">联系我们</li>
                <li class="guestBook_info">
                    <p><strong>名称：<%=Adapte.sys.webName %></strong></p>
                    <p><strong>地址：<%=Adapte.sys.workPlace %></strong></p>
                    <p><strong>联系人：<%=Adapte.sys.lianXiren %></strong></p>
                    <p><strong>手机：<a href="tel:<%=Adapte.sys.cellPhone %>"><%=Adapte.sys.cellPhone %></a></strong></p>
                    <p><strong>电话：<%=Adapte.sys.workPhone %></strong></p>
                    <p><strong>传真：<%=Adapte.sys.flax %></strong></p>
                    <p><strong>Email：<a href="mailto:<%=Adapte.sys.mailAddress %>"><%=Adapte.sys.mailAddress %></a></strong></p>
                    <p><strong><a href="<%=Adapte.sys.webAddress %>"><%=Adapte.sys.webAddress %></a></strong></p>
                </li>
            </ul>
            <ul data-role="listview" data-inset="true" data-theme="c">
                <li data-role="divider">我要咨询</li>
                <li>
                    <div data-role="fieldcontain">
                        <label for="txtTitle">标题：</label>
                        <input type="text" name="txtTitle" id="txtTitle" placeholder="请输入标题">
                    </div>
                    <div data-role="fieldcontain">
                        <label for="ddlGuestType">产品：</label>
                        <select name="ddlGuestType" id="ddlGuestType" data-theme="c">
	                        <%=guestType %>
                        </select>
                    </div>
                    <div data-role="fieldcontain">
                        <label for="txtName">姓名：</label>
                        <input type="text" name="txtName" id="txtName" placeholder="请输入姓名">
                    </div>
                    <fieldset data-role="controlgroup">
                      <legend>请选择您的性别：</legend>
                        <label for="rbtnSex_0">男性</label>
                        <input type="radio" name="rbtnSex" checked="checked" id="rbtnSex_0" value="男" data-theme="c">
                        <label for="rbtnSex_1">女性</label>
                        <input type="radio" name="rbtnSex" id="rbtnSex_1" value="女" data-theme="c">	
                    </fieldset>
                    <div data-role="fieldcontain">
                        <label for="txtWorkPlace">单位：</label>
                        <input type="text" name="txtWorkPlace" id="txtWorkPlace" placeholder="请输入单位">
                    </div>
                    <div data-role="fieldcontain">
                        <label for="txtChuanZhen">传真：</label>
                        <input type="text" name="txtChuanZhen" id="txtChuanZhen" placeholder="请输入传真">
                    </div>
                    <div data-role="fieldcontain">
                        <label for="txtCellphone">手机：</label>
                        <input type="text" name="txtCellphone" id="txtCellphone" placeholder="请输入手机">
                    </div>
                    <div data-role="fieldcontain">
                        <label for="txtEmail">邮箱：</label>
                        <input type="email" name="txtEmail" id="txtEmail" placeholder="请输入邮箱">
                    </div>
                    <div data-role="fieldcontain">
                        <label for="txtAddress">地址：</label>
                        <input type="text" name="txtAddress" id="txtAddress" placeholder="请输入地址">
                    </div>
                    <div data-role="fieldcontain">
                        <label for="txtContent">内容：</label>
                        <textarea name="txtContent" rows="2" cols="20" id="txtContent" placeholder="请输入留言内容"></textarea>
                    </div>
                </li>
            </ul>
            <input type="button" onclick="Add_guestBook()" value="递交">
      </div>
        <uc2:bottom ID="bottom5" runat="server" />
    </div>
    <div data-role="page" data-theme="b" id="showlist">
        <div data-role="header" data-position="fixed">
            <a href="#default" data-transition="fade" data-icon="home" data-role="button">首页</a>
            <h1>最新资讯</h1>
            <a href="#showlist" data-transition="fade" data-icon="info" data-role="button">最新资讯</a>
        </div>
        <div data-role="content">
            <img src="../App_Themes/default/images/logo.png" alt="<%=Adapte.sys.webName %>" style="max-width:300px"/>
            <ul data-role="listview" id="newslist" data-inset="true" data-theme="c">
                <%=NewList %>
            </ul>
            <div data-role="navbar" data-inset="true">
                <ul>
                    <li><a href="javascript:showlistMore()" id="listMore" runat="server" data-transition="fade">点击获取更多</a></li>
                </ul>
            </div>
        </div>
        
        <asp:HiddenField ID="hidPageNow_list" runat="server" />
        <asp:HiddenField ID="hidPagecount_list" runat="server" />
        <uc2:bottom ID="bottom6" runat="server" />
    </div>
    <div data-role="page" data-theme="b" id="Detail">
        <div data-role="header" data-position="fixed">
            <a href="#default" data-transition="fade" data-icon="home" data-role="button">首页</a>
            <h1 id="Detail_header"></h1>
            <a href="#showlist" data-transition="fade" data-icon="info" data-role="button">最新资讯</a>
        </div>
        <div data-role="content">
            <img src="../App_Themes/default/images/logo.png" alt="<%=Adapte.sys.webName %>" style="max-width:300px"/>
            <ul data-role="listview" id="news_info" data-inset="true" data-theme="c">
                <li data-role="divider" id="Detail_title"></li>
                <li class="product_pinfo">
                    <div id="Detail_content"></div>
                </li>
            </ul>
        </div>
        <uc2:bottom ID="bottom7" runat="server" />
    </div>
    </form>
</body>
</html>
