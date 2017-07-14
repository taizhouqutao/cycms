<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="guestbookReply.aspx.cs" Inherits="cycms.Web.admin.guestbook.guestbookReply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>留言回复</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="divmain">
     <div class="top">
                <div class="row rowtitle">留言类型回复</div>
                <div class="row"> 您现在的位置：留言类型回复
                </div>
            </div>
        <div style="text-align:left;">
        <table cellpadding="0" cellspacing="0" class="tableMain" align="center" style="line-height:25px;">
            <tr>
                <td class="tableLeft">标题：</td>
                <td><asp:Literal runat="server" ID="litTitle"></asp:Literal></td>
            </tr>
             <tr>
                <td class="tableLeft">产品类型：</td>
                <td><asp:Literal runat="server" ID="litGuestTypeName"></asp:Literal></td>
            </tr>
            <tr>
                <td class="tableLeft">姓名：</td>
                <td><asp:Literal runat="server" ID="litName"></asp:Literal></td>
            </tr>
            <tr>
                <td class="tableLeft">性别：</td>
                <td><asp:Literal runat="server" ID="litSex"></asp:Literal></td>
            </tr>
            <tr>
                <td class="tableLeft">邮箱：</td>
                <td><asp:Literal runat="server" ID="litEmail"></asp:Literal></td>
            </tr>
            <tr>
                <td class="tableLeft">手机：</td>
                <td><asp:Literal runat="server" ID="litCellPhone"></asp:Literal></td>
            </tr>
            <tr>
                <td class="tableLeft">传真：</td>
                <td><asp:Literal runat="server" ID="litFlax"></asp:Literal></td>
            </tr>
            <tr>
                <td class="tableLeft">单位：</td>
                <td><asp:Literal runat="server" ID="litWorkName"></asp:Literal></td>
            </tr>
            <tr>
                <td class="tableLeft">地址：</td>
                <td><asp:Literal runat="server" ID="litAddress"></asp:Literal></td>
            </tr>
            <tr>
                <td class="tableLeft">留言时间：</td>
                <td><asp:Literal runat="server" ID="litPtime"></asp:Literal></td>
            </tr>
            <tr>
                <td class="tableLeft">留言内容：</td>
                <td><asp:Literal runat="server" ID="litContent"></asp:Literal></td>
            </tr>
            <tr>
                <td class="tableLeft">回复：</td>
                <td><asp:TextBox runat="server" ID="txtReplyContent" TextMode="MultiLine" Height="227px" Width="676px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">是否显示：</td>
                <td>
                    <asp:RadioButtonList runat="server" ID="rbtnIsShow" RepeatDirection="Horizontal">
                        <asp:ListItem Text="是" Value="True"></asp:ListItem>
                        <asp:ListItem Text="否" Value="False" Selected="true"></asp:ListItem>
                    </asp:RadioButtonList>                   
               </td>
            </tr>
            <tr>
                <td class="tableLeft">回复时间：</td>
                <td><asp:Literal runat="server" ID="litReplyTime"></asp:Literal></td>                
            </tr>            
            <tr>
                <td colspan="2" style="text-align: center; height: 21px;"  class="lastrow">
                    <asp:Button runat="server" ID="btnAdd" Text="回复" style="width:82px; height:20px;" OnClick="btnAdd_Click"  OnClientClick="if(document.getElementById('txtReplyContent').value == ''){ return confirm('回复内容为空，确认回复？')} return true;" />                
                </td>
            </tr>
        </table>
        </div>
    </div>
    </form>
</body>
</html>