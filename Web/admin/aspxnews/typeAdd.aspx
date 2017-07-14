<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="typeAdd.aspx.cs" Inherits="cycms.Web.admin.aspxnews.typeAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>类型编辑</title>
    <style type="text/css">
    *{font-size:12px;}
    .ddlfathertype{font-size:12px;}    
    </style>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnAdd").click(function () {
                if ($("#chkIsArticleType").attr("checked") != 'checked') {
                    if ($("#txtLinkUrl").val() == "") {
                        alert("如不是文章类型，需要给类别一个跳转链接！");
                        $("#txtLinkUrl").focus();
                        return false;
                    }
                }
                return true;
            })
        });
        function funSpeciality() {
            var selType = document.getElementById("ddlFatherType");
            var selSpe = document.getElementById("ddlSpeciality");
            if (selSpe != null) {
                var typeid = selType.options[selType.selectedIndex].value;
                if (typeid != 0) {
                    selSpe.selectedIndex = 0;
                    selSpe.disabled = "disabled";
                }
                else {
                    selSpe.disabled = "";
                }
            }
        }    
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="divmain">
          <div class="top">
                    <div class="row rowtitle">类型编辑</div>
                    <div class="row"> 您现在的位置：编辑类型属性    
                    </div>
          </div>
    
        <table style="text-align:left;width:400px; " class="tableMain" cellpadding="0" cellspacing="0" >
            <tr>
                <td class="tableLeft">类型名称：</td>
                <td><asp:TextBox runat="server" ID="txtTypeName"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">父节点：</td>
                <td><asp:DropDownList runat="server" ID="ddlFatherType" CssClass="ddlfathertype" onchange="javascript:funSpeciality();"></asp:DropDownList></td>
            </tr>
            <tr>
                <td class="tableLeft">链接地址：</td>
                <td><asp:TextBox runat="server" ID="txtLinkUrl"></asp:TextBox>*仅对非文章类型有效</td>
            </tr>
            <tr>
                <td class="tableLeft">导航显示：</td>
                <td><asp:CheckBox runat="server" ID="chkIsDisplay" /></td>
            </tr>
            <tr>
                <td class="tableLeft">文章类型：</td>
                <td><asp:CheckBox runat="server" ID="chkIsArticleType" Checked="true" /></td>
            </tr>
            <tr>
                <td class="tableLeft">
                    所属专题：</td>
                <td><asp:Literal runat="server" ID="litSpcName"></asp:Literal>
                    <asp:DropDownList ID="ddlSpeciality" runat="server">
                    </asp:DropDownList></td>
            </tr>
            
            <tr>
                <td colspan="2" style="text-align: center" class="lastrow"><asp:Button runat="server" ID="btnAdd" Text="添加" OnClick="btnAdd_Click" style="width:82px; height:20px;" /></td>
            </tr>
        </table>
    </div>
    </form>
    
    <script type="text/javascript">
        funSpeciality();
    </script>
</body>
</html>

