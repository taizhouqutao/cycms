<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addressList.aspx.cs" Inherits="cycms.Web.teacherControl.addressList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>员工通讯录</title>
    <link href="../admin/css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #GridView1 td{ text-align:center;}
        #GridView1 td a,#GridView1 td a:visited,#GridView1 td span{ text-align:center;display:block; padding:2px 8px;}
        #GridView1 td a:hover{background-color:#ffffff; color:#000000;}
    </style>   
</head>
<body>
     <form id="form1" runat="server">
    <div class="divmain">
          <div class="top">
                    <div class="row rowtitle">员工通讯录</div>
                    <div class="row"> 您现在的位置：员工通讯录    
                    </div>
          </div>
        <div style="text-align:left;border:solid 1px #6c94fc;background-color:#ffffff;height:26px;padding-top:4px;">
            <span style="font-weight:bold;text-indent:5px;">搜索：</span><asp:TextBox runat="server" ID="txtKeyWord"></asp:TextBox>
                &nbsp;
                <asp:DropDownList runat="server" ID="ddlSearchType">
                    <asp:ListItem Text="姓名" Value="dbo_Name"></asp:ListItem>
                    <asp:ListItem Text="办公电话" Value="dbo_OfficePhone"></asp:ListItem>
                    <asp:ListItem Text="住宅电话" Value="dbo_HomePhone"></asp:ListItem>
                    <asp:ListItem Text="手机" Value="dbo_MobilePhone"></asp:ListItem>
                    <asp:ListItem Text="虚拟网" Value="dbo_ShortNumber"></asp:ListItem>
                    <asp:ListItem Text="电子邮件" Value="dbo_Email"></asp:ListItem>
                </asp:DropDownList>                
            <asp:Button runat="server" ID="btnSearch" Text="搜索" Width="72px" OnClick="btnSearch_Click" />
        </div>       
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="GridView" DataKeyNames="id"
            Width="100%" HeaderStyle-CssClass="gridHeader" BackColor="White" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="13" >    
            <HeaderStyle CssClass="GridViewHeader" />
            <Columns>
                <asp:BoundField DataField="dbo_Name" DataFormatString="{0}" HeaderText="姓名" />
                <asp:BoundField DataField="dbo_OfficePhone" DataFormatString="{0}" HeaderText="办公电话" />
                <asp:BoundField DataField="dbo_HomePhone" DataFormatString="{0}" HeaderText="住宅电话" />
                <asp:BoundField DataField="dbo_MobilePhone" DataFormatString="{0}" HeaderText="手机" />
                <asp:BoundField DataField="dbo_ShortNumber" DataFormatString="{0}" HeaderText="虚拟网" />
                <asp:BoundField DataField="dbo_Email" DataFormatString="{0}" HeaderText="电子邮件" />
            </Columns>
        </asp:GridView>    
    </div>
    
    </form>
     <script type="text/javascript">
         var grid = document.getElementById("GridView1");
         if (grid != null) {
             var trs = grid.getElementsByTagName("tr");
             for (var i = 1; i < trs.length; i++) {
                 trs[i].onmouseover = function () { this.style.backgroundColor = '#ccffff'; }
                 trs[i].onmouseout = function () { this.style.backgroundColor = '#ffffff'; }
             }
         }        
        </script>    
</body>
</html>
