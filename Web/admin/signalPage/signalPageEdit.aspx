<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signalPageEdit.aspx.cs" Inherits="cycms.Web.admin.signalPage.signalPageEdit" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑单独页面</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../ckeditor/ckeditor.js" ></script>
 	<script type="text/javascript" src="../../ckfinder/ckfinder.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<div class="divmain">
          <div class="top">
                    <div class="row rowtitle">编辑单独页面</div>
                    <div class="row"> 您现在的位置：编辑单独页面 
                                <asp:HyperLink runat="server" ID="hlkEditContent"></asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:HyperLink runat="server" ID="hlkEditTemplate"></asp:HyperLink> 
                    </div>
          </div>
        <asp:Panel ID="pnlContent" runat="server">
        <table cellpadding="0" cellspacing="0" class="tableMain">
            
            <tr>
                <td class="tableLeft">文件名：</td>
                <td><asp:TextBox runat="server" ID="txtFileName" Width="195px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFileName"
                        ErrorMessage="文件名必须填写" Display="Dynamic"></asp:RequiredFieldValidator>不需要写文件后缀</td>
            </tr>
            
            <tr>
                <td class="tableLeft">标题：</td>
                <td><asp:TextBox runat="server" ID="txtTitle" Width="495px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="标题必须填写"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="tableLeft">是否导航显示：</td>
                <td><asp:CheckBox runat="server" ID="chkIfshow" Checked="true" /></td>
            </tr>
            <tr>
                <td class="tableLeft" style="height:20px;">页面路径：</td>
                <td>
                    <asp:Literal runat="server" id="litPagePath"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td style="height: 577px" class="tableLeft">
                    内容：
                    <br />
                </td>
                <td style="height: 577px;" >
                    <asp:TextBox ID="fckContent" runat="server" CssClass="ckeditor" TextMode="MultiLine" Width="100%" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; height: 30px;" class="lastrow"><asp:Button runat="server" ID="btnSubmit" Text="保存" Height="20px" Width="82px" OnClick="btnSubmit_Click" />
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <input type="button" value="返回" id="btnBackToList" runat="server" style="width:82px; height:20px;" /> 
                </td>
            </tr>
        </table>
       </asp:Panel>  
       
       <asp:Panel runat="server" ID="pnlTemplate" Visible="false">
             <div>
                <asp:TextBox runat="server" ID="txtContent" Width="100%" Height="670" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div style="margin-top:10px;">            
                <asp:Button runat="server" Text="保存" ID="btnEditTemplate" Width="62px" OnClick="btnEditTemplate_Click" />
            </div>
       </asp:Panel>
            
    </div>
    </form>
</body>
</html>
