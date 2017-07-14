<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminEdit.aspx.cs" Inherits="cycms.Web.admin.admin.adminEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>管理员权限设置</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        fieldset{padding-top:10px;}
    </style>
    <script type="text/javascript">
        function showPower(IsShow) {
            if (IsShow) { document.getElementById("OtherPower").style.display = "block"; }
            else if (!IsShow) { document.getElementById("OtherPower").style.display = "none"; }
        }
        function showTypes(IsShow, divId) {
            if (IsShow) document.getElementById(divId).style.display = "block";
            else document.getElementById(divId).style.display = "none";

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="divmain">
         <div class="top">
            <div class="row rowtitle">编辑管理员</div>
            <div class="row"> 您现在的位置：编辑管理员权限</div>
         </div>
         <div style="text-align:left">
              <fieldset>
                <legend>管理员权限设置</legend>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tableMain" style="width:100%;">
                    <tr>
                        <td class="tableLeft">管理员名：</td>
                        <td><asp:Literal runat="server" ID="litName"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td class="tableLeft">权限设置：</td>
                        <td>
                            <asp:RadioButton runat="server" ID="rbtnSuper" GroupName="IsSuperPower" onclick="javascript:showPower(false);" />超级管理员：拥有所有权限，某些权限（如系统设置，频道设置，管理员设置等）只有超级管理员才有<br />
                            <asp:RadioButton runat="server" ID="rbtnCommon" GroupName="IsSuperPower" onclick="javascript:showPower(true);" />普通管理员：需要详细设置管理权限
                        </td>
                    </tr>
                </table>
                <div id="OtherPower">            
                    <asp:CheckBoxList runat="server" ID="chkPower" RepeatDirection="Horizontal"></asp:CheckBoxList>                       
                    <asp:PlaceHolder runat="server" ID="pla1"></asp:PlaceHolder>
                </div>
            </fieldset>
            
            
         </div>
         
            <asp:Button ID="btn_save" runat="server" Text="保存修改" OnClick="btn_save_Click" />
    </form>
    <script type="text/javascript">
        showPower(!document.getElementById("rbtnSuper").checked);
        
    </script>

    

    
</body>
</html>