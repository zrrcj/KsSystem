using HNNDB09_DOME.BLL;
using HNNDB09_DOME.COMMON;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNNDB09_DOME.WEB.PAGE.TJ
{
    public partial class listData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OutPutJson();
        }
        public void OutPutJson()
        {
            SQL_DBHelp dp = new SQL_DBHelp();
            XS_BLL bl = new XS_BLL();
            StringBuilder se = new StringBuilder();
            string jsno = Request.QueryString["xs_no"];
            if (!string.IsNullOrEmpty(jsno))
            {
                dp.Parames.Clear();
                se.Append(" and hnn09_xs_no like @hnn09_xs_no ");
                DataSQLhelp parame = new DataSQLhelp("@hnn09_xs_no", "%" + jsno.Trim() + "%");
                dp.Parames.Add(parame);
            }
            string jszw = Request.QueryString["xs_bj"];
            if (jszw != null && jszw != "0")
            {
                dp.Parames.Clear();
                se.Append("and hnn09_xs_clsid = @hnn09_xs_clsid");
                DataSQLhelp parame = new DataSQLhelp("@hnn09_xs_clsid", jszw.Trim());
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
            JsonDataSource jds = bl.list(pageIndex, pageSize, se.ToString(), dp,"");

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