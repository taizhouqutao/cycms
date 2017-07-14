<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacherInfo.aspx.cs" Inherits="cycms.Web.admin.teacherManager.teacherInfo" %>

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
li{height:25px; width:200px;}

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
</head>
<body>
    <form id="form1" runat="server">
    <div id="formwrapper">
	<fieldset>
		<legend>基本信息</legend>
		<div style="border:1px solid #1E7ACE; margin-top:28px; padding:5px 5px 5px 5px; width:165px; height:143px; text-align:center;vertical-align:middle;">
		    <asp:Image ID="photo" runat="server" Width="165" Height="125" />
        </div>
        <div style="margin-left:20px; ">
            <fieldset style="width:480px;">
		    <legend>公开信息</legend>
		        <div>
                    <ul>
                        <li>登&nbsp;&nbsp;陆&nbsp;&nbsp;名：<asp:Literal runat="server" ID="litLoginName"></asp:Literal></li>
                        <li>姓　　名：<asp:Literal runat="server" ID="litname"></asp:Literal></li>
                        <li>职　　称：<asp:Literal runat="server" ID="littitle"></asp:Literal></li>
                        <li>毕业院校：<asp:Literal runat="server" ID="litschool"></asp:Literal></li>                        
                        <li>性　　别：<asp:Literal runat="server" ID="litsex"></asp:Literal></li>
                    </ul>
                </div>
                <div style="margin-left:50px;">
                    <ul>
                        <li>所学专业：<asp:Literal runat="server" ID="litProfessional"></asp:Literal></li>
                        <li>学　　位：<asp:Literal runat="server" ID="litdegree"></asp:Literal></li>    
                        <li>学　　历：<asp:Literal runat="server" ID="litxueli"></asp:Literal></li>         
                        <li>邮　　箱：<asp:Literal runat="server" ID="litEmail"></asp:Literal></li>                                 
                        <li>备　　注：<asp:Literal runat="server" ID="litRemarks"></asp:Literal></li>
                    </ul>
                </div>
            </fieldset>
        </div>
       
        <fieldset style="text-align:left;width:680px;">
		    <legend>其他信息(非公开)</legend>
		         <div style="margin-left:10px;">
                    <ul>
                        <li>出生年月：<asp:Literal runat="server" ID="litbirthday"></asp:Literal></li>
                        <li>籍　　贯：<asp:Literal runat="server" ID="litJiGuan"></asp:Literal></li>
                        <li>工作时间：<asp:Literal runat="server" ID="litwork_time"></asp:Literal></li>
                        <li>聘任时间：<asp:Literal runat="server" ID="litemp_time"></asp:Literal></li>
                    </ul>
                </div>
                <div style="margin-left:20px;">
                    <ul>                        
                        <li>民　　族：<asp:Literal runat="server" ID="litminzu"></asp:Literal></li>
                        <li>党　　派：<asp:Literal runat="server" ID="litparty"></asp:Literal></li>
                        <li>入党时间：<asp:Literal runat="server" ID="litparty_time"></asp:Literal></li>
                        <li>家庭地址：<asp:Literal runat="server" ID="litHomeAddress"></asp:Literal></li>
                    </ul>
                </div>
                <div style="margin-left:20px;">
                    <ul>
                        <li>办公电话：<asp:Literal runat="server" ID="litOfficePhone"></asp:Literal></li>
                        <li>住宅电话：<asp:Literal runat="server" ID="litHomePhone"></asp:Literal></li>
                        <li>手　　机：<asp:Literal runat="server" ID="litMobilePhone"></asp:Literal></li>
                        <li>虚&nbsp;&nbsp;拟&nbsp;&nbsp;网：<asp:Literal runat="server" ID="litShortNum"></asp:Literal></li>
                   </ul>
                </div>
	    </fieldset>
	</fieldset>
	
	<fieldset>
		<legend>个人简介</legend>
		<div>
			<asp:Literal runat="server" ID="litinfo_base"></asp:Literal>
		</div>
	</fieldset>
	<fieldset>
		<legend>学术研究</legend>
		<div>
			<asp:Literal runat="server" ID="litinfo_study"></asp:Literal>
		</div>
	</fieldset>
	
    <fieldset>
	    <legend>工作简历</legend>
	    <div>
	        <a name="#resumes1"></a>
	        <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" Width="100%" CssClass="grid" DataKeyNames="id">
                <Columns>
                    <asp:BoundField DataField="dbo_startTime" DataFormatString="{0}" HeaderText="开始时间" />
                    <asp:BoundField DataField="dbo_endTime" DataFormatString="{0}" HeaderText="结束时间" />
                    <asp:BoundField DataField="dbo_unit" DataFormatString="{0}" HeaderText="工作单位" />
                    <asp:BoundField DataField="dbo_duty" DataFormatString="{0}" HeaderText="职务" />
               </Columns>
	        </asp:GridView>
	    </div>
    </fieldset>	
	
    <fieldset>
	    <legend>学习进修简历</legend>
	    <div>
            <a name="#resumes2"></a>
	        <asp:GridView runat="server" ID="GridView2" AutoGenerateColumns="False" Width="100%" CssClass="grid" DataKeyNames="id" >
                <Columns>
                    <asp:BoundField DataField="dbo_startTime" DataFormatString="{0}" HeaderText="开始时间" />
                    <asp:BoundField DataField="dbo_endTime" DataFormatString="{0}" HeaderText="结束时间" />
                    <asp:BoundField DataField="dbo_school" DataFormatString="{0}" HeaderText="学习学校" />
                    <asp:BoundField DataField="dbo_professional" DataFormatString="{0}" HeaderText="专业" />
                    <asp:BoundField DataField="dbo_graduateTime" DataFormatString="{0}" HeaderText="毕业时间" />
                </Columns>
	        </asp:GridView>
	    </div>
    </fieldset>	

    <fieldset>
	    <legend>育人简历</legend>
	    <div>
		    <a name="#resumes3"></a>
	        <asp:GridView runat="server" ID="GridView3" AutoGenerateColumns="False" Width="100%" CssClass="grid" DataKeyNames="id">
                <Columns>
                    <asp:BoundField DataField="dbo_startTime" DataFormatString="{0}" HeaderText="开始时间" />
                    <asp:BoundField DataField="dbo_endTime" DataFormatString="{0}" HeaderText="结束时间" />
                    <asp:BoundField DataField="dbo_theClass" DataFormatString="{0}" HeaderText="班级" />
                    <asp:BoundField DataField="dbo_result" DataFormatString="{0}" HeaderText="成绩效果" />                        
                </Columns>                    
	        </asp:GridView>		
	    </div>
    </fieldset>
</div>
</form>
</body>
</html>
