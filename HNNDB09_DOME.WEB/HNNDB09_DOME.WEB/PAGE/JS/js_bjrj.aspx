<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="js_bjrj.aspx.cs" Inherits="HNNDB09_DOME.WEB.PAGE.JS.js_bjrj" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/themes/icon.css" />
    <script src="/scrpit/jquery.min.js"></script>
    <script src="/scrpit/jquery.easyui.min.js"></script>
    <script type ="text/javascript">
        function formstat() {
            return $('#form1').form('validate');
        }
    </script>
</head>
<body>
    <div>
        <form id="form1" runat="server">
            <table>
                <tr>
                    <asp:CheckBoxList CssClass="easyui-tree" ID="bj" runat="server"></asp:CheckBoxList>
                </tr>
            </table>
            <span style="display: none;">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" /></span>
        </form>
    </div>
</body>
</html>
