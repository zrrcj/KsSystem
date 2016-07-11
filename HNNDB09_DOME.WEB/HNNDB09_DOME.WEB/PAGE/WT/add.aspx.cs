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

namespace HNNDB09_DOME.WEB.PAGE.WT
{
    public partial class add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                load();
                string pkid = Request.QueryString["id"];
                clss_id.Value = pkid;
                if (!string.IsNullOrEmpty(pkid))
                {
                    LoadFormData(pkid);
                }
            }
           
        }
        public void LoadFormData(string id)
        {
            WT_BLL da = new WT_BLL();
            WT_Model m = da.updata("hnn09_wt", id);
            if (m == null)
            {
                //new MsgHelper().ShowAlert(this, "请求修改信息出错！");
                return;

            }

            hnn09_wt_wt.Text = m.HNN09_WT_WT;
            hnn09_wt_da.Text = m.HNN09_WT_DA;
            km.SelectedValue = m.HNN09_WT_XKID.ToString();
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
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (clss_id.Value != "")
            {
                WT_Model m = new WT_Model();
                m.HNN09_WT_ID = Convert.ToInt32(clss_id.Value);
                m.HNN09_WT_WT = hnn09_wt_wt.Text.Trim();
                m.HNN09_WT_XKID = Convert.ToInt32(km.SelectedValue);
                m.HNN09_WT_DA = hnn09_wt_da.Text.Trim();
                WT_BLL da = new WT_BLL();
                if (da.updata(m))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script>window.parent.qd('修改成功！');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script>window.parent.qd('修改失败！');</script>");
                }
            }
            else
            {
               WT_Model m = new WT_Model();
                m.HNN09_WT_WT = hnn09_wt_wt.Text.Trim();
                m.HNN09_WT_XKID = Convert.ToInt32(km.SelectedValue);
                m.HNN09_WT_DA = hnn09_wt_da.Text.Trim();
               WT_BLL bll = new WT_BLL();
                if (bll.add(m))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script>window.parent.qd('添加成功！');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script>window.parent.qd('修改失败！');</script>");
                }
            }
        }
    }
}