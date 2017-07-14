<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="typeList.aspx.cs" Inherits="cycms.Web.admin.aspxnews.typeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>类型列表</title>
    <style type="text/css">
        .mytable{ width:100%;border:solid 1px #6c94fc;}
        .mytable td{height:20px;}
        .mytable .typename{ text-align:left;}
    </style>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color:#ffffff;">

 <div style="vertical-align:middle"></div>
     <div class="divmain">
          <div class="top">
                    <div class="row rowtitle">类型列表</div>
                    <div class="row"> 您现在的位置：查看类型列表    
                    </div>
          </div>
          <div style="text-align:center;">           
                <asp:Literal ID="litContent" runat="server"></asp:Literal>         
         </div>
    </div>
    
    
    
         <script type="text/javascript">
             var thetable = document.getElementById("table1");
             if (thetable != null) {
                 var trs = thetable.getElementsByTagName("tr");
                 for (var i = 1; i < trs.length; i++) {
                     trs[i].onmouseover = function () { this.style.backgroundColor = '#ccffff'; }
                     trs[i].onmouseout = function () { this.style.backgroundColor = '#ffffff'; }
                 }
             }      
        </script>    
</body>
</html>
