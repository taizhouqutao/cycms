<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Top.ascx.cs" Inherits="cycms.Web.control.Top" %>
<div class="topimage">
    <div class="logo"></div>
    <form id="formsearch" name="formsearch" onsubmit="return checkform()" method="post" action="<%=Adapte.sys.AppPath %>search.aspx">
        <div class="searchpan">
            <div class="lanage">
                <a href="<%=Adapte.sys.AppPath %>teacherControl/login.aspx">内部OA</a><a href="<%=Adapte.sys.AppPath %>default.aspx">中文</a><a href="#">Engilsh</a>
            </div>  
            <input type="text" id="keywords" name="keywords"/>
            <input name="Submit" type="submit" class="form1" value=""/>   
        </div>    
    </form>
</div>
<div class="ullink">
    <%=Toptablink %>
</div>