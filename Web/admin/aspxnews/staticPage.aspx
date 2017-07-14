<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="staticPage.aspx.cs" Inherits="cycms.Web.admin.aspxnews.staticPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>静态生成</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
         .cale{background-color:#f0fffa;width:150px;padding:2px;border:solid 2px #8bc9f2;}
         fieldset{padding-left:20px; line-height:20px;}
    </style>
    <script src="../../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        var strpower = "0";
        function IsNumberKeyup(txt) {
            var srange = txt.value;
            var patrn = /^[0-9]{1,20}$/;
            if (srange != "" && !patrn.exec(srange)) {
                txt.value = strpower;
                return false;
            }
            strpower = srange;

        }
        function IsNumberFocus(txt) {
            if (txt.value == "") {
                strpower = "0";
            }
            else {
                strpower = txt.value;
            }
        }
	     
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="divmain">
            <div class="top">
                <div class="row rowtitle">静态生成</div>
                    <div class="row"> 您现在的位置：内容静态生成    
                    </div>
            </div>
            <!--
            <div class="top" style="height:auto;">
                <div class="row rowtitle" style="text-align:left;"></div>
                <div class="row">频道首页生成：</div>
                <div class="row">频道列表页生成：生成前</div>
                <div class="row">频道内容页生成：共有1000页，</div>
                <div class="row" style="padding-left:75px;"></div>    
            </div>
            -->
            <fieldset>
                <legend>频道首页生成</legend>
                <div style="text-align:left;">
                     静态模式下系统自动生成频道首页。也可以在动态模式下生成首页以提高站点访问速度和效率
                     <asp:Button runat="server" ID="btnExecDefault" Text="执行生成" OnClick="btnExecDefault_Click" /><br />
                     <asp:Literal runat="server" ID="litDefaultLastTime"></asp:Literal><asp:Button runat="server" ID="btnDeleteFile" Text="删除" OnClick="btnDeleteFile_Click" />
                 </div>
           </fieldset>
           <br />
           <fieldset>
               <legend>频道列表页生成</legend>
               <div style="text-align:left;">
                   静态模式下当前系统设置为每个分类生成前<%=Adapte.sys.staticListPages.ToString()%>页的分页列表，可以手动设置分页列表页面。<br />
                   生成该频道下前<asp:TextBox runat="server" ID="txtListPageCount" onfocus="javascript:IsNumberFocus(this);" onkeyup="javascript:IsNumberKeyup(this);">
                   </asp:TextBox>页分页列表页面
                   <asp:Button runat="server" ID="btnExecList" Text="执行生成" OnClick="btnExecList_Click" /><br />
                   提示：如果手动重新设置生成页面数目将保存当前设置。该数目设置越大将越消耗资源，建议不要使用太大的数字。
               </div>
           </fieldset>
           <br />
           <fieldset>
                <legend>频道内容页生成</legend>
                <div style="text-align:left;">
                    静态模式下每次添加、编辑、删除文章后系统自动生成该页以及相关列表页、专题首页和网站首页。<br />
                    当前频道中共有文章<asp:Literal runat="server" ID="litArticleCount"></asp:Literal>篇<br />
                    生成前<asp:TextBox runat="server" ID="txtContentPageCount" onfocus="javascript:IsNumberFocus(this);" onkeyup="javascript:IsNumberKeyup(this);"></asp:TextBox>页<asp:Button runat="server" ID="btnExecContentPageCount" Text="执行生成" OnClick="btnExecContentPageCount_Click" /> <br />
                    生成日期在<asp:TextBox runat="server" ID="txtContentDateStart" class="Wdate" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>至<asp:TextBox runat="server" ID="txtContentDateEnd" class="Wdate" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>之间的页面<asp:Button runat="server" ID="btnExecContentDate" Text="执行生成" OnClick="btnExecContentDate_Click" />
                </div>
           </fieldset>
            
    </div>
    <asp:Label runat="server" ID="lblMessage" ></asp:Label>
    </form>    
    <script type="text/javascript">
        //        var message = document.getElementById("lblMessage").innerHTML;
        //        if(message != "")
        //        {
        //            //document.write(message);
        //        }        
    </script>
</body>
</html>
