<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HNNDB09_DOME.WEB.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>技能评定系统1.0</title>
    <link rel="stylesheet" type="text/css" href="/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/themes/icon.css" />
    <script src="/scrpit/jquery.min.js"></script>
    <script src="/scrpit/jquery.easyui.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            
            $("#nav a").click(function () {
                if ($(this).hasClass("accordion-collapse")) {
                    return
                } else {
                    showProcess();
                    var t = $(this);
                    if ($("#tt").tabs('exists', t.text())) {
                        $("#tt").tabs('select', t.text())
                        //让选中的选项卡中ifram的src重新加载
                        $("#content" + t.attr("id")).attr("src", t.attr("niuniu"));
                    }
                    else {
                        $('#tt').tabs('add', {
                            title: t.text(),
                            content: '<iframe scrolling="no" frameborder="0" id="content' + t.attr("id") + '" src="' + t.attr("niuniu") + "?r=" + Math.random() + '" style="width:100%; overflow-x:hidden; overflow-y:hidden; border:false;"></iframe></div>',
                            closable: true
                        });
                    }
                }
                //处理ifram的自适高度
                var ifr = $("iframe");
                var p = ifr.parent();
                ifr.width(p.width());
                ifr.height(p.height());
                $("body").data("id", t)
                $("#tt .panel-body").css("overflow", "hidden");
            });
        //初始化窗口
        initWin();
        });
        //显示加载

        function showProcess() {
            $.messager.progress();
        }
        //关闭进度加载框
        function closeProcess() {
            $.messager.progress('close');
        }

        function initWin(w, h, t) {
            $('#w').window({
                width: (w == undefined ? 600 : w),
                height: (h == undefined ? 400 : h),
                collapsible: false,
                minimizable: false,
                maximizable: false,
                resizable: false,
                modal: true,
                title: t
            });
        }
        //打开窗口
        function openWin(w, h, s, t) {
            initWin(w, h, t);
            //给ifram动态赋值
            $("#w iframe").attr("src", s);
            $("#w").window("open");
            $("#w").window("center");
        }
        //保存窗口
        function saveWin() {
            var ifr = $("#w iframe");
            var isValid = ifr.get(0).contentWindow.formstat();
            if (isValid) {
                ifr.contents().find("#btnSave").click();
            }
            else {
                if (!isValid) {
                    $.messager.alert('消息', '原密码错误！');
                } else {
                    $.messager.alert('消息', '表单数据不合法！');
                }
            }
        }
        //function sx() {
        //    $("iframe").contents().find("#GridView1").datagrid('reload');
        //    //$('#tt ifrem #GridView1').datagrid('reload')
        //}
        function qd(a) {
            $.messager.alert('消息', a, 'info', function () {
                var t = $("body").data("id");
                $("#content" + t.attr("id")).attr("src", t.attr("niuniu"));
                $('#w').window('close')
            });
        }
        function qgma(a) {
            $.messager.alert('消息', a, 'info', function () {
                $('#w').window('close')
            });
        }
        function sc(url) {
            $.messager.confirm('警告', '确认要删除这条数据吗？', function (t) {
                //alert(row.HNN09_JS_ID)
                if (t) {
                    $.ajax({
                        url: url,
                        success: function (data) {
                            if (data == 'true') {

                                $.messager.alert('消息', '删除成功', 'info', function () {
                                    //$('#GridView1').datagrid('reload')
                                    var t = $("body").data("id");
                                    $("#content" + t.attr("id")).attr("src", t.attr("niuniu"));
                                });
                            }
                            else {
                                $.messager.alert('消息', '删除失败', 'info', function () {
                                });
                            }
                        }
                    })
                }
            })
        }
        function showalert(ms) {
            $.messager.alert('消息', ms);
        }
        function xgpwd() {
            openWin('300', '300', 'PAGE/JS/sevepwd.aspx', '密码修改')
        }
    </script>
    <style type="text/css">
        #top {
            background: url(images/top_bg.jpg);
            height: 65px;
            margin: 0 auto;
            padding: 0;
            font-size: 12px;
        }
    </style>
