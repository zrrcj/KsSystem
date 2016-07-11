<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BXDL.login" %>

<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>登录 - 学生能力测评系统</title>
    <meta content="text/html; charset=UTF-8" http-equiv="Content-Type"/>
    <link rel="stylesheet" type="text/css" href="images/common.css"media="screen"/>
    <meta name="GENERATOR" content="MSHTML 8.00.7600.16853"/>
    <script type="text/javascript">

        if (window != top) {
            top.location.href = location.href;
        }
    </script>
</head>
<body id="loginFrame" >
    <div id="header">
        <div id="logo">
            <a title="UI制造者-专注于UI界面设计"href="http://www.uimaker.com"></a>
        </div>
    </div>
    <div id="loginBox">
        <div id="loginBoxHeader"></div>
        <div id="loginBoxBody">
            <ul class="floatLeft">
                <li>
                    <h4>请用您的教师号登录</h4>
                </li>
                <form id="login" method="post" runat="server">
                    <li>
                        <p>教师号:</p>
                        <%--<input id="email" class="textInput" maxlength="150" size="30" type="text"name="email"/>--%>
                        <asp:TextBox ID="js_no" runat="server" class="textInput" maxlength="150" size="30"></asp:TextBox>
                    </li>
                    <li>
                        <p>密码:</p>
                        <%--<input id="password" class="textInput" maxlength="80" size="30" type="password" name="password"/>--%>
                        <asp:TextBox ID="password" runat="server" class="textInput" maxlength="80" size="30" TextMode="Password"></asp:TextBox>
                        <a class="highlight" href="http://www.uimaker.com" target="_blank">忘记密码？</a>
                    </li>
                    <li class="highlight">
                        <%--<input id="loginBtn" onclick="this.blur();" value="登录" type="submit"/>--%>
                        <asp:Button ID="loginBtn" runat="server" Text="登录" OnClick="loginBtn_Click" />
                        <%--<a id="regBtn" href="http://www.uimaker.com" target="_blank">注册新账号</a> </li>--%>
                    <li></li>
                </form>
            </ul>
            <div
                class="floatRight">
              <h4>  欢迎使用学生能力测评系统，</br>此界面为教师端登陆界面。</h4>
            </div>
            <br clear="all"/>
        </div>
        <div id="loginBoxFooter"></div>
    </div>
    <div id="footer">
        <a href="http://www.uimaker.com/">
            <img alt="进入UI制造者" src="images/copyright.png"/></a>
    </div>
</body>
</html>
