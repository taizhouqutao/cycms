<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="information.aspx.cs" Inherits="cycms.Web.teacherControl.information" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
<style type="text/css">
body {
	font-family: Arial, Helvetica, sans-serif;
	font-size:12px;
	color:#666666;
	background:#fff;
	text-align:center;

}
ul{
text-decoration:none;
}

* {
	margin:0;
	padding:0;
}

a {
	color:#1E7ACE;
	text-decoration:none;	
}

a:hover {
	color:#000;
	text-decoration:underline;
}
h3 {
	font-size:14px;
	font-weight:bold;
}

pre,p {
	color:#1E7ACE;
	margin:4px;
}
input, select,textarea {
	padding:1px;
	margin:2px;
	font-size:11px;
}
.buttom{
	padding:1px 10px;
	font-size:12px;
	border:1px #1E7ACE solid;
	background:#D0F0FF;
}
#formwrapper {
	width:720px;
	margin:10px auto;
	padding:15px;
	text-align:left;
	border:1px #1E7ACE solid;
}

fieldset {
    width:700px;
	padding:10px;
	margin-top:5px;
	border:1px solid #1E7ACE;
	background:#fff;
}

fieldset legend {
	color:#1E7ACE;
	font-weight:bold;
	padding:3px 20px 3px 20px;
	border:1px solid #1E7ACE;	
	background:#fff;
}
fieldset div{   
    float:left;
    margin-top:8px;
}
fieldset label {
	float:left;
	width:120px;
	text-align:right;
	padding:4px;
	margin:1px;
}

