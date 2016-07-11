<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="js_tw.aspx.cs" Inherits="HNNDB09_DOME.WEB.PAGE.JS.js_tw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/themes/icon.css" />
    <script src="/scrpit/jquery.min.js"></script>
    <script src="/scrpit/jquery.easyui.min.js"></script>
    <style>
    </style>
    <script type="text/javascript">
        $(function () {
            window.parent.closeProcess();
        })
        function Mysearch() {
            $('#Button1').click();
        }
        function showda() {
            $('#1').css("visibility", "visible");
        }
        function lrcj()
        {
            $("#w").window("open");
            $("#w").window("center");
        }

        function saveWin()
        {
            //alert('djgkhs')
            $("#btnSave").click()
        }
    </script>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server" style="border: none">
        <asp:HiddenField ID="wtid" runat="server" />
        <asp:HiddenField ID="xsid" runat="server" />
        <div data-options="region:'north',border:false" style="height: 40px; background: #eff7ff; padding: 10px; overflow-y: hidden">
            <span style="display: none;">
                <asp:Button ID="Button1" runat="server" Text="提问" OnClick="Button1_Click" />
            <asp:Button ID="btnSave" runat="server" Text="录入成绩" OnClick="btnSave_Click" /></span>
            <div>
               
                班级：
                <asp:DropDownList ID="bj" runat="server" Style="width: 100px;" class="easyui-combobox" data-options="panelHeight:100">
                </asp:DropDownList>
                学科：
        <asp:DropDownList ID="km" runat="server" Style="width: 100px;" class="easyui-combobox" data-options="panelHeight:100">
        </asp:DropDownList>
                
                
                &nbsp;<a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="Mysearch()" style="height: 22px">提问</a>
                <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-ok'" onclick="showda()" style="height: 22px">显示答案</a>
                  <asp:TextBox CssClass=" easyui-textbox" ID="TextBox2" runat="server"></asp:TextBox>
                <a class="easyui-linkbutton" data-options="iconCls:'icon-ok'" href="javascript:void(0)" onclick="javascript:saveWin()" style="width: 80px">提交成绩</a>
            </div>
        </div>
        <div data-options="region:'center'" style="padding: 40px 30px 5px 30px; overflow: hidden; font-size: 25px; font-weight: bold; text-align: center;">

            <div style="padding: 10px; height: 140px; font-size: 20px; font-weight: bold; text-align: center; border: 5px solid #96c2f1; background: #eff7ff; border-radius: 20px;">
                <asp:Literal ID="name" runat="server"></asp:Literal>
                <br />
                问题：&nbsp;&nbsp; 
            <asp:Literal ID="wt" runat="server"></asp:Literal>
            </div>
        </div>

        <div data-options="region:'south'" style="height: 275px; padding: 20px 30px 5px 30px; overflow: hidden; font-size: 25px; font-weight: bold; text-align: center; color: #ff0000;">

            <div id="w" class="easyui-window" data-options="iconCls:'icon-save',modal:false,closed:true" style="width: 300px; height: 200px; padding: 5px;">
        <div class="easyui-layout" data-options="fit:true">
            <div data-options="region:'center'" style="padding: 0px; overflow: hidden;">
              <div style="text-align:center;padding:50px"> 成绩：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></div>
            </div>
            <div data-options="region:'south',border:false" style="text-align: right; padding: 5px 0 0;">
                <a class="easyui-linkbutton" data-options="iconCls:'icon-ok'" href="javascript:void(0)" onclick="javascript:saveWin()" style="width: 80px">确定</a>
                <a class="easyui-linkbutton" data-options="iconCls:'icon-cancel'" href="javascript:void(0)" onclick="javascript:$('#w').window('close')" style="width: 80px">取消</a>
            </div>
        </div>
    </div>
            <%--<div style="text-align:center;"><a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-filesave'" onclick="lrcj()" style="height: 22px">录入成绩</a></div>--%>
            <div style="padding: 10px 5px 5px 5px; height: 190px; font-size: 20px; font-weight: bold; text-align: center; border: 5px solid #96c2f1; background: #eff7ff; border-radius: 20px;">
                <span id="1" style="visibility: hidden;">
                    <asp:Literal ID="DA" runat="server"></asp:Literal></span>
            </div>
        </div>
    </form>
</body>
</html>
