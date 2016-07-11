<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="js_add.aspx.cs" Inherits="HNNDB09_DOME.WEB.js_add" %>

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
                <asp:HiddenField ID="js_id" runat="server" />
                <tr>
                    <td class="auto-style1">&nbsp; 教师号:</td>
                    <td>
                        <asp:TextBox ID="hnn09_js_no" CssClass="easyui-validatebox easyui-textbox" runat="server" data-options="required:true,missingMessage:'请输入教师号',validType:'minLength[5]',tipPosition:'top'"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                       
                        &nbsp;
                       
                        性别:</td>
                    <td>
                        <asp:DropDownList ID="hnn09_js_sex" runat="server" data-options="panelHeight:50" CssClass="easyui-combobox" Style="width: 80px;">
                            <asp:ListItem Value="1">男</asp:ListItem>
                            <asp:ListItem Value="2">女</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1">
                        &nbsp;
                        职称:</td>
                    <td>
                        <asp:DropDownList ID="hnn09_js_zc" runat="server" data-options="panelHeight:100" CssClass="easyui-combobox" Style="width: 80px;">
                            <asp:ListItem Value="教授">教授</asp:ListItem>
                            <asp:ListItem Value="副教授">副教授</asp:ListItem>
                            <asp:ListItem Value="工程师">工程师</asp:ListItem>
                            <asp:ListItem Value="讲师">讲师</asp:ListItem>
                            <asp:ListItem Value="助教">助教</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp; 姓名：</td>
                    <td>
                        <asp:TextBox ID="hnn09_js_name" CssClass="easyui-validatebox easyui-textbox" runat="server" data-options="required:true,missingMessage:'请输入姓名',validType:'minLength[5]',tipPosition:'top'"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        &nbsp;职务:</td>
                    <td>
                        <asp:DropDownList ID="hnn09_js_zw" runat="server" data-options="panelHeight:80" CssClass="easyui-combobox" Style="width: 80px;">
                            <asp:ListItem Value="系主任">系主任</asp:ListItem>
                            <asp:ListItem Value="系书记">系书记</asp:ListItem>
                            <asp:ListItem Value="系副主任">系副主任</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1">
                        &nbsp;从业时间:</td>
                    <td>
                        <asp:DropDownList ID="hnn09_js_sj" runat="server" CssClass="easyui-combobox" Style="width: 80px;">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <span style="display: none;">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" /></span>
        </form>
    </div>
</body>
</html>
