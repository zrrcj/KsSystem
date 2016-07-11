using HNNDB09_DOME.BLL;
using HNNDB09_DOME.COMMON;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNNDB09_DOME.WEB.PAGE.XS
{
    public partial class list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            SQL_DBHelp dp = new SQL_DBHelp();
            DataTable dt = dp.GetList("select * from HNN09_CLSS");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        js_bj.Items.Clear();
                        js_bj.Items.Add(new ListItem("不限", "0"));
                        foreach (DataRow dr in dt.Rows)
                        {
                            js_bj.Items.Add(new ListItem(dr["HNN09_CLSS_NAME"].ToString(), dr["HNN09_CLSS_ID"].ToString()));
                        }
                    }
                }
            }
        }
    }
}