<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="HNNDB09_DOME.WEB.PAGE.CLSS.list" %>

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
        $(function () {
           
            $('#GridView1').datagrid({
                url: 'listData.aspx?r=' + Math.random(),
                method: 'get',
                toolbar: toolbar,
                loadMsg: "",
                rownumbers: true,
                border: false,
                columns: [[
                { field: 'ck', checkbox: true, width: 60 },
                { field: 'HNN09_CLSS_NAME', title: '班级名称', width: 100 },
                { field: 'HNN09_CLSS_NUMBER', title: '班级人数', width: 100 },

                ]],
                //数据加载完成回掉的函数
                onLoadSuccess: function (data) {
                    //指定分页total属性的值
                    $('#pp').pagination('refresh', {
                        // 改变选项并刷新分页栏信息
                        total: data.total
                    });
                    //调用父窗口的关闭加载框方法
                    window.parent.closeProcess();
                },
                onLoadError: function () {
                    //调用父窗口的关闭加载框方法
                    window.parent.closeProcess();
                }
            });
            //初始化分页
            $('#pp').pagination({
                //total: data.total,//$('#GridView1').datagrid("getRows").length,
                pageList: [10, 15, 20, 50],
                loading: false,
                layout: ['list', 'first', 'prev', 'links', 'next', 'last'],
                links: 10,
                showRefresh: false,
                displayMsg: '当前显示 {from} - {to} ，共 {total} 条记录'
            });
            //分页改变事件
            $('#pp').pagination({
                onSelectPage: function (pageNumber, pageSize) {
                    //window.parent.showProcess();
                    //$(this).pagination('loading');
                    //alert('pageNumber:' + pageNumber + ',pageSize:' + pageSize);
                    //根据两个参数重新请求数据并加载datagrid
                    $('#GridView1').datagrid('load', {
                        pageIndex: pageNumber,
                        pageSize: pageSize,
                        clssno: $("#clss_no").val()
                    });
                    $(this).pagination('loaded');
                }
            });
        })
        var toolbar = [{
            text: '增加',
            iconCls: 'icon-add',
            handler: function () {
                //alert('add')
                window.parent.openWin('350', '250', 'PAGE/CLSS/add.aspx?r=' + Math.random(), '班级添加');
            }
        }, '-', {
            text: '修改',
            iconCls: 'icon-cut',
            handler: function () {
                var row = $("#GridView1").datagrid("getSelected");
                if (row != null) {
                    if (row.length > 1) {
                        $.messager.alert("一次只能选择一项");
                    } else {
                        window.parent.openWin('350', '250', 'PAGE/CLSS/add.aspx?id=' + row.HNN09_CLSS_ID, '班级修改');
                    }

                }
                else {
                    //$.messager.alert("请选择一项");
                    window.parent.showalert('请选择一项')
                }

                //alert(row.HNN09_JS_ID);
            }
        }, '-', {
            text: '删除',
            iconCls: 'icon-cancel',
            handler: function () {
                //alert('save')
                var row1 = $("#GridView1").datagrid("getSelected");
                if (row1!=null) {
                    var row = $("#GridView1").datagrid("getSelections");
                    var a = [];
                    $(row).each(function () {
                        a.push(this.HNN09_CLSS_ID)
                    })
                    if (row != null) {
                        window.parent.sc('PAGE/CLSS/del.aspx?id=' + a.join(','))
                    }
                }
                else {
                    //$.messager.alert("请选择一项");
                    window.parent.showalert('请选择一项')
                }
            }
        }];
        function Mysearch() {
            //alert("dfsdfsd")
            $('#GridView1').datagrid('load', {
                clssno: $("#clss_no").val()
                //js_zw: $('#js_zw').combobox('getValue')
            })
        }
    </script>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server" style="border :none">
        <div data-options="region:'north',border:false" style="height: 40px; background: #ffffff; padding: 10px; overflow-y: hidden">
           <%--<span style ="display:none"> <asp:Button ID="delet" runat="server" Text="Button" OnClick="delet_Click" /></span>--%>
            <div>
                &nbsp;
                请输入班级名：<input id="clss_no" class="easyui-textbox"  style="width: 100px;height:21px" type="text" />&nbsp;
              &nbsp;<a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="Mysearch()" style ="height:22px">查询</a>
            </div>
            

        </div>
        <div data-options="region:'center'" style="padding: 0px">

            <div style="margin: 0px">
                <table id="GridView1">
                </table>
            </div>

        </div>
        <div data-options="region:'south'" style="height: 30px; padding: 0px; overflow: hidden">
            <div id="pp"></div>
        </div>
    </form>
</body>
</html>
