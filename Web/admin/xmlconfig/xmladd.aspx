<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xmladd.aspx.cs" Inherits="cycms.Web.admin.xmlconfig.xmladd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=titlename %></title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnAdd").click(function () {
                if ($("#txtName").val() == '') {
                    alert("链接名称不能为空！");
                    $("#txtName").focus();
                    return false;
                }
                if ($("#txtHref").val() == '') {
                    alert("链接地址不能为空！");
                    $("#txtHref").focus();
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
                    <div class="row rowtitle"><%=titlename %>编辑</div>
                    <div class="row"> 您现在的位置：编辑<%=titlename %>    
                    </div>
          </div>
    
        <table style="text-align:left;width:100%;" class="tableMain" cellpadding="0" cellspacing="0" >
            <tr>
                <td class="tableLeft">链接名称：</td>
                <td><asp:TextBox runat="server" ID="txtName"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">链接地址：</td>
                <td><asp:TextBox runat="server" ID="txtHref"></asp:TextBox></td>
            </tr>
            <asp:panel ID="Panel2" runat="server">
            <tr>
                <td class="tableLeft">描述：</td>
                <td><asp:TextBox runat="server" ID="txtContent" Height="182px" Width="674px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            </asp:panel>
            <asp:panel ID="Panel1" runat="server">
            <tr>
                <td class="tableLeft">上传图片：</td>
                <td><asp:FileUpload ID="fulimg" runat="server" /></td>
            </tr>
            <tr>
                <td class="tableLeft">图片预览：</td>
                <td>
                    <asp:Image ID="Imgshow" runat="server" Height="133" />
                </td>
            </tr>
            </asp:panel>
            <tr>
                <td colspan="2" style="text-align: center" class="lastrow"><asp:Button runat="server" ID="btnAdd" Text="添加" OnClick="btnAdd_Click" style="width:82px; height:20px;" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
