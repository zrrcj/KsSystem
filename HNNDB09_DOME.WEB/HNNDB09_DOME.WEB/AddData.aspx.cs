using HNNDB09_DOME.BLL;
using HNNDB09_DOME.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNNDB09_DOME.WEB
{
    public partial class DataAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //addstudent();
            load();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script>alert(‘添加成功');</script>");
        }
        public void addstudent()
        {
            string[] students = {"蔡轩悦", "曹莉", "陈波", "程鹏亮", "都金婷","费孟凡", "勾晓寒", "关文天", "霍秀岭", "荆梦瑶",
                "克铁柱", "郎鑫", "李明", "李明轩", "李树鹏","李亭亭", "李霞霞", "李小闯", "李雅", "李亚哲",
                "李杨", "李英君", "刘青悦", "刘腾飞", "刘婷婷","刘喆", "刘铮", "刘重阳", "卢远晨", "吕昶乐",
                "马勇", "闵一博", "牛建阳", "任胜男", "荣紫君","沈泽通", "王齐磊", "王晴", "王天", "王天祥",
                "王祥智", "武怡锦", "徐斌", "薛如新", "杨建","张晗", "张慧阳", "张晓宁", "张银凤", "李孟杰",
                "赵威"};//51人
            //电信14-3学生名单
            string[] students1 = {"李聪", "常红", "单鹏辉", "窦玉卿", "段铁鑫","高康康", "广昭华", "郭建鹏", "郝宁宁", "何恒建",
                "黄建阔", "霍坤炜", "姜博", "解美慧", "孔宪哲", "李昂", "李宝乐", "李建利", "李文峰", "刘畅",
                "刘方兵", "刘莎", "刘尚", "刘晓红", "刘兴康","娄英楠", "吕强", "孟君正", "任玉曌", "邵文杰",
                "石书鹏", "石宇", "田桃桃", "王青", "王淑锦","王思琪", "王旭阳", "王彦凯", "王紫轩", "闫兆峰",
                "杨桉", "杨森", "杨亚倩", "杨跃宾", "尹跃腾","张彤", "张晓涵", "张玉珍", "张泽达", "赵家旭",
                "赵建伟", "赵宽", "周华思"};//53人
            
            for (int i = 0; i <students.Length; i++)
            {
                XS_Model m = new XS_Model();
                m.hnn09_xs_age = 20;
                m.hnn09_xs_clsid = 2;
                m.hnn09_xs_id = i + 1;
                m.hnn09_xs_name = students[i];
                m.hnn09_xs_no = i + 1 <10 ?"0" + (i + 1).ToString() : (i + 1).ToString();
                m.hnn09_xs_phone = "1551246xxxxx";
                m.hnn09_xs_pwd = "D759808CBACBF15B";
                m.hnn09_xs_sex = 1;
                XS_BLL bll = new XS_BLL();
                bll.add(m);
            }
            for (int i = 0; i < students1.Length; i++)
            {
                XS_Model m = new XS_Model();
                m.hnn09_xs_age = 20;
                m.hnn09_xs_clsid = 3;
                m.hnn09_xs_id = i + 1;
                m.hnn09_xs_name = students1[i];
                m.hnn09_xs_no = i + 1 < 10 ? "0" + (i + 1).ToString() : (i + 1).ToString();
                m.hnn09_xs_phone = "1551246xxxxx";
                m.hnn09_xs_pwd = "D759808CBACBF15B";
                m.hnn09_xs_sex = 1;
                XS_BLL bll = new XS_BLL();
                bll.add(m);
            }
        }
        public void load()
        {
            string[,] wt = {{"请简述启用Sa账号的步骤？","答案:使用Windows身份登录，安全性--登录名--sa--属性--修改密码并启用，右击服务器--安全性--混合登录模式--重启服务"},
                 {"使用PowerDesigner创建物理模型的注意事项（至少两点）？简述三种分页原理？", "答案:字段使用大写，带前缀，使用通用类型；not in; id大于max(id);row_number()over()"},
                 {"请简述C#操作数据库的7个步骤？", "答案:1、编写或者获取数据库连接字符串</br>2、使用数据库连接字符串初始化连接对象SqlConnection</br>3、判断连接状态并打开</br>4、编写sql语句并创建SqlCommand对象</br>5、声明数据适配器和容器</br>6、使用数据适配器填充容器</br>7、关闭连接"},
                 {"请说出SQL函数中两个类型转换函数以及使用方法？", "答案:cast 列名 as 类型；convert(类型,列名)"},
                 {"请说出三层架构是哪三层？层次之间的引用关系是什么？各层之间主要写什么？", "答案:表现层==》业务逻辑层==》数据访问层"},
                 {"读取web.config要引入哪个命名空间？为什么要将数据库连接字符串存放到web.config文件的AppSetting节点中？", "答案:System.Configuration；安全，方便修改"},
                 {"请用一句话总结出高级查询之分组查询的语法？并说出SQL语句Row_Number()Over()分页公式？", "答案:select后面出现的字段，如果没有使用聚合函数进行处理一定要出现在Group By后面；(PageIndex-1)*PageSize+1 And PageIndex*PageSize"},
                 {"请说出相当于if的SQL语句中的函数及其语法？","答案:case when 表达式 then xxx when 表达式 then xxx end as xxx"},
                 //JavaScript部分
                 {"请说出JavaScript获取页面元素的三种方法？说明innerHTML和innerText的区别？", "答案:document.getElementById();document.getElementsByName();document.getElementsByTagName();innerHTML是赋值或取值html元素中间的HTML片段，innerText只是赋值或取值文本"},
                 {"声明一个数组的四种方法？说明split和join函数的作用？", "答案:var arr={};var arr=new Array(); var arr=new Array(7);var arr=new Array(1,2,3);split是将字符串按指定的字符分隔到数组中，例：var arr='1,2,3'.split(',');join是将数组元素串联成指定字符的字符串，例：var arr={'1','2','3'};arr.join('@');结果'1@2@3'"},
                 {"定义样式有哪三种写法？JavaScript中页面加载时要使用哪个函数,用两种写法举例说明？", "答案:#id{};.className{},tagName{};window.onload=functionName;或者function(){functionName();}"},
                 {"JavaScript中如何声明一个变量、对象，举例说明对象的属性使用？","答案:var;var obj=new Object(); obj.自定义属性名=值"},
                 {"说出JavaScript中单行注释和多行注释？请说明break和continue的意义？", "答案:break终止循环；continue终止本次循环，进入下一次循环。单行注释//;多行注释:/**/"},
                 {"警告对话框是哪个函数？确认对话框是哪个函数？说明onMouseOver和onMouseOut函数的意义?", "答案:alert(),confirm()。onMouseOver鼠标悬停;onMouseOut鼠标离开"},
                 {"鼠标单击事件是什么？请举例说明常用的事件。", "答案:onclick;onkeyup;onkeydown;onchange;</br>onblur;ondblclick;oncontextmenu"},
                 {"JavaScript调用函数时传递参数可以少于定义的参数个数?Jquery中页面加载事件是什么，说出两种写法？", "答案:可以。$(document).ready(function(){});或者$(function(){});"},
                 {"定时器函数是什么，有几个参数，说明每个参数的含义？","setInterval(函数名，毫秒);"},
                 {"Jquery获取元素值、文本、HTML片段、属性的函数分别是什么，并且说明各个函数的参数和用法","答案:val();text();html();attr('paramName','paramValue');"},
                 {"Jquery有哪三种常用选择器，请分别举例说明？Jquery常用的过滤器有哪些，请举例说明？", "答案:$('#id');$('.className');$('tagName'):<br/>first;:last;:gt;:lt;:eq;:even;:odd;"},
                 {"&lt;div id='div1'&gt;a&lt;b&gt;niuniu&lt;/b&gt;&lt;/div&gt;,请写出获取niuniu文本的Jquery选择器表达式", "答案:$('#div1 b').text()"},
                 {"Jquery中的循环函数是什么，有一个数组dom对象arr，如何循环数组对象，请写出表达式","答案:each,$(arr).each(function(){...todo});"},
                 {"请说明Jquery-EasyUI框架使用的css和js引用顺序，简要说明EasyUI实现了哪些功能组件?", "答案:先引入css，后引入js;According折叠面板，datagrid数据表格，tree树形结构，layout页面布局；window弹出层窗口，ComboBox可写可选下拉框，Datebox日期控件等"},
                 //ASP.NET部分22
                 {"WebForm中页面加载事件是什么?如何区分页面第一次加载还是回传？", "答案：Page_Load,!IsPostBack代表第一次加载"},
                 {"请用两种方式写出ASP.NET中后台获取控件&lt;input type=\"text\" id=\"txtUserName\" runat=\"server\" name=\"txtUid\" value=\"牛牛\"/&gt;值的语句", "答案：Request.Form{\"txtUid\"},txtUserName.value"},
                 {"写出三种(可以使用JavaScript)跳转到“网站根目录下面的Index.aspx”页面的语句?", "答案：Response.Redirect(\"/Index.aspx\");Server.Transfer(\"/Index.aspx\");location.href='/Index.aspx'"},
                 {"写出两种弹出对话框内容“您好，牛牛”的语句", "答案：Response.Write(\"<script>alert('您好，牛牛')<script>\");Page.ClientScript.RegisterStartupScript(this,\"\"\"<script>alert('您好，牛牛')</script>\")"},
                 {"写出获取/xxx.aspx?tid=12&tpartId=22路径中值“22”的语句", "答案：Request.QueryString{\"tpartId\"}"},
                 {"写出将“牛牛”这个字符串存放到名为“niuniu”的Session对象中的语句", "答案：Session{\"niuniu\"}=\"牛牛\""},
                 {"下拉框数据绑定DropDownList绑定控件时候，要指定的两个属性分别是什么？", "答案：DataTextField，DataValueField"},
                 {"有一个Users的实体类，请写出Users泛型列表的声明语句", "答案：List<Users> lm=new List<Users>()"},
                 {"GridView实现分页需要作哪些设置?", "答案：AllowPaging=true,PageSize=10,添加GridView_PageIndexChanging事件"},
                 {"字符串变量strNiuNiu，写出判断该变量是否为“空或者Null”的表达式", "答案：string.IsNullOrEmpty(strNiuNiu)"},
                 //J2EE部分
                 {"HTML的注释方法____________,特点是通过____________能被用户看见","答案：&lt;!--注释内容--&gt;，查看源代码"},
                 {"JSP隐藏注释方法_________________。","答案：&lt;%--注释内容--%&gt;"},
                 {"单行脚本注释_________________,多行脚本注释________________,方法注释或说明_________________。","答案：//单行注释，/*多行注释*/，/**方法注释*/"},
                 {"指令的通用格式为_______________,常用的指令元素有________指令，用于对JSP文件中的_________进行设置；________指令，用于在JSP页面中引用_________；_________指令，用于声明用户自定义的_______________。","答案：&lt;%@ 指令名称 属性=\"属性名\"%&gt;，page，全局属性；include，外部文件；taglib，新标签"},
                 {"include指令的格式为____________________，特点是文件路径不能带有______。","答案：&lt;%@ include file=\"文件路径\"%&gt;,参数"},
                 {"taglib指令格式为_____________,不能使用jsp、java等作为前缀。","答案：&lt;%@ taglib uri=\"tagLibraryURL\" prefix=\"tagPrefix\"%&gt;"},
                 {"声明的格式为_____________；输出表达式为_____________;Scriptlet小脚本格式为______________。","答案：&lt;%! 声明的变量或者方法%&gt;；&lt;%=变量或有返回值的方法或java表达式%&gt;；&lt;% 脚本代码%&gt;"},
                 {"jsp:param动作的使用格式为____________________;jsp:include动作使用格式_________________;jsp:forward动作使用格式_____________；jsp:plugin动作指令格式为____________________。","答案：&lt;jsp:param name=\"paramName\" value=\"paramValue\" /&gt;;&lt;jsp:include page=\"filename\" flush=\"true\" /&gt;;&lt;jsp:forward page=\"url\" /&gt;;&lt;jsp:plugin type=\"bean|applet\" codebase=\"classFileDirectoryName\" code=\"classname\" /&gt;"},
                 {"表单提交有汉字时，需要通过request的__________方法设置编码为gb2312或者utf-8，获取参数的方法是_______________。","答案：setCharacterEncoding(\"gb2312\"),getParameter(\"表单元素的name\")"},
                 {"使用response对象跳转页面的方法___________________。","答案：答案：sendRedirect(\"url地址\");"},
                 {"Session的获取和赋值分别是___________方法和______________方法。","答案：getAttribute()和setAttribute()"},
                 {"使用out的println方法弹框________________。","答案：out.println(\"&lt;script&gt;alert('提示信息!')&lt;/script&gt;\")"},
                 {"Session和Application的区别在于Session是______________级的，Application是___________级的。", "答案：会话，应用程序"}};
            for (int i = 0; i < (wt.Length) / 2; i++)
            {
                if (i <= 7)
                {
                    WT_Model m = new WT_Model();
                    m.HNN09_WT_WT =Server.HtmlEncode(wt[i, 0]);
                    m.HNN09_WT_XKID = 4;
                    m.HNN09_WT_DA = wt[i, 1];
                    WT_BLL bll = new WT_BLL();
                    bll.add(m);
                }
                else if (i <= 21)//JavaScript部分
                {
                    WT_Model m = new WT_Model();
                    m.HNN09_WT_WT = wt[i, 0];
                    m.HNN09_WT_XKID = 2;
                    m.HNN09_WT_DA = wt[i, 1];
                    WT_BLL bll = new WT_BLL();
                    bll.add(m);
                }
                else if (i <= 31)//ASP.NET部分
                {
                    WT_Model m = new WT_Model();
                    m.HNN09_WT_WT = wt[i, 0];
                    m.HNN09_WT_XKID = 1;
                    m.HNN09_WT_DA = wt[i, 1];
                    WT_BLL bll = new WT_BLL();
                    bll.add(m);
                }
                else
                {
                    WT_Model m = new WT_Model();
                    m.HNN09_WT_WT = wt[i, 0];
                    m.HNN09_WT_XKID = 5;
                    m.HNN09_WT_DA = wt[i, 1];
                    WT_BLL bll = new WT_BLL();
                    bll.add(m);
                }

            }
        }
    }
}