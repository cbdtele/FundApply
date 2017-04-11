
function readCookie() {
    if (document.getElementById("Image").value == "") {
        alert("请输入验证码");
        document.getElementById("Image").focus();
        return false;
    }
    //判断是否存在cookie

    var isExist = document.cookie.indexOf("ValidateCode=");
    if (isExist != -1) {
        //“imgRandom=”后面的等号的位置
        var c = document.cookie.indexOf("=", isExist) + 1;
        //获取等号后面的字符串，也就是所需要的验证码！
        var str = decodeURIComponent(document.cookie.substring(c, c + 4));

        if (document.getElementById("Image").value.toString() == str.toString() || document.getElementById("Image").value.toString() == str.toUpperCase() || document.getElementById("Image").value.toString() == str.toLowerCase()) {
            return true;
        }
        else {
            document.getElementById("Image").select();
            document.getElementById("imgRandom").src = "DataExchange/Randomimage_CN.aspx?abc=" + Math.random();
            alert("验证码输入错误！")
            return false;
        }
    }
}
function check() {
    if (document.getElementById("txtUserName").value == "") {
        alert("用户名不能为空");
        document.getElementById("txtUserName").focus();
        return false;
    }
    if (document.getElementById("txtPassword").value == "") {
        alert("密码不能为空");
        document.getElementById("txtPassword").focus();
        return false;
    }
    return true;
}
function submitCheck() {
    if (check() && readCookie()) {
        return true;
    } else {
        return false;
    }
}
//获取图片的src
function imgSrc() {
    // 通过链接让图片中的src发生变化 
    document.getElementById("imgRandom").src = document.getElementById("imgRandom").src + "?abc=" + Math.random();
}
