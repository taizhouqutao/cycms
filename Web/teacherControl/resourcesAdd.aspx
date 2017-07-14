<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resourcesAdd.aspx.cs" Inherits="cycms.Web.teacherControl.resourcesAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加资源</title>
    <link href="../admin/css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <form id="form1" runat="server">
    <div class="divmain">
          <div class="top">
                    <div class="row rowtitle">添加资源</div>
                    <div class="row"> 您现在的位置：添加资源    
                    </div>
          </div>
          <table cellpadding="0" cellspacing="0" class="tableMain" >          
            <tr>
                <td class="tableLeft">资源名名：</td>
                <td><asp:TextBox runat="server" ID="txtFileTitle" Width="459px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFileTitle"
                        ErrorMessage="文件名必须填写"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="tableLeft">
                    资源说明：
                </td>
                <td>
                    <asp:TextBox ID="fileInfo" TextMode="MultiLine"  runat="server" Height="182px" Width="674px"></asp:TextBox>
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
                <td  class="tableLeft">下载密码：</td>
                <td><asp:TextBox runat="server" ID="txtDownPwd"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;输入下载密码，为空则不需要密码</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; height: 30px;" class="lastrow">
                    <asp:Button runat="server" ID="btnSubmit" Text="添加" OnClick="btnSubmit_Click" Height="20px" Width="82px" />
                </td>
            </tr>
        </table>
    </div>
     <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
              ShowMessageBox="True" ShowSummary="False" />
    </form>
</body>
</html>
