<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="templateEdit.aspx.cs" Inherits="cycms.Web.admin.aspxnews.templateEdit"  ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>模板编辑</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    html{height:100%;}
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div class="divmain">
            <div class="top">
                <div class="row rowtitle">模板编辑</div>
                    <div class="row"> 您现在的位置：<asp:Literal runat="server" id="litEditType"></asp:Literal>模板编辑
                               &nbsp;&nbsp;&nbsp;&nbsp;选择要编辑的模板：<asp:Literal runat="server" ID="litSelectEditTpe"></asp:Literal>
                    </div>
            </div>
            <div>
                <asp:TextBox runat="server" ID="txtContent" Width="100%" Height="670" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div style="margin-top:10px;">
            
                <asp:Button runat="server" Text="保存" ID="btnSave" OnClick="btnSave_Click" Width="62px" />
            </div>
    </div>
    </form>
</body>
</html>