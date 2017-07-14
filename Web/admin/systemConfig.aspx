<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="systemConfig.aspx.cs" Inherits="cycms.Web.admin.systemConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>系统设置</title>
     <link href="css/common.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
       .td1{width:100px; text-align:right; height:20px;}
       .td2{text-align:left; padding-left:10px;}
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="divmain">
         <div class="top">
            <div class="row rowtitle">系统设置</div>
            <div class="row"> 您现在的位置：系统设置</div>
         </div>
         <fieldset>
            <legend>站点基本信息</legend>
            <table cellpadding="0" cellspacing="0" border="0">
            
                <tr>
                    <td class="td1">网站地址：</td>
                    <td class="td2" style="width: 278px"><asp:TextBox runat="server" ID="txtWebAddress"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td class="td1">网站名称：</td>
                    <td class="td2" style="width: 278px"><asp:TextBox runat="server" ID="txtWebName"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="td1">备案号：</td>
                    <td class="td2" style="width: 278px"><asp:TextBox runat="server" ID="txtBeiAnHao"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="td1">联系人：</td>
                    <td class="td2" style="width: 278px"><asp:TextBox runat="server" ID="txtLianXiRen"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="td1">手机：</td>
                    <td class="td2" style="width: 278px"><asp:TextBox runat="server" ID="txtCellPhone"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="td1">电话：</td>
                    <td class="td2" style="width: 278px"><asp:TextBox runat="server" ID="txtWorkPhone"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="td1">传真：</td>
                    <td class="td2" style="width: 278px"><asp:TextBox runat="server" ID="txtFlax"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="td1">公司地址：</td>
                    <td class="td2" style="width: 278px"><asp:TextBox runat="server" ID="txtWorkPlace" Width="400"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="td1">站点是否开放：</td>
                    <td class="td2" style="width: 278px"><asp:CheckBox runat="server" ID="chkSysIsRun" Text="开放站点" /></td>
                </tr>
            </table>
         </fieldset>
         
         <fieldset>
            <legend>系统模式</legend>
           
           <asp:RadioButtonList runat="server" ID="rbtnIsStatic">
                <asp:ListItem Value="0" Text="静态模式"></asp:ListItem>
                <asp:ListItem Value="1" Text="动态模式"></asp:ListItem>
           </asp:RadioButtonList>
           <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td class="td1">提示1：</td>
                    <td class="td2">在静态模式下系统将自动生成频道首页和对应列表及内容页保存于服务器上。要求在服务器上有读取，写入和修改的权限</td>
                </tr>
                 <tr>
                    <td class="td1">提示2：</td>
                    <td class="td2">在动态模式下在用户如不指定则不生成任何文件，所有交互均通过数据库</td>
                </tr>
                 <tr>
                    <td class="td1">提示3：</td>
                    <td class="td2">静态模式和动态模式的区别：静态模式不需要频繁的与数据库交互，速度相对较快，适合于要求速度较快的站点。<br />
                                    动态模式不需要在服务器上生成文件，但需要频繁的与数据库交互，相对速度较慢，适合于修改频繁的站点。
                    </td>
                </tr>
                  <tr>
                    <td class="td1">提示4：</td>
                    <td class="td2">在动态模式下可以生成频道首页以提高访问速度和效率</td>
                </tr>
           </table>
         </fieldset>
         <div><asp:Button runat="server" ID="btnSave" Text="保存信息" OnClick="btnSave_Click" /></div>
    </div>
    </form>
</body>
</html>