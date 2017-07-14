<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelUpload.aspx.cs" Inherits="cycms.Web.admin.teacherManager.ExcelUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>科研成果上传</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">        
    <div class="divmain">
        <div class="top">
            <div class="row rowtitle">科研成果上传</div>
            <div class="row"> 您现在的位置：科研成果上传</div>            
        </div>
        <table style="text-align:left;width:400px; " class="tableMain" cellpadding="0" cellspacing="0" >
            <tr>
                <td class="tableLeft">选择文件：</td>
                <td><asp:FileUpload runat="server" ID="file1" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center" class="lastrow">
                    <asp:Button runat="server" ID="btnUpload" Text="上 传" Width="76px" OnClick="btnUpload_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center" class="lastrow">
                    <a href='../../uploads/teacherInfo/科研人事行政各类成果汇编.xls'>下载当前的EXCEL</a>
                </td>
            </tr>
        </table>
         
    </div>
    </form>
</body>
</html>
