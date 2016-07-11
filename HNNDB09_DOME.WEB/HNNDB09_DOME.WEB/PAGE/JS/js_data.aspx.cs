using HNNDB09_DOME.BLL;
using HNNDB09_DOME.COMMON;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace HNNDB09_DOME.WEB
{
    public partial class js_data : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OutPutJson();
        }
        public void OutPutJson()
        {
            SQL_DBHelp dp = new SQL_DBHelp();
            JS_BLL bl = new JS_BLL();
            StringBuilder se = new StringBuilder();
            string jsno=Request.QueryString["js_no"];
            if (!string .IsNullOrEmpty(jsno))
            {
                se.Append(" and hnn09_js_no like @hnn09_js_no ");
                DataSQLhelp parame = new DataSQLhelp("@hnn09_js_no", "%" + jsno.Trim() + "%");
                dp.Parames.Add(parame);
            }
            string jszw = Request.QueryString["js_zw"];
            if (jszw!=null &&jszw!="0")
            {
                se.Append("and hnn09_js_zw = @hnn09_js_zw");
                DataSQLhelp parame = new DataSQLhelp("@hnn09_js_zw",jszw.Trim());
                dp.Parames.Add(parame);
            }
            //取参数
            int pageSize = 10, pageIndex = 1;
            //Request获取页面空间或参数值
            if (!String.IsNullOrEmpty(Request.QueryString["pageIndex"]))
            {
                pageIndex = Convert.ToInt32(Request.QueryString["pageIndex"]);
            }
            if (!String.IsNullOrEmpty(Request.QueryString["pageSize"]))
            {
                pageSize = Convert.ToInt32(Request.QueryString["pageSize"]);
            }
            JsonDataSource jds = bl.list(pageIndex ,pageSize ,se.ToString(),dp);

            DataTable dt = jds.List;//GvDataSource();
            String json = "{\"total\":" + jds.ListRecord + ",\"rows\":";
            //DataTable数据
            json += new mtojson().getjson(dt);
            json += "}";

            //Response对象输出内容到前台页面
            Response.Clear();
            Response.Write(json);
            Response.End();
        }
    }
}