.enter{ text-align:center;}
.clear {
	clear:both;
}
.nodisplay{ display:none;}
.grid{border:solid 1px #1E7ACE; border-right-width:0px; line-height:20px;padding:0px;margin:0px;}
.grid td, .grid th{border-bottom:solid 1px #1E7ACE; line-height:20px; border-right:solid 1px #1E7ACE; text-align:center}
</style>
    <script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="formwrapper">
	<fieldset>
		<legend>基本信息</legend>
		<div style="border:1px solid #1E7ACE; margin-top:23px; padding:5px 5px 5px 5px; width:165px; height:155px; text-align:center;vertical-align:middle;">
		    <asp:Image ID="photo" runat="server" Width="165" Height="125" />
            <div style="font-size:12px;"><asp:FileUpload runat="server" ID="file1" Width="165px" /></div>
        </div>
        <div style="margin-left:20px; ">
            <fieldset style="width:480px;">
		    <legend>公开信息</legend>
		        <div>
                    <ul>
                        <li>登&nbsp;&nbsp;陆&nbsp;&nbsp;名：<asp:TextBox ID="txtLoginName" Enabled="false" runat="server"></asp:TextBox></li>
                        <li>姓　　名：<asp:TextBox ID="name" runat="server"></asp:TextBox></li>
                        <li>职　　称：<asp:TextBox ID="title" runat="server"></asp:TextBox></li>
                        <li>毕业院校：<asp:TextBox ID="school" runat="server"></asp:TextBox></li>                        
                        <li>性　　别：<asp:TextBox ID="sex" runat="server"></asp:TextBox></li>
                    </ul>
                </div>
                <div style="margin-left:50px;">
                    <ul>
                        <li>所学专业：<asp:TextBox ID="txtProfessional" runat="server"></asp:TextBox></li>   
                        <li>学　　位：<asp:TextBox ID="degree" runat="server"></asp:TextBox></li>    
                        <li>学　　历：<asp:TextBox ID="xueli" runat="server"></asp:TextBox></li>         
                        <li>邮　　箱：<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></li>
                        <li>备　　注：<asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox></li>
                    </ul>
                </div>
            </fieldset>
        </div>
       
        <fieldset style="text-align:left;width:680px;">
		    <legend>其他信息(非公开)</legend>
		         <div style="margin-left:10px;">
                    <ul>
                        <li>出生年月：<asp:TextBox ID="birthday" runat="server" class="Wdate" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox></li>
                        <li>籍　　贯：<asp:TextBox runat="server" ID="txtJiGuan"></asp:TextBox></li>
                        <li>工作时间：<asp:TextBox ID="work_time" runat="server" class="Wdate" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox></li>
                        <li>聘任时间：<asp:TextBox ID="emp_time" runat="server" class="Wdate" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox></li>
                    </ul>
                </div>
                <div style="margin-left:20px;">
                    <ul>                        
                        <li>民　　族：<asp:TextBox ID="minzu" runat="server"></asp:TextBox></li>
                        <li>党　　派：<asp:TextBox ID="party" runat="server"></asp:TextBox></li>
                        <li>入党时间：<asp:TextBox ID="party_time" runat="server" class="Wdate" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox></li>
                        <li>家庭地址：<asp:TextBox runat="server" ID="txtHomeAddress"></asp:TextBox></li>
                    </ul>
                </div>
                <div style="margin-left:20px;">
                    <ul>
                        <li>办公电话：<asp:TextBox runat="server" ID="txtOfficePhone"></asp:TextBox></li>
                        <li>住宅电话：<asp:TextBox runat="server" ID="txtHomePhone"></asp:TextBox></li>
                        <li>手　　机：<asp:TextBox runat="server" ID="txtMobilePhone"></asp:TextBox></li>
                        <li>虚&nbsp;&nbsp;拟&nbsp;&nbsp;网：<asp:TextBox runat="server" ID="txtShortNum"></asp:TextBox></li>
                   </ul>
                </div>
	    </fieldset>
	</fieldset>
	
	<fieldset>
		<legend>个人简介</legend>
		<div>
			<asp:TextBox ID="info_base" runat="server" TextMode="MultiLine" Width="680" Height="180"></asp:TextBox>
		</div>
	</fieldset>
	<fieldset>
		<legend>技术专长</legend>
		<div>
			<asp:TextBox ID="info_study" runat="server" TextMode="MultiLine" Width="680" Height="180"></asp:TextBox>
		</div>
	</fieldset>
	<div style="text-align:center;"><asp:Button ID="saveBtn" runat="server" CssClass="buttom" Text="保存修改" OnClick="saveBtn_Click" /></div>
	
    <fieldset>
		<legend>工作简历</legend>
		<div>
		    <a name="#resumes1"></a>
		    <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" Width="100%" CssClass="grid" DataKeyNames="id" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="dbo_startTime" DataFormatString="{0}" HeaderText="开始时间" />
                    <asp:BoundField DataField="dbo_endTime" DataFormatString="{0}" HeaderText="结束时间" />
                    <asp:BoundField DataField="dbo_unit" DataFormatString="{0}" HeaderText="工作单位" />
                    <asp:BoundField DataField="dbo_duty" DataFormatString="{0}" HeaderText="职务" />
                    <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="myEdit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>'
                                Text="编辑"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('确认删除？');"
                                Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
               </Columns>
		    </asp:GridView>		    
		    <input type="button" id="btnAdd1" class="buttom" value="增加" onclick="document.getElementById('pnl1').style.display = 'block'; this.style.display='none'" />
		    <asp:Panel runat="server" ID="pnl1" Width="100%" CssClass="nodisplay" style="display:none">
		         开始时间：<asp:TextBox runat="server" ID="txtStartTime1" Width="103px"></asp:TextBox>
		         结束时间：<asp:TextBox runat="server" ID="txtendTime1" Width="103px"></asp:TextBox>
		         工作单位：<asp:TextBox runat="server" ID="txt_workunit" Width="102px"></asp:TextBox>
		         职务：<asp:TextBox runat="server" ID="txt_workduty"></asp:TextBox><br />
		        <asp:Button runat="server" ID="btnSubmit1" Text="提交" CssClass="buttom" OnClick="btnSubmit1_Click"  />
		        
		       <asp:Button runat="server" ID="btnCancel1" Text="取消" CssClass="buttom" OnClick="btnCancel1_Click"/>
		        <!--<input type="button" class="buttom" value="取消" onclick="" /> -->
		    </asp:Panel>		    
		</div>
	</fieldset>	
	
	<fieldset>
		<legend>学习进修简历</legend>
		<div>
	        <a name="#resumes2"></a>
		    <asp:GridView runat="server" ID="GridView2" AutoGenerateColumns="False" Width="100%" CssClass="grid" DataKeyNames="id" OnRowCommand="GridView2_RowCommand" OnRowDeleting="GridView2_RowDeleting" >
                <Columns>
                    <asp:BoundField DataField="dbo_startTime" DataFormatString="{0}" HeaderText="开始时间" />
                    <asp:BoundField DataField="dbo_endTime" DataFormatString="{0}" HeaderText="结束时间" />
                    <asp:BoundField DataField="dbo_school" DataFormatString="{0}" HeaderText="学习学校" />
                    <asp:BoundField DataField="dbo_professional" DataFormatString="{0}" HeaderText="专业" />
                    <asp:BoundField DataField="dbo_graduateTime" DataFormatString="{0}" HeaderText="毕业时间" />
                      <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="myEdit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>'
                                Text="编辑"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('确认删除？');"
                                Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
		    </asp:GridView>
		    <input type="button" id="btnAdd2" class="buttom" value="增加" onclick="document.getElementById('pnl2').style.display = 'block'; this.style.display='none'" />
		    <asp:Panel runat="server" ID="pnl2" Width="100%" CssClass="nodisplay" style="display:none">
		         开始时间：<asp:TextBox runat="server" ID="txtStartTime2" Width="103px"></asp:TextBox>
		         结束时间：<asp:TextBox runat="server" ID="txtendTime2" Width="103px"></asp:TextBox>
		         学习学校：<asp:TextBox runat="server" ID="txtSchool" Width="103px"></asp:TextBox>
		         专业：<asp:TextBox runat="server" ID="txtStudyProfessional" Width="103px"></asp:TextBox>
                <br />
		         毕业时间：<asp:TextBox runat="server" ID="txtGraduateTime" Width="103px"></asp:TextBox>
                <br />
		        <asp:Button runat="server" ID="btnSubmit2" Text="提交" CssClass="buttom" OnClick="btnSubmit2_Click" />
		        
		       <asp:Button runat="server" ID="btnCancel2" Text="取消" CssClass="buttom" OnClick="btnCancel2_Click" />
		        <!--<input type="button" class="buttom" value="取消" onclick="" /> -->
		    </asp:Panel>
		</div>
	</fieldset>
	

	<fieldset>
		<legend>在岗简历</legend>
		<div>
			<a name="#resumes3"></a>
		    <asp:GridView runat="server" ID="GridView3" AutoGenerateColumns="False" Width="100%" CssClass="grid" DataKeyNames="id" OnRowCommand="GridView3_RowCommand" OnRowDeleting="GridView3_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="dbo_startTime" DataFormatString="{0}" HeaderText="开始时间" />
                    <asp:BoundField DataField="dbo_endTime" DataFormatString="{0}" HeaderText="结束时间" />
                    <asp:BoundField DataField="dbo_theClass" DataFormatString="{0}" HeaderText="班级" />
                    <asp:BoundField DataField="dbo_result" DataFormatString="{0}" HeaderText="成绩效果" />
                    <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="myEdit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>'
                                Text="编辑"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="删除" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('确认删除？');"
                                Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                
		    </asp:GridView>	
		    <input type="button" id="btnAdd3" class="buttom" value="增加" onclick="document.getElementById('pnl3').style.display = 'block'; this.style.display='none'" />
		    <asp:Panel runat="server" ID="pnl3" Width="100%" CssClass="nodisplay" style="display:none">
		         开始时间：<asp:TextBox runat="server" ID="txtStartTime3" Width="103px"></asp:TextBox>
		         结束时间：<asp:TextBox runat="server" ID="txtendTime3" Width="103px"></asp:TextBox>
		         部门：<asp:TextBox runat="server" ID="txtTheClass" Width="102px"></asp:TextBox>
		         成绩效果：<asp:TextBox runat="server" ID="txtResult"></asp:TextBox>
		        <asp:Button runat="server" ID="btnSubmit3" Text="提交" CssClass="buttom" OnClick="btnSubmit3_Click"/>		        
		       <asp:Button runat="server" ID="btnCancel3" Text="取消" CssClass="buttom" OnClick="btnCancel3_Click"/>
		        <!--<input type="button" class="buttom" value="取消" onclick="" /> -->
		    </asp:Panel>		
		</div>
	</fieldset>
	<!--
	<fieldset>
		<legend>其他教育工作信息</legend>
		<div>
			<asp:TextBox ID="info_teac" runat="server" TextMode="MultiLine" Width="680" Height="180"></asp:TextBox>
		</div>
	</fieldset>
	-->
</div>
</form>
</body>
</html>
