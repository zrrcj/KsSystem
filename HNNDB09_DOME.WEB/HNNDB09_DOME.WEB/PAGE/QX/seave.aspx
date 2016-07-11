<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seave.aspx.cs" Inherits="HNNDB09_DOME.WEB.PAGE.QX.seave" %>

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
            return $('#form1').form('validate');
        }
    </script>
</head>
<body>
    <form runat="server">
        <div class="easyui-panel" style="padding: 5px; width: 300px;">
            <%--<ul id="tt" style="text-align:center" class="easyui-tree" data-options="checkbox:true">
            <li>--%>
            <asp:CheckBoxList CssClass="easyui-tree" ID="CheckBoxList1" runat="server">
                <asp:ListItem>教师管理</asp:ListItem>
                <asp:ListItem>学科管理</asp:ListItem>
                <asp:ListItem>班级管理</asp:ListItem>
                <asp:ListItem>学生管理</asp:ListItem>
                <asp:ListItem>问题管理</asp:ListItem>
            </asp:CheckBoxList>
        </div>
        
        <div style="margin: 20px 0; display: none">
            <asp:Button ID="btnSave" runat="server" Text="Button" OnClick="Button1_Click" />
            <%--<a href="#" id="btnSave" class="easyui-linkbutton" onclick="getChecked()">确定</a>--%>
        </div>
        <script type="text/javascript">
            function getChecked() {
                var nodes = $('#tt').tree('getChecked');
                var s = [];
                for (var i = 0; i < nodes.length; i++) {
                    //if (s != '') s += ',';
                    s.push(nodes[i].text);
                }
                $.ajax({
                    type: "POST",
                    url: "qxjy.ashx",
                    data: "name=" + s.join(','),
                    success: function (msg) {
                        alert(msg);
                    }
                });
                //alert(s.join(','));
            }
        </script>
    </form>
</body>
</html>
