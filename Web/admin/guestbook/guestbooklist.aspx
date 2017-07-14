<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="guestbooklist.aspx.cs" Inherits="cycms.Web.admin.guestbook.guestbooklist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>留言列表</title>
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
                    <div class="row rowtitle">>留言列表</div>
                    <div class="row"> 您现在的位置：查看留言列表    
                    </div>
          </div>
        <div style="text-align:left;border:solid 1px #6c94fc;background-color:#ffffff;height:26px;padding-top:4px;">
        <span style="font-weight:bold;text-indent:5px;">留言搜索：</span><asp:TextBox runat="server" ID="txtKeyWord"></asp:TextBox>
            &nbsp;
            <asp:DropDownList runat="server" ID="ddlSearchType">
                <asp:ListItem Text="标题" Value="dbo_title" Selected="true"></asp:ListItem>
                <asp:ListItem Text="姓名" Value="dbo_name"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:DropDownList runat="server" ID="ddlGuestType"></asp:DropDownList>
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
                <asp:BoundField DataField="dbo_title" DataFormatString="{0}" HeaderText="标题" />
                <asp:BoundField DataField="dbo_name" DataFormatString="{0}" HeaderText="留言者" />
                <asp:BoundField DataField="dbo_ptime" DataFormatString="{0}" HeaderText="时间" />
                <asp:BoundField DataField="dbo_email" DataFormatString="{0}" HeaderText="邮箱" />
                <asp:BoundField DataField="dbo_isreply" DataFormatString="{0}" HeaderText="是否回复" />                
                <asp:BoundField DataField="dbo_isShow" DataFormatString="{0}" HeaderText="是否显示" />
                <asp:BoundField DataField="dbo_TypeName" DataFormatString="{0}" HeaderText="留言对象" />
                
                <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="guestbookReply.aspx?id={0}"
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
        <div id="articleNav" class="articleNav">
            <asp:PlaceHolder runat="server" ID="phNav">
            
            </asp:PlaceHolder>
            <asp:Literal runat="server" ID="litCounts"></asp:Literal>
        </div>
        <div style="float:left">
            <asp:Button runat="server" ID="btnDelSelected" Text="批量删除" OnClick="btnDelSelected_Click" OnClientClick="return confirm('确认删除选中的文章？');" />
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
