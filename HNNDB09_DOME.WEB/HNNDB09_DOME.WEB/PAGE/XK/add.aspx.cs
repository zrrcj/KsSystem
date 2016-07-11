using HNNDB09_DOME.BLL;
using HNNDB09_DOME.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNNDB09_DOME.WEB.PAGE.XK
{
    public partial class add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pkid = Request.QueryString["id"];
                clss_id.Value = pkid;
                if (!string.IsNullOrEmpty(pkid))
                {
                    //执行修改加载数据操作
                    LoadFormData(pkid);
                }
            }
        }
        public void LoadFormData(string id)
        {
            XK_BLL da = new XK_BLL();
            XK_Model m = da.updata("hnn09_xk", id);
            if (m == null)
            {
                //new MsgHelper().ShowAlert(this, "请求修改信息出错！");
                return;

            }

            hnn09_xk_name.Text = m.hnn09_xk_name;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (clss_id.Value != "")
            {
                XK_Model m = new XK_Model();
                m.hnn09_xk_id = Convert.ToInt32(clss_id.Value);
                m.hnn09_xk_name = hnn09_xk_name.Text.Trim();
                XK_BLL da = new XK_BLL();
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
                XK_Model m = new XK_Model();
                m.hnn09_xk_name = hnn09_xk_name.Text.Trim();
                XK_BLL bll = new XK_BLL();
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