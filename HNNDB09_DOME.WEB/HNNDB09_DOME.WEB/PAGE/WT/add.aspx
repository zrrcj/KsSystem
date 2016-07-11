<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="HNNDB09_DOME.WEB.PAGE.WT.add" %>

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
                <asp:HiddenField ID="clss_id" runat="server" />
                <tr>
                    <td class="auto-style1">&nbsp; 问题:</td>
                    <td>
                        <asp:TextBox ID="hnn09_wt_wt" CssClass="easyui-validatebox " runat="server" data-options="required:true,missingMessage:'请输入班级名称',tipPosition:'top',multiline:true" TextMode="MultiLine"></asp:TextBox>
                
                        </td></tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp; 答案：
                    </td>
                    <td>
                        <asp:TextBox ID="hnn09_wt_da" CssClass="easyui-validatebox " runat="server" data-options="required:true,missingMessage:'请输入人数',tipPosition:'top',multiline:true" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td class="auto-style1">
                        &nbsp; 学科：
                    </td>
                    <td>
        <asp:DropDownList ID="km" runat="server" Style="width: 145px;" class="easyui-combobox" data-options="panelHeight:100">
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
