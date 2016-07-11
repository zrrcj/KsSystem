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

namespace HNNDB09_DOME.WEB.PAGE.XK
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
            XK_BLL bl = new XK_BLL();
            StringBuilder se = new StringBuilder();
            string jsno = Request.QueryString["xkno"];
            if (!string.IsNullOrEmpty(jsno))
            {
                se.Append(" and hnn09_xk_name like @hnn09_xk_name ");
                DataSQLhelp parame = new DataSQLhelp("@hnn09_xk_name", "%"+jsno.Trim()+"%");
                dp.Parames.Add(parame);
            }
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