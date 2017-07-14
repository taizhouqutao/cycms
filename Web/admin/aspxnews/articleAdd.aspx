<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="articleAdd.aspx.cs" Inherits="cycms.Web.admin.aspxnews.articleAdd" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加文章</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #divFileUploads{margin:0px;padding:0px;}
        #divFileUploads li{list-style-type:none;}
        .fujian ul{padding:0px; margin:0px;}
        .fujian ul li{list-style-image:none;}
    </style>
    <script type="text/javascript" src="../../ckeditor/ckeditor.js" ></script>
 	<script type="text/javascript" src="../../ckfinder/ckfinder.js"></script>
    <script type="text/javascript">
        var strpower = "0";
        function f() {
            var srange = document.getElementById("txtClick").value;
            var patrn = /^[0-9]{1,20}$/;
            if (srange != "" && !patrn.exec(srange)) {
                document.getElementById("txtClick").value = strpower;
                return false;
            }
            strpower = srange;
        }

        var fileCount = 0;
        function AddFile() {
            fileCount++;
            var theul = document.getElementById("divFileUploads");
            var tagli = document.createElement("li");
            var tagfile = document.createElement("input");
            tagfile.type = "file";
            tagfile.name = "file";
            tagfile.size = "50";
            var tagbtn = document.createElement("input");
            tagbtn.onclick = deleteElement(tagbtn);
            tagbtn.type = "button";
            tagbtn.height = "20";
            tagbtn.value = "删除";

            tagli.appendChild(tagfile);
            tagli.appendChild(tagbtn);
            theul.appendChild(tagli);
        }
        function deleteElement(obj) {
            var theul = document.getElementById("divFileUploads");
            var f = function () {
                theul.removeChild(obj.parentNode);
            }
            return f;
        }

        //删除已有的附件
        function deleteFile(obj) {
            var theul = document.getElementById("fujian");
            theul.removeChild(obj.parentNode);

            fillFujianContent();
        }
        function fillFujianContent() {
            var oldfujian = document.getElementById("_fujianOld");
            oldfujian.value = getFujians();
        }

        function getFujians() {
            var strFujians = "";
            if (document.getElementById("fujian") != null) {
                var lis = document.getElementById("fujian").getElementsByTagName("li");
                for (var i = 0; i < lis.length; i++) {
                    var tagA = lis[i].getElementsByTagName("a");
                    if (tagA.length == 1) {
                        strFujians += (strFujians == "") ? tagA[0].innerHTML : "/" + tagA[0].innerHTML;
                    }
                }
            }
            return strFujians;
        }
       
        
    </script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <asp:Label id="lblFileMessage" runat="server" ForeColor="Red"></asp:Label>
      <div class="divmain">
          <div class="top">
                    <div class="row rowtitle">添加文章</div>
                    <div class="row"> 您现在的位置：编辑文章</div>
          </div>
        <asp:Panel ID="pnlContent" runat="server">
        <table cellpadding="0" cellspacing="0" class="tableMain">         
            <tr>
                <td class="tableLeft">文章类别：</td>
                <td><asp:DropDownList runat="server" ID="ddlType" Width="240px"></asp:DropDownList>
                    <asp:Label ID="lblTypeMessage" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td class="tableLeft">标题：</td>
                <td><asp:TextBox runat="server" ID="txtTitle" Width="495px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="标题必须填写"></asp:RequiredFieldValidator></td>
            </tr>   
            <tr>
                <td class="tableLeft">作者：</td>
                <td><asp:TextBox runat="server" ID="txtAuthor" Width="173px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">来源：</td>
                <td><asp:TextBox runat="server" ID="txtSource" Width="172px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableLeft">点击次数：</td>
                <td><asp:TextBox runat="server" ID="txtClick" Width="103px" onkeyup="javascript:f();" Text="0"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 577px" class="tableLeft">
                    内容：
                    <br />
                    <asp:CheckBox ID="chkDownPic" Checked="true" runat="server" Text="下载文章中图片" />
                    <asp:CheckBox ID="chkIsAddImgToDb" runat="server" Text="添加到滚动图片" />
                    <asp:CheckBox ID="chkIsAddShuiYinToImg" runat="server" Text="图片中添加水印" /> 
                    <asp:CheckBox ID="chkIsLock" runat="server" Text="锁定" />  
                    <asp:CheckBox ID="chkIsTop" runat="server" Text="置顶" />                      
                    </td>
                <td style="height: 577px;" >
                    <asp:TextBox ID="fckContent" runat="server" CssClass="ckeditor" TextMode="MultiLine" Width="100%" ></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="tableLeft" rowspan="2">附件：</td>
                <td>
                    <ul id="divFileUploads" ></ul>
                </td>           
            </tr>
            <tr>
                <td>
                    <input type="button" id="btnAddFile" value="添加附件" onclick="javascript:AddFile()" />
                    <hr style="width:100%;" />
                    <div class='fujian'>
                        <asp:Literal runat="server" ID="litFujian"></asp:Literal> 
                    </div>          
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; height: 30px;" class="lastrow"><asp:Button runat="server" ID="btnSubmit" Text="添加" OnClick="btnSubmit_Click" Height="20px" Width="82px" />
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <input type="button" value="返回" runat="server" id="btnBackToList" style="width:82px; height:20px;" onclick="javascript:window.location.href='articleList.aspx'"  /> 
                </td>
            </tr>
        </table>
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
              ShowMessageBox="True" ShowSummary="False" />
       </asp:Panel>       
    </div>
    <input type="hidden" name="_fujianOld" id="_fujianOld" value="" />
    <script type="text/javascript">
        fillFujianContent();
    </script>
    
    </form>
</body>
</html>
