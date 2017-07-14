<%@ Page Language="C#" AutoEventWireup="true" Inherits="Adapte.NormalPage" %>
<%@ Register Src="~/control/top.ascx" TagName="top" TagPrefix="uc2" %>
<%@ Register Src="~/control/bottom.ascx" TagName="bot" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=Adapte.sys.webName %></title>
    <link href="js/jcarousel/lib/jquery.jcarousel.css" rel="stylesheet" type="text/css" />
    <link href="js/jcarousel/skins/tango/skin.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/default/css/Global.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/default/css/Default.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/jcarousel/lib/jquery.jcarousel.pack.js" type="text/javascript"></script>
    <script src="js/Global.js" type="text/javascript"></script>
    <script src="App_Themes/default/js/Default.js" type="text/javascript"></script>
</head>
<body>
    <div id="container">
        <div id="header">
            <uc2:top ID="top1" runat="server" />
        </div>
        <div id="middle">
            <%=Adapte.sys.showXML("guid1", "simgandtxtlinkandbimg", MapPath("App_Data/data.xml"))%>
        </div>
        <div id="moreinfo">
            <div class="compayinfo">
                <%--<ul class="compaylist">
                    <li class="select"><a onclick="factory_select('guid1',this)">汉高机械</a></li>
                    <li class=""><a onclick="factory_select('guid2',this)">汉高机械</a></li>
                    <li class=""><a onclick="factory_select('guid3',this)">汉高机械</a></li>
                    <li class=""><a onclick="factory_select('guid4',this)">汉高机械</a></li>
                    <li class="lastli"><a onclick="factory_select('guid5',this)">汉高机械</a></li>
                </ul>
                <div class="compaydetail">
                    <div id="f_guid1" class="factoryunion select">
                        <div class="factleft">
                            <h2><a target="_blank" href="http://www.lanrentuku.com">视觉焊接跟踪器(汉高机械)</a></h2>
                            <a target="_blank" href="http://www.lanrentuku.com"><img alt="汉高机械" width="175" height="62" title="汉高机械" src="UserFiles/Image/2013/5/17/543201305171249475.jpg"/></a>
                        </div>
                        <div class="factmiddle">
                            本品说明，用于的部位，作用功能等介绍。本系统主要功能是对有缝不锈钢管的氩弧焊接进行自动跟踪与矫正，解决目前人力成本日益提高，工人操作时视觉疲劳带来的焊接质量问题。
                        </div>
                        <div class="factright">
                            <a target="_blank" href="http://www.lanrentuku.com"><img width="205" height="155" title="视觉焊接跟踪器" alt="视觉焊接跟踪器" src="UserFiles/Image/2013/5/17/221201305171249475.jpg"/></a>
                        </div>
                    </div>
                    <div id="f_guid2" class="factoryunion">
                        <div class="factleft">
                            <h2><a target="_blank" href="http://www.lanrentuku.com">视觉焊接跟踪器(汉高机械)</a></h2>
                            <a target="_blank" href="http://www.lanrentuku.com"><img alt="汉高机械" width="175" height="62" title="汉高机械" src="UserFiles/Image/2013/5/17/543201305171249475.jpg"/></a>
                        </div>
                        <div class="factmiddle">
                            本品说明，用于的部位，作用功能等介绍。本系统主要功能是对有缝不锈钢管的氩弧焊接进行自动跟踪与矫正，解决目前人力成本日益提高，工人操作时视觉疲劳带来的焊接质量问题。
                        </div>
                        <div class="factright">
                            <a target="_blank" href="http://www.lanrentuku.com"><img width="205" height="155" title="视觉焊接跟踪器" alt="视觉焊接跟踪器" src="UserFiles/Image/2013/5/17/221201305171249475.jpg"/></a>
                        </div>
                    </div>
                    <div id="f_guid3" class="factoryunion">
                        <div class="factleft">
                            <h2><a target="_blank" href="http://www.lanrentuku.com">视觉焊接跟踪器(汉高机械)</a></h2>
                            <a target="_blank" href="http://www.lanrentuku.com"><img alt="汉高机械" width="175" height="62" title="汉高机械" src="UserFiles/Image/2013/5/17/543201305171249475.jpg"/></a>
                        </div>
                        <div class="factmiddle">
                            本品说明，用于的部位，作用功能等介绍。本系统主要功能是对有缝不锈钢管的氩弧焊接进行自动跟踪与矫正，解决目前人力成本日益提高，工人操作时视觉疲劳带来的焊接质量问题。
                        </div>
                        <div class="factright">
                            <a target="_blank" href="http://www.lanrentuku.com"><img width="205" height="155" title="视觉焊接跟踪器" alt="视觉焊接跟踪器" src="UserFiles/Image/2013/5/17/221201305171249475.jpg"/></a>
                        </div>
                    </div>
                    <div id="f_guid4" class="factoryunion">
                        <div class="factleft">
                            <h2><a target="_blank" href="http://www.lanrentuku.com">视觉焊接跟踪器(汉高机械)</a></h2>
                            <a target="_blank" href="http://www.lanrentuku.com"><img alt="汉高机械" width="175" height="62" title="汉高机械" src="UserFiles/Image/2013/5/17/543201305171249475.jpg"/></a>
                        </div>
                        <div class="factmiddle">
                            本品说明，用于的部位，作用功能等介绍。本系统主要功能是对有缝不锈钢管的氩弧焊接进行自动跟踪与矫正，解决目前人力成本日益提高，工人操作时视觉疲劳带来的焊接质量问题。
                        </div>
                        <div class="factright">
                            <a target="_blank" href="http://www.lanrentuku.com"><img width="205" height="155" title="视觉焊接跟踪器" alt="视觉焊接跟踪器" src="UserFiles/Image/2013/5/17/221201305171249475.jpg"/></a>
                        </div>
                    </div>
                    <div id="f_guid5" class="factoryunion">
                        <div class="factleft">
                            <h2><a target="_blank" href="http://www.lanrentuku.com">视觉焊接跟踪器(汉高机械)</a></h2>
                            <a target="_blank" href="http://www.lanrentuku.com"><img alt="汉高机械" width="175" height="62" title="汉高机械" src="UserFiles/Image/2013/5/17/543201305171249475.jpg"/></a>
                        </div>
                        <div class="factmiddle">
                            本品说明，用于的部位，作用功能等介绍。本系统主要功能是对有缝不锈钢管的氩弧焊接进行自动跟踪与矫正，解决目前人力成本日益提高，工人操作时视觉疲劳带来的焊接质量问题。
                        </div>
                        <div class="factright">
                            <a target="_blank" href="http://www.lanrentuku.com"><img width="205" height="155" title="视觉焊接跟踪器" alt="视觉焊接跟踪器" src="UserFiles/Image/2013/5/17/221201305171249475.jpg"/></a>
                        </div>
                    </div>
                </div>--%>
                <%=Adapte.sys.ShowDefaultBottom() %>
            </div>
            <div class="newinfo">
                <div class="newtitle"><a href="Showlist.aspx?typeid=7">最新更新</a></div>
                <div class="newlist">
                    <div id="prevclick">
                        <a id=prev class=gray hideFocus href="javascript:;" ></a>
                    </div>
                    <div id="nextclick">
                        <a id=next hideFocus  href="javascript:;"></a>
                    </div>
                    <div class="tancancontent">
                        <div class="slide-pic" id="slidePic">
                            <div class="pic-container">
                                <%=Adapte.sys.getArticleList(10,24, "7", true, "")%>   
                            </div>
                        </div>
                    </div>
                </div>
                <div class="newbotton">
                    <a class="contentus" href="guestBook.aspx?s=1" title="联系我们"></a>
                    <a class="aboutus" href="aboutus.aspx" title="关于我们"></a>
                </div>
            </div>
        </div>
        <div id="bottom">
            <uc3:bot ID="bot1" runat="server" />
            <input class="hidden" id="directory" value="<%=Adapte.sys.AppPath %>"/>
        </div>
    </div>
</body>
</html>
