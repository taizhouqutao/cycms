<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileTypeAdd.aspx.cs" Inherits="cycms.Web.admin.FileManager.fileTypeAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>文件类型编辑</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="divmain">
     <div class="top">
                <div class="row rowtitle">文件类型编辑</div>
                <div class="row"> 您现在的位置：文件类型编辑
                </div>
            </div>
        <div style="text-align:left;">
        <table cellpadding="0" cellspacing="0" class="tableMain" align="center" style="width:350px;">
            <tr>
                <td class="tableLeft">类型名称：</td>
                <td style="width: 280px"><asp:TextBox runat="server" ID="txtFileTypeName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="类型名成" ControlToValidate="txtFileTypeName" Display="Dynamic"></asp:RequiredFieldValidator></td>
            </tr>         
            <tr>
                <td colspan="2" style="text-align: center; height: 21px;"  class="lastrow"><asp:Button runat="server" ID="btnAdd" Text="添加文件" style="width:82px; height:20px;" OnClick="btnAdd_Click" /></td>
            </tr>
        </table>
        </div>
    </div>
    </form>
</body>
</html>