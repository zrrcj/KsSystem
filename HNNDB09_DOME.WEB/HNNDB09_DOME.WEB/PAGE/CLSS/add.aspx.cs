using HNNDB09_DOME.BLL;
using HNNDB09_DOME.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNNDB09_DOME.WEB.PAGE.CLSS
{
    public partial class add : PageBase
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
            CLSS_BLL da = new CLSS_BLL();
            CLSS_Model m = da.updata("hnn09_clss", id);
            if (m == null)
            {
                //new MsgHelper().ShowAlert(this, "请求修改信息出错！");
                return;

            }

            hnn09_clss_name.Text = m.hnn09_clss_name;
            hnn09_clss_number.Text = m.hnn09_clss_number.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (clss_id.Value != "")
            {
                CLSS_Model m = new CLSS_Model();
                m.hnn09_clss_id = Convert.ToInt32(clss_id.Value);
                m.hnn09_clss_name = hnn09_clss_name.Text.Trim();
                m.hnn09_clss_number = Convert.ToInt32(hnn09_clss_number.Text.Trim());
                CLSS_BLL da = new CLSS_BLL();
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
                CLSS_Model m = new CLSS_Model();
                m.hnn09_clss_name = hnn09_clss_name.Text.Trim();
                m.hnn09_clss_number = Convert.ToInt32(hnn09_clss_number.Text.Trim());
                CLSS_BLL bll = new CLSS_BLL();
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