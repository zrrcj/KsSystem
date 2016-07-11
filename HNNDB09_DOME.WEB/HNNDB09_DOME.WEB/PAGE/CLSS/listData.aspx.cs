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

namespace HNNDB09_DOME.WEB.PAGE.CLSS
{
    public partial class listData : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OutPutJson();
        }
        public void OutPutJson()
        {
            SQL_DBHelp dp = new SQL_DBHelp();
            CLSS_BLL bl = new CLSS_BLL();
            StringBuilder se = new StringBuilder();
            string jsno = Request.QueryString["clssno"];
            if (!string.IsNullOrEmpty(jsno))
            {
                se.Append(" and hnn09_clss_name like @hnn09_clss_name ");
                DataSQLhelp parame = new DataSQLhelp("@hnn09_clss_name", "%"+jsno.Trim()+"%");
                dp.Parames.Add(parame);
            }
            //string jszw = Request.QueryString["js_zw"];
            //if (jszw != null && jszw != "0")
            //{
            //    se.Append("and hnn09_clss_number = @hnn09_clss_number");
            //    DataSQLhelp parame = new DataSQLhelp("@hnn09_clss_number", jszw);
            //    dp.Parames.Add(parame);
            //}
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
            JsonDataSource jds = bl.list(pageIndex, pageSize, se.ToString(), dp);

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