<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FriendLinkList.aspx.cs" Inherits="cycms.Web.admin.FriendLink.FriendLinkList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>首页底部图文列表</title>
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
                    <div class="row rowtitle">首页底部图文列表</div>
                    <div class="row"> 您现在的位置：首页底部图文列表   <asp:HyperLink runat="server" ID="hlkAddpage">添加图文列表</asp:HyperLink> 
                    </div>
          </div>
        <div style="text-align:left;border:solid 1px #6c94fc;background-color:#ffffff;height:26px;padding-top:4px;">
        <span style="font-weight:bold;text-indent:5px;">图文搜索：</span><asp:TextBox runat="server" ID="txtKeyWord"></asp:TextBox>
            &nbsp;
            <asp:DropDownList runat="server" ID="ddlSearchType">                
                <asp:ListItem Text="产品名称" Value="dbo_productimgname"></asp:ListItem>
                <asp:ListItem Text="合作单位" Value="dbo_factoryproductname"></asp:ListItem>
            </asp:DropDownList>
        <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" Width="72px" />
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridView"
            DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging"
            OnRowDeleting="GridView1_RowDeleting" Width="100%" HeaderStyle-CssClass="gridHeader" BackColor="White" PageSize="13">
            <Columns>                
                <asp:BoundField DataField="id" DataFormatString="{0}" HeaderText="ID" />                
                <asp:BoundField DataField="dbo_productimgname" DataFormatString="{0}" HeaderText="产品名称" />
                <asp:TemplateField HeaderText="运转图片">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <img width="98" src="<%=Adapte.sys.AppPath %><%#Eval("dbo_productimgsrc").ToString()%>" alt="<%#Eval("dbo_productimgname").ToString()%>"/>
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:BoundField DataField="dbo_productimglink" DataFormatString="{0}" HeaderText="产品链接" />
                <asp:BoundField DataField="dbo_factoryproductname" DataFormatString="{0}" HeaderText="合作单位" />
                <asp:TemplateField HeaderText="单位LOGO">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <img width="98" src="<%=Adapte.sys.AppPath %><%#Eval("dbo_factorylogosrc").ToString()%>" alt="<%#Eval("dbo_factoryproductname").ToString()%>"/>
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:BoundField DataField="dbo_factorylink" DataFormatString="{0}.aspx" HeaderText="单位链接" />     
                           
                <asp:TemplateField HeaderText="编辑">
                    <ItemTemplate>
                        <a href="FriendLinkEdit.aspx?<%# "id=" + DataBinder.Eval(Container.DataItem,"id").ToString()%>">编辑</a>
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
        <div style="float:left">
            &nbsp;&nbsp;
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

