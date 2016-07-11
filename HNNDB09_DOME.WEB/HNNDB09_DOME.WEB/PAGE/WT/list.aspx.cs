using HNNDB09_DOME.BLL;
using HNNDB09_DOME.COMMON;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNNDB09_DOME.WEB.PAGE.WT
{
    public partial class list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                load();
            }
        }
        private void load()
        {
            SQL_DBHelp dp = new SQL_DBHelp();
            JS_BLL bll1 = new JS_BLL();
            DataTable dt1 = bll1.list(" V_TWXK", "", dp);
            if (dt1 != null)
            {
                if (dt1.Rows.Count > 0)
                {
                    km.Items.Clear();
                    foreach (DataRow dr in dt1.Rows)
                    {
                        km.Items.Add(new ListItem(dr["HNN09_XK_NAME"].ToString(), dr["HNN09_XK_ID"].ToString()));
                    }
                    km.Items.Add(new ListItem("不限", "0"));
                }
            }
        }
    }
}