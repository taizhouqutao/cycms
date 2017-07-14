<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IpHistory.aspx.cs" Inherits="cycms.Web.admin.aspxnews.IpHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>访问记录</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
     <script src="../../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
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
                <div class="row rowtitle">访问记录</div>
                    <div class="row"> 您现在的位置：查看访问记录 
                    </div>
            </div>
            <asp:Panel ID="pnlContent" runat="server">
            <div style="text-align:left;border:solid 1px #6c94fc;background-color:#ffffff;height:26px;padding-top:4px;">
                <span style="font-weight:bold;text-indent:5px;">区间搜索：</span>
                <asp:TextBox ID="txtStart" runat="server" class="Wdate" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>至
                <asp:TextBox ID="txtEnd" runat="server" class="Wdate" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                <asp:BoundField DataField="dbo_IPAddress" DataFormatString="{0}" HeaderText="IP地址" />
                <asp:BoundField DataField="dbo_Area" DataFormatString="{0}" HeaderText="来自地区" />
                <asp:BoundField DataField="dbo_Platform" DataFormatString="{0}" HeaderText="操作系统" />
                <asp:BoundField DataField="dbo_Browser" DataFormatString="{0}" HeaderText="浏览器版本" />
                <asp:BoundField DataField="dbo_Address" DataFormatString="{0}" HeaderText="查看页面" />
                <asp:BoundField DataField="dbo_PageTitle" DataFormatString="{0}" HeaderText="页面名称" />
                <asp:BoundField DataField="dbo_ptime" DataFormatString="{0}" HeaderText="访问时间" />
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
            <asp:Button runat="server" ID="btnDelSelected" Text="批量删除" OnClick="btnDelSelected_Click" OnClientClick="return confirm('确认删除选中的记录？');" />            
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
