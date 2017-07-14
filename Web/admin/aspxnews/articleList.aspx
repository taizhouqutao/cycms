<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="articleList.aspx.cs" Inherits="cycms.Web.admin.aspxnews.articleList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>文章列表</title>
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
                <div class="row rowtitle">文章列表</div>
                    <div class="row"> 您现在的位置：查看文章列表    
                    </div>
            </div>
            <asp:Panel ID="pnlContent" runat="server">
            <div style="text-align:left;border:solid 1px #6c94fc;background-color:#ffffff;height:26px;padding-top:4px;">
                <span style="font-weight:bold;text-indent:5px;">文章搜索：</span><asp:TextBox runat="server" ID="txtKeyWord"></asp:TextBox>
                <asp:DropDownList runat="server" ID="ddlSearch">
                    <asp:ListItem Value="标题" Text="标题"></asp:ListItem>
                    <asp:ListItem Value="作者" Text="作者"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList runat="server" ID="ddlType"></asp:DropDownList>
                <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" Width="72px" />
            </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridView" CellPadding="0"
            DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging"
            OnRowDeleting="GridView1_RowDeleting" Width="100%" HeaderStyle-CssClass="GridViewHeader" BackColor="White" PageSize="15" >
            <Columns>
                <asp:TemplateField HeaderText="&lt;input type='checkbox' id='chkAll' onclick='javascript:selectAll(this)' /&gt;">
                    <ItemTemplate>                        
                        <asp:CheckBox runat="server" ID="chkSelect" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="id" DataFormatString="{0}" HeaderText="ID" />
                <asp:BoundField DataField="dbo_title" DataFormatString="{0}" HeaderText="标题" />
                <asp:BoundField DataField="dbo_author" DataFormatString="{0}" HeaderText="作者" />
                <asp:BoundField DataField="dbo_typename" DataFormatString="{0}" HeaderText="分类名称" />
                <asp:BoundField DataField="dbo_ptime" DataFormatString="{0}" HeaderText="发布时间" />
                <asp:BoundField DataField="dbo_isTop" DataFormatString="{0}" HeaderText="置顶" />
                <asp:BoundField DataField="dbo_isLock" DataFormatString="{0}" HeaderText="锁定" />                
                <asp:BoundField DataField="dbo_click" DataFormatString="{0}" HeaderText="点击次数"/>
                <asp:TemplateField HeaderText="编辑">
                    <ItemTemplate>
                        <a href='articleAdd.aspx?id=<%#DataBinder.Eval(Container.DataItem,"id")%>&spcId=<%#spcId %>'>编辑</a>    
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" 
                            OnClientClick="javascript:return confirm('确认删除？');" Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridViewHeader" />
        </asp:GridView>
        <div id="articleNav" class="articleNav">
            <asp:PlaceHolder runat="server" ID="phNav">
            
            </asp:PlaceHolder>
            <asp:Literal runat="server" ID="litCounts"></asp:Literal>
        </div>
        <div style="float:left">
            <asp:Button runat="server" ID="btnDelSelected" Text="批量删除" OnClick="btnDelSelected_Click" OnClientClick="return confirm('确认删除选中的文章？');" />            
            
            <asp:Button runat="server" ID="btnChangeType" Text="批量移到" OnClick="btnChangeType_Click" />
            <asp:DropDownList runat="server" ID="ddlType2"></asp:DropDownList>
        </div>
       </asp:Panel>
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