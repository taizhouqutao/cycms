<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FriendLinkEdit.aspx.cs" Inherits="cycms.Web.admin.FriendLink.FriendLinkEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>首页底部图文编辑</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnAdd").click(function () {
                if ($("#txtProductImgName").val() == '') {
                    alert("产品名称不能为空！");
                    $("#txtProductImgName").focus();
                    return false;
                }
                if ($("#txtProductImgLink").val() == '') {
                    alert("产品链接不能为空！");
                    $("#txtProductImgLink").focus();
                    return false;
                }
                if ($("#txtProductInfo").val() == '') {
                    alert("描述不能为空！");
                    $("#txtProductInfo").focus();
                    return false;
                }
                if ($("#txtFactoryProductName").val() == '') {
                    alert("合作单位不能为空！");
                    $("#txtFactoryProductName").focus();
                    return false;
                }
                if ($("#txtFactoryLink").val() == '') {
                    alert("单位链接不能为空！");
                    $("#txtFactoryLink").focus();
                    return false;
                }
                return true;
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="divmain">
          <div class="top">
                    <div class="row rowtitle">首页底部图文编辑</div>
                    <div class="row"> 您现在的位置：首页底部图文编辑    
                    </div>
          </div>
    
        <table style="text-align:left;width:100%;" class="tableMain" cellpadding="0" cellspacing="0" >
            <tr>
                <td class="tableLeft">产品名称：</td>
                <td><asp:TextBox runat="server" ID="txtProductImgName"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">产品链接：</td>
                <td><asp:TextBox runat="server" ID="txtProductImgLink"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">描述：</td>
                <td><asp:TextBox runat="server" ID="txtProductInfo" Height="182px" Width="674px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">运转图片：</td>
                <td><asp:FileUpload ID="fulimg" runat="server" /></td>
            </tr>
            <tr>
                <td class="tableLeft">图片预览：</td>
                <td>
                    <asp:Image ID="Imgshow" runat="server" Height="155" Width="205"/>
                </td>
            </tr>
            <tr>
                <td class="tableLeft">合作单位：</td>
                <td><asp:TextBox runat="server" ID="txtFactoryProductName"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">单位链接：</td>
                <td><asp:TextBox runat="server" ID="txtFactoryLink"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">单位LOGO：</td>
                <td><asp:FileUpload ID="fulimgfactory" runat="server" /></td>
            </tr>
            <tr>
                <td class="tableLeft">图片预览：</td>
                <td>
                    <asp:Image ID="Imgshowfactory" runat="server" Height="62" Width="175"/>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center" class="lastrow"><asp:Button runat="server" ID="btnAdd" Text="添加" OnClick="btnAdd_Click" style="width:82px; height:20px;" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
