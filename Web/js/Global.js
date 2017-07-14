jQuery(document).ready(function () {
    var url = window.location.href;
    var title = document.title;
    $.ajax({
        type: "POST",
        url: "/scripts.aspx?op=GetIPInfo&title="+title+"&url=" + url,
        success: function (msg) {
        }
    });
});
function checkform() {
    if ($("#keywords").val() == "") {
        alert('关键字不能为空！');
        $("#keywords").focus();
        return false;
    }
    formsearch.action = formsearch.action + "?kw=" + $("#keywords").val();
    return true;
}
function checkSourceform() {
    if ($("#keywords").val() == "") {
        alert('关键字不能为空！');
        $("#keywords").focus();
        return false;
    }
    formsearch.action = "/sourceCenter.aspx?kw=" + $("#keywords").val();
    return true;
}
function checkDownLoadform() {
    if ($("#keywords").val() == "") {
        alert('关键字不能为空！');
        $("#keywords").focus();
        return false;
    }
    formsearch.action = "/Down.aspx?kw=" + $("#keywords").val();
    return true;
}
function checkLogin() {
    if ($("#tName").val().indexOf("'") != -1 || $("#tPassword").val().indexOf("'") != -1) {
        alert("登陆失败");
        return false;
    }
    else if ($("#tName").val() == "" || $("#tPassword").val() == "") {
        alert("请输入用户名和密码");
        return false;
    }
    return true;
}
function goReset() {
    $("#tName").val("");
    $("#tPassword").val("");
}
function checkguestbookform() {
    var flag = 0;
    if ($("#txtTitle").val() == "") {
        $("#checktxtTitle").attr("style", "color:green;");
        flag = 1;
    }
    else {
        $("#checktxtTitle").attr("style", "color:green;display: none;");
    }
    if ($("#txtName").val() == "") {
        $("#checktxtName").attr("style", "color:green;");
        flag = 1;
    }
    else {
        $("#checktxtName").attr("style", "color:green;display: none;");
    }
    if ($("#txtCellphone").val() == "") {
        $("#checktxtCellphone1").attr("style", "color:green;");
        $("#checktxtCellphone2").attr("style", "color:green;display: none;");
        flag = 1;
    }
    else if ($("#txtCellphone").val() != "") {
        $("#checktxtCellphone1").attr("style", "color:green;display: none;");
        var myreg = /^[1][0-9]{10}$/;
        if (!myreg.test($("#txtCellphone").val())) {
            $("#checktxtCellphone2").attr("style", "color:green;");
            flag = 1;
        }
        else {
            $("#checktxtCellphone1").attr("style", "color:green;display: none;");
            $("#checktxtCellphone2").attr("style", "color:green;display: none;");
        }
    }
    if ($("#txtEmail").val() == "") {
        $("#checktxtEmail1").attr("style", "color:green;");
        $("#checktxtEmail2").attr("style", "color:green;display: none;");
        flag = 1;
    }
    else if ($("#txtEmail").val() != "") {
        $("#checktxtEmail1").attr("style", "color:green;display: none;");
        var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
        if (!myreg.test($("#txtEmail").val())) {
            $("#checktxtEmail2").attr("style", "color:green;");
            flag = 1;
        }
        else {
            $("#checktxtEmail1").attr("style", "color:green;display: none;");
            $("#checktxtEmail2").attr("style", "color:green;display: none;");
        } 
    }
    if ($("#txtContent").val() == "") {
        $("#checktxtContent").attr("style", "color:green;");
        flag = 1;
    }
    if (flag == 1) {
        return false;
    }
    else {
        return true;
    }
}