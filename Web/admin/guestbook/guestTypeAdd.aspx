<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="guestTypeAdd.aspx.cs" Inherits="cycms.Web.admin.guestbook.guestTypeAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>留言类型</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="divmain">
     <div class="top">
                <div class="row rowtitle">留言类型编辑</div>
                <div class="row"> 您现在的位置：留言类型编辑
                </div>
            </div>
        <div style="text-align:left;">
        <table cellpadding="0" cellspacing="0" class="tableMain" align="center" style="width:350px;">
            <tr>
                <td class="tableLeft">类型名：</td>
                <td style="width: 280px"><asp:TextBox runat="server" ID="txtTypeName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入类型名" ControlToValidate="txtTypeName" Display="Dynamic"></asp:RequiredFieldValidator></td>
            </tr>           
            <tr>
                <td colspan="2" style="text-align: center; height: 21px;"  class="lastrow"><asp:Button runat="server" ID="btnAdd" Text="添加类型" style="width:82px; height:20px;" OnClick="btnAdd_Click" />                
                </td>
            </tr>
        </table>
        </div>
    </div>
    </form>
</body>
</html>