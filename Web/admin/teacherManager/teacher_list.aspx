<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacher_list.aspx.cs" Inherits="cycms.Web.admin.teacherManager.teacher_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>教师列表</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />   
    <script type="text/javascript">
        function selectAll(obj) {
            var grid = document.getElementById("GridView1");
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type = 'checkbox') inputs[i].checked = obj.checked;
            }
        }
        
    </script>
</head>
<body>
     <form id="form1" runat="server">
    <div class="divmain">
          <div class="top">
                    <div class="row rowtitle">教师列表</div>
                    <div class="row"> 您现在的位置：查看教师列表    
                    </div>
          </div>
        <div style="text-align:left;border:solid 1px #6c94fc;background-color:#ffffff;height:26px;padding-top:4px;">
        <span style="font-weight:bold;text-indent:5px;">搜索：</span><asp:TextBox runat="server" ID="txtKeyWord"></asp:TextBox>
            &nbsp;
            <asp:DropDownList runat="server" ID="ddlSearchType">
                <asp:ListItem Text="姓名" Selected="true" Value="dbo_name"></asp:ListItem>
                <asp:ListItem Text="学历" Value="dbo_degree"></asp:ListItem>
                <asp:ListItem Text="职称" Value="dbo_title"></asp:ListItem>
            </asp:DropDownList>            
        <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" Width="72px" />
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"  CssClass="GridView"
            DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging"
            OnRowDeleting="GridView1_RowDeleting" Width="100%" HeaderStyle-CssClass="gridHeader" BackColor="White" PageSize="13">
            <Columns>
                <asp:TemplateField HeaderText="&lt;input type='checkbox' id='chkAll' onclick='javascript:selectAll(this)' /&gt;">
                    <ItemTemplate>                        
                        <asp:CheckBox runat="server" ID="chkSelect" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="id" DataFormatString="{0}" HeaderText="ID" />
                <asp:BoundField DataField="dbo_loginName" DataFormatString="{0}" HeaderText="登陆名" />
                <asp:BoundField DataField="dbo_name" DataFormatString="{0}" HeaderText="真实姓名" />
                <asp:BoundField DataField="dbo_title" DataFormatString="{0}" HeaderText="职称" />
                <asp:BoundField DataField="dbo_email" DataFormatString="{0}" HeaderText="邮箱" />
                <asp:BoundField DataField="dbo_officePhone" DataFormatString="{0}" HeaderText="办公电话" />                
                <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="teacherInfo.aspx?id={0}"
                    DataTextField="id" DataTextFormatString="详细信息" HeaderText="详细信息" />
                <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="teacherEdit2.aspx?id={0}"
                    DataTextField="id" DataTextFormatString="编辑" HeaderText="编辑" />
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            OnClientClick="javascript:return confirm('确认删除？');" Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridViewHeader" />
        </asp:GridView>
        <div style="float:left">
            <asp:Button runat="server" ID="btnDelSelected" Text="批量删除" OnClick="btnDelSelected_Click" OnClientClick="return confirm('确认删除选中的内容？');" />
            &nbsp;
        </div>
       
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