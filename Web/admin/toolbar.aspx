<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="toolbar.aspx.cs" Inherits="cycms.Web.admin.toolbar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <style type="text/css" >
    html { 	overflow-y:auto!important; 	*overflow-y:hidden;  overflow-x:hidden;} 
    body,td,th { font-size: 12px; color: #FFFFFF; background-color:#a6c8e4}
    body {margin:0;margin-left:5px;margin-top:5px;border:solid 0px #000000;}
	
	#divmain{background-image:url(images/Guide_main.gif); background-repeat:repeat-y;border:solid 0px #000000;}
	.divtop{border:solid 0px #ffffff;width:180px;text-align:left;text-indent:30px; height:18px;padding-top:7px;cursor:hand; 
	        cursor:pointer;color:#000000;background:url(images/guide_collapse.gif) no-repeat;margin-left:10px;}
	.divitem{ text-align:left;display:none;}
    .divitem a:link,.divitem a:visited{ width:170px; height:18px; display:block;font-size:12px;margin-left:10px; text-indent:30px;
                 color:#508d8e;text-decoration:none; padding-top:6px;background-image:none;}	
    .divitem a:hover{text-decoration:none;color:#ff0000;border:solid 1px #D4E4F6; width:168px; height:16px;}
    
    </style>
    <script type="text/javascript">
        function showMenu(obj) {
            var themain = document.getElementById("divmain");
            var divbigs = themain.childNodes;
            for (var j = 0; j < themain.childNodes.length; j++) {
                var sons = divbigs[j].childNodes;
                for (var i = 1; i < sons.length; i++) {
                    if (sons[i].className == "divitem") {
                        if (sons[i].parentNode == obj.parentNode) {
                            sons[i].style.display = ((sons[i].style.display == "none") || (sons[i].style.display == "")) ? "block" : "none";
                        } else {
                            sons[i].style.display = "none";
                        }
                    }

                }
            }
        }      
        
        
    </script>

</head>
<body>
        <div style=" background-image:url('images/Guide_top.gif');background-repeat:no-repeat; height:25px;width:197px;text-align:center;padding-top:25px;">
                <span style="font-size:16px;font-weight:bold;color:#29559C;">管理导航</span>
         </div>
         <div id="divmain">        
            <asp:Literal runat="server" ID="litToolbarContent"></asp:Literal>
           
            <div class='divbig'>
                <div class='divtop' onclick='javascript:showMenu(this);'>个人设置</div>
                <div class='divitem'><a href='admin/adminPassword.aspx?action=edit' target='main'>修改密码</a></div>
            </div>            
        </div>
        <div style=" background-image:url('images/Guide_bottom.gif'); background-repeat:no-repeat; height:13px;"></div>

</body>
</html>
