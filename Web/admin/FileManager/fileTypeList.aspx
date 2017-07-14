<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileTypeList.aspx.cs" Inherits="cycms.Web.admin.FileManager.fileTypeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>文件类型列表</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />     
</head>
<body>
     <form id="form1" runat="server">
    <div class="divmain">
          <div class="top">
                    <div class="row rowtitle">文件类型列表</div>
                    <div class="row"> 您现在的位置：文件类型列表    
                    </div>
          </div>
       
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"  CssClass="GridView"
            DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging"
            OnRowDeleting="GridView1_RowDeleting" Width="100%" HeaderStyle-CssClass="gridHeader" BackColor="White" PageSize="13">
            <Columns>                
                <asp:BoundField DataField="id" DataFormatString="{0}" HeaderText="ID" />
                <asp:BoundField DataField="dbo_typeName" DataFormatString="{0}" HeaderText="类型名" />
                <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="fileTypeAdd.aspx?id={0}"
                    DataTextField="id" DataTextFormatString="编辑" HeaderText="编辑" />    
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            OnClientClick="javascript:return confirm('确认删除该类型并且删除类型下的所有文件？');" Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridViewHeader" />
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
