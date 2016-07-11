using HNNDB09_DOME.BLL;
using HNNDB09_DOME.COMMON;
using HNNDB09_DOME.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNNDB09_DOME.WEB.PAGE.JS
{
    public partial class js_rjxk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFormData(Request.QueryString["id"]);
            }
            
        }
        public void LoadFormData(string id)
        {
            SQL_DBHelp dp = new SQL_DBHelp();
            JS_BLL da = new JS_BLL();
            dp.Parames.Add(new DataSQLhelp("@HNN09_JS_ID", id));
            string sql = "P_RJXK";
            DataTable m = da.list(sql, dp);
            if (m != null)
            {
                bj.Items.Clear();
                if (m.Rows.Count > 0)
                {

                    foreach (DataRow li in m.Rows)
                    {
                        ListItem l = new ListItem(li["HNN09_XK_NAME"].ToString(), li["HNN09_XK_ID"].ToString());
                        if (li["HNN09_RJXK_JSID"].ToString().Equals(id))
                        {
                            l.Selected = true;
                        }
                        bj.Items.Add(l);
                    }
                }

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<RJXK_Model> lm = new List<RJXK_Model>();
            lm.Clear(); 
            string pkid = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(pkid))
            {
            foreach (ListItem li in bj.Items)
            {
                if (li.Selected)
                {
                    RJXK_Model m = new RJXK_Model();
                    m.HNN09_RJXK_XKID = Convert.ToInt32(li.Value);
                    m.HNN09_RJXK_JSID = Convert.ToInt32(pkid);
                    lm.Add(m);
                }

            }
            JS_BLL da = new JS_BLL();
            if (da.add(lm, pkid))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script>window.parent.qd('操作成功！');</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script>window.parent.qd('操作失败！');</script>");
            }
            }
        }
    }
}