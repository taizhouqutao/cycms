<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileAdd.aspx.cs" Inherits="cycms.Web.admin.FileManager.fileAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加文件下载</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
      <div class="divmain">
          <div class="top">
                    <div class="row rowtitle">文件信息编辑</div>
                    <div class="row"> 您现在的位置：文件信息编辑</div>
          </div>
        <asp:Panel ID="pnlContent" runat="server">
        <table cellpadding="0" cellspacing="0" class="tableMain" >
            <tr>
                <td class="tableLeft">文件类型：</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlFileType"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlFileType"
                        Display="Dynamic" ErrorMessage="请选择文件类型"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="tableLeft">文件名：</td>
                <td><asp:TextBox runat="server" ID="txtFileTitle" Width="459px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFileTitle"
                        ErrorMessage="文件名必须填写"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="tableLeft">
                    文件说明：
                </td>
                <td>
                    <asp:TextBox ID="fileInfo" TextMode="MultiLine"  runat="server" Height="182px" Width="674px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tableLeft">锁定：</td>
                <td>                   
                     <asp:CheckBox runat="server" ID="chkIsLock" Text="锁定" />
                </td>           
            </tr>
            <tr>
                <td class="tableLeft" rowspan="2">上传：</td>
                <td>                   
                     <asp:FileUpload ID="FileUpload1" runat="server" Width="298px" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload1"
                        ErrorMessage="请选择文件"></asp:RequiredFieldValidator>
                </td>           
            </tr>
             
            <tr>
                <td style="height: 53px">                    
                        如果服务器上该文件名已存在文件将被重命名
                     <hr style="width:100%;" />
                    <div class='fujian'>
                        <asp:Literal runat="server" ID="litFujian"></asp:Literal> 
                    </div>     
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; height: 30px;" class="lastrow">
                    <asp:Button runat="server" ID="btnSubmit" Text="添加" OnClick="btnSubmit_Click" Height="20px" Width="82px" />
                </td>
            </tr>
        </table>
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
              ShowMessageBox="True" ShowSummary="False" />
            </asp:Panel>       
    </div>    
    </form>
</body>
</html>

