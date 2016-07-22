<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="web_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="css/style.css"/>
    <link rel="stylesheet" type="text/css" href="css/login.css"/>
    <link href="http://apps.bdimg.com/libs/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="/scripts/jquery.min.js"></script>
    <script src="/bootstrap/js/bootstrap.min.js"></script>
    <title>登录</title>
</head>
<body>
    <div class="panel panel-default login-panel">
        <div class="panel-heading">
            <h3 class="panel-title" style="text-align:center">登录</h3>
        </div>
        <form class="bs-example bs-example-form" role="form" runat="server">
            <div class="input-group input-group-lg" style="margin: 10px 5px">
                <span class="input-group-addon">工号</span>
                <input id="txtUserName" type="text" class="form-control" runat="server"/>
            </div>
            <div class="input-group input-group-lg" style="margin: 10px 5px">
                <span class="input-group-addon">密码</span>
                <input id="txtPwd" type="password" class="form-control" runat="server"/>
            </div>
            <asp:button class="btn btn-primary btn-lg btn-login" type="submit" style="margin: 10px 5px" runat="server" OnClick="Login" Text="登录"/>
        </form>
    </div>
</body>
</html>