</head>
<body class="easyui-layout">
    <div id="header" data-options="region:'north',split:true,border:false" style="height: 45px; padding: 0px; overflow: hidden; background: url(/images/layout-browser-hd-bg.gif) repeat-x;">
        <div style="float: left; padding: 5px,0px,2px,8px;">
            <a href="http://www.xscp.com">
                <img style="border: 0px;" alt="" width="20px" height="20px" src="/images/blocks.gif" /></a>
        </div>
        <div style="float: left; font-size: 16px; padding: 5px 0px 0px 5px; font-weight: bold; color: #ffffff">学生能力测评系统登录后台</div>
        <form runat="server">
            <div style="float: left"></div>
            <div style="float: left"></div>
            <div style="float: right; margin: 5px">
                <asp:LinkButton ID="zx" runat="server" class="easyui-linkbutton" data-options="plain:true" OnClick="zx_Click1">注销</asp:LinkButton>
            </div>
            <div id="mm2" style="width: 100px;">
                <div onclick="xgpwd()" data-options="iconCls:'icon-key_add'">修改密码</div>
                <div>关于</div>
            </div>
            <div style="float: right; margin: 5px">欢迎你&nbsp<a href="#" class="easyui-menubutton" data-options="plain:true,menu:'#mm2'"><%=((HNNDB09_DOME.MODEL.JS_Model)Session ["User"])!=null?((HNNDB09_DOME.MODEL.JS_Model)Session ["User"]).hnn09_js_name:"" %></a>！</div>
        </form>
    </div>
    <%-- 下拉列表 --%>
    <div id="nav" data-options="region:'west',split:true,title:'任务栏'" style="width: 160px; padding: 0px;">
        <div class="easyui-accordion" fit="true">
            <div title="系统功能" data-options="iconCls:'icon-monitor'" style="padding: 10px;">
                <%--<ul class="easyui-tree">--%>
               <a runat="server" name="qx1" href="#"  class="easyui-linkbutton" id="qx1" niuniu="/PAGE/JS/js_list.aspx" data-options="iconCls:'icon-large-picture',size:'large',iconAlign:'top'">Picture</a>
                <a runat="server" href="#" class="easyui-linkbutton" id="js1" niuniu="/PAGE/JS/js_list.aspx" data-options="iconCls:'icon-large-clipart',size:'large',iconAlign:'top'">教师管理</a>
                <a runat="server" href="#" class="easyui-linkbutton" id="bj2" niuniu="/PAGE/CLSS/list.aspx" data-options="iconCls:'icon-large-shapes',size:'large',iconAlign:'top'">班级管理</a>
                <a runat="server" href="#" class="easyui-linkbutton" id="xk3" niuniu="/PAGE/XK/list.aspx" data-options="iconCls:'icon-large-smartart',size:'large',iconAlign:'top'">学科管理</a>
                <a runat="server" href="#" class="easyui-linkbutton" id="xs4" niuniu="/PAGE/XS/list.aspx" data-options="iconCls:'icon-large-chart',size:'large',iconAlign:'top'">学生管理</a>
                <a runat="server" href="#" class="easyui-linkbutton" id="wt5" niuniu="/PAGE/WT/list.aspx" data-options="iconCls:'icon-large-chart',size:'large',iconAlign:'top'">问题管理</a>
                 <a runat="server" href="#" class="easyui-linkbutton" id="A1" niuniu="/PAGE/TJ/List.aspx" data-options="iconCls:'icon-large-chart',size:'large',iconAlign:'top'">报表管理</a>
                <a runat="server" href="#" class="easyui-linkbutton" id="tw6" niuniu="/PAGE/JS/js_tw.aspx" data-options="iconCls:'icon-large-chart',size:'large',iconAlign:'top'">教师提问</a>
                <%--<li data-options="iconCls:'icon-table'"><a href="#" id="1" niuniu="/PAGE/JS/js_list.aspx">教师管理</a></li>
                    <li data-options="iconCls:'icon-table'"><a href="#" id="2" niuniu="/PAGE/CLSS/list.aspx">班级管理</a></li>
                    <li data-options="iconCls:'icon-table'"><a href="#" id="3" niuniu="/PAGE/XK/list.aspx">学课管理</a></li>
                    <li data-options="iconCls:'icon-table'"><a href="#" id="4" niuniu="/PAGE/XS/list.aspx">学生管理</a></li>
                    <li data-options="iconCls:'icon-table'"><a href="#" id="5" niuniu="/PAGE/JS/js_tw.aspx">教师提问</a></li>
                    <li data-options="iconCls:'icon-table'"><a href="#" id="5" niuniu="/PAGE/WT/list.aspx">问题管理</a></li>--%>
                <%--</ul>--%>
            </div>
            <%--<div title="学生管理" data-options="iconCls:'icon-group'" style="overflow: auto; padding: 10px;">
            </div>
            <div title="技能测定" data-options="iconCls:'icon-group'" style="overflow: auto; padding: 10px;">
            </div>--%>
            <div runat="server" id="xtsz" title="系统设置" data-options="iconCls:'icon-cog'" style="padding: 10px;">
                <a href="#" runat="server" class="easyui-linkbutton" id="qx11" niuniu="/PAGE/QX/List.aspx" data-options="iconCls:'icon-large-clipart',size:'large',iconAlign:'top'">权限管理管理</a>
            </div>
        </div>
    </div>
    <%-- 下拉列表结束 --%>
    <%-- 通用iframe弹窗 --%>
    <div id="w" class="easyui-window" data-options="iconCls:'icon-save',modal:true,closed:true" style="width: 500px; height: 200px; padding: 5px;">
        <div class="easyui-layout" data-options="fit:true">
            <div data-options="region:'center'" style="padding: 0px; overflow: hidden;">
                <iframe style="width: 100%; overflow-x: hidden; overflow-y: hidden; border: 0px;"></iframe>
            </div>
            <div data-options="region:'south',border:false" style="text-align: right; padding: 5px 0 0;">
                <a class="easyui-linkbutton" data-options="iconCls:'icon-accept'" href="javascript:void(0)" onclick="javascript:saveWin()" style="width: 80px">确定</a>
                <a class="easyui-linkbutton" data-options="iconCls:'icon-cancel'" href="javascript:void(0)" onclick="javascript:$('#w').window('close')" style="width: 80px">取消</a>
            </div>
        </div>
    </div>
    <%-- 弹窗结束 --%>
    <div data-options="region:'south',split:true,border:false" style="height: 30px; background: url(/images/nav_link.png); padding: 5px; text-align: center; font-weight: bold; overflow: hidden;">
        Copyright ©2015-2016 石家庄普软公司 all rights resrevled.
    </div>
    <div data-options="region:'center'" style="padding: 0px; overflow: hidden;">
        <div id="tt" class="easyui-tabs" data-options="border:false,fit:true">
            <div title="桌面" style="padding: 10px" data-options="iconCls:'icon-home'">
                <div style="padding: 10px 5px 5px 5px; height: 470px; font-size: 22px; font-weight: bold; text-align: center; border: 5px solid #96c2f1; background: #eff7ff; border-radius: 20px;">欢迎使用学生提问系统</div>
            </div>
        </div>
</body>
</html>
