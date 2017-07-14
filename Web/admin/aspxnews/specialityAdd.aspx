<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="specialityAdd.aspx.cs" ValidateRequest="false" Inherits="cycms.Web.admin.aspxnews.specialityAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>频道编辑</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../ckeditor/ckeditor.js" ></script>
 	<script type="text/javascript" src="../../ckfinder/ckfinder.js"></script>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnAdd").click(function () {
                if ($("#chkIfshow").attr("checked") != 'checked') {
                    if ($("#txtLinkurl").val() == "") {
                        alert("如不显示描述，需要给频道一个跳转链接！");
                        $("#txtLinkurl").focus();
                        return false;
                    }
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
                    <div class="row rowtitle">频道编辑</div>
                    <div class="row"> 您现在的位置：编辑频道属性    
                    </div>
          </div>
    
        <table style="text-align:left;width:100%;" class="tableMain" cellpadding="0" cellspacing="0" >
            <tr>
                <td class="tableLeft">频道名称：</td>
                <td><asp:TextBox runat="server" ID="txtName"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">目录名称：</td>
                <td><asp:TextBox runat="server" ID="txtDir"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">是否显示描述：</td>
                <td><asp:CheckBox runat="server" ID="chkIfshow" Checked="true" /></td>
            </tr>
            <tr>
                <td class="tableLeft">链接地址：</td>
                <td><asp:TextBox runat="server" ID="txtLinkurl"></asp:TextBox>*仅对不显示描述有效</td>
            </tr>
            <tr style=" height:577px;">
                <td class="tableLeft">频道描述：</td>
                <td><asp:TextBox ID="fckContent" runat="server" CssClass="ckeditor" TextMode="MultiLine" Width="100%" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center" class="lastrow"><asp:Button runat="server" ID="btnAdd" Text="添加" OnClick="btnAdd_Click" style="width:82px; height:20px;" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
