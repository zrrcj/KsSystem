<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sevepwd.aspx.cs" Inherits="HNNDB09_DOME.WEB.sevepwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/themes/icon.css" />
    <script src="/scrpit/jquery.min.js"></script>
    <script src="/scrpit/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        function formstat() {
             
            var pwd = $('#js_pwd').val();
            var ypwd = $('#ypwd').text();
            if (pwd==ypwd) {
                return $('#form1').form('validate');
            }
            else
            {
                //$('#pwd1').css('display', 'block')
                return false;
            }
            
        }
        $.extend($.fn.validatebox.defaults.rules, {
            equals: {
                validator: function (value, param) {
                    return value == $(param[0]).val();
                },
                message: '两次输入的密码不同'
            }
        });

    </script>
</head>
<body>
    <div>
        <form id="form1" runat="server">
            <table>
                <%--<asp:HiddenField ID="clss_id" runat="server" />--%>
                <tr>
                    <td class="auto-style1">&nbsp; 原密码:</td>
                    <td>
                        <span style="display:none" id="ypwd"><%=((HNNDB09_DOME.MODEL.JS_Model)Session ["User"])!=null?new HNNDB09_DOME.COMMON.DESEncrypt().Decrypt(((HNNDB09_DOME.MODEL.JS_Model)Session ["User"]).hnn09_js_pwd):""%></span>
                        <%--<asp:TextBox ID="hnn09_js_pwd" name="pwd" TextMode="Password" CssClass="easyui-validatebox easyui-textbox" runat="server" data-options="required:true,missingMessage:'请输入原密码',validType:'minLength[5]',tipPosition:'top'"></asp:TextBox>--%>
                        <input id="js_pwd" name="pwd" runat="server" type="password" class="easyui-validatebox easyui-textbox" data-options="required:true,missingMessage:'请输入原密码',tipPosition:'top'" />
                        <span id="pwd1" style="color:#ff0000;display:none">原密码错误</span>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp; 新密码:</td>
                    <td>
                        <asp:TextBox ID="pwd" TextMode="Password" CssClass="easyui-validatebox easyui-textbox" runat="server" data-options="required:true,missingMessage:'请输入新密码',tipPosition:'top'"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp; 确认密码:</td>
                    <td>
                        <asp:TextBox ID="rpwd" TextMode="Password" CssClass="easyui-validatebox easyui-textbox" runat="server" required="required" validtype="equals['#pwd']" data-options="required:true,missingMessage:'请再次输入密码',tipPosition:'top'"></asp:TextBox>
                    </td>
                </tr>
<%--                <input id="pwd" name="pwd" type="password" class="easyui-validatebox" data-options="required:true" />
                <input id="rpwd" name="rpwd" type="password" class="easyui-validatebox"required="required" validtype="equals['#pwd']" />--%>

            </table>
            <span style="display: none;">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" /></span>
        </form>
    </div>
</body>
</html>
