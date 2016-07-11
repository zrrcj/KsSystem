<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="HNNDB09_DOME.WEB.PAGE.XS.add" %>

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
                <asp:HiddenField ID="xs_id" runat="server" />
                <tr>
                    <td class="auto-style1">&nbsp; 学号:</td>
                    <td>
                        <asp:TextBox ID="hnn09_xs_no" CssClass="easyui-validatebox easyui-textbox" runat="server" data-options="required:true,missingMessage:'请输入教师号',validType:'minLength[5]',tipPosition:'top'"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                       
                        &nbsp;
                       
                        性别:</td>
                    <td>
                        <asp:DropDownList ID="hnn09_xs_sex" runat="server" data-options="panelHeight:50" CssClass="easyui-combobox" Style="width: 80px;">
                            <asp:ListItem Value="1">男</asp:ListItem>
                            <asp:ListItem Value="2">女</asp:ListItem>
                        </asp:DropDownList>
                    </td>
               <td class="auto-style1">
                        &nbsp;年龄:</td>
                    <td>
                        <asp:DropDownList ID="hnn09_xs_age" runat="server" CssClass="easyui-combobox" Style="width: 80px;">
                        </asp:DropDownList>
                    </td>
                     
                </tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp; 姓名：</td>
                    <td>
                        <asp:TextBox ID="hnn09_xs_name" CssClass="easyui-validatebox easyui-textbox" runat="server" data-options="required:true,missingMessage:'请输入姓名',validType:'minLength[5]',tipPosition:'top'"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        &nbsp;手机号:</td>
                    <td>
                        <asp:TextBox ID="hnn09_xs_phone" runat="server" CssClass="easyui-validatebox easyui-textbox" data-options="required:true,missingMessage:'请输入手机号',validType:'minLength[5]',tipPosition:'top'"></asp:TextBox>
                    </td>
                   <td class="auto-style1">
                        &nbsp;班级:</td>
                    <td>
                        <asp:DropDownList ID="km" runat="server" CssClass="easyui-combobox" Style="width: 80px;">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <span style="display: none  ;">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" /></span>
        </form>
    </div>
</body>
</html>
