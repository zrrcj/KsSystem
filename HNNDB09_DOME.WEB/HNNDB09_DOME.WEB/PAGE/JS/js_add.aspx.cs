using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNNDB09_DOME.MODEL;
using HNNDB09_DOME.BLL;
using HNNDB09_DOME.COMMON;

namespace HNNDB09_DOME.WEB
{
    public partial class js_add : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 1; i < 46; i++)
                {
                    hnn09_js_sj.Items.Add(new ListItem(i.ToString() + " 年", i.ToString()));
                }
                string pkid = Request.QueryString["id"];
                js_id.Value = pkid;
                if (!string.IsNullOrEmpty(pkid))
                {
                    //执行修改加载数据操作
                    LoadFormData(pkid);
                }
            } 
        }
        public void LoadFormData(string  id)
        {
            JS_BLL da = new JS_BLL();
            JS_Model m = da.updata("hnn09_js", id);
            if (m == null)
            {
               //new MsgHelper().ShowAlert(this, "请求修改信息出错！");
                return;

            }
           
            hnn09_js_name.Text = m.hnn09_js_name;
            hnn09_js_no.Text = m.hnn09_js_no;
            //hnn09_js_pwd.Text = new DESEncrypt().Decrypt(m.hnn09_js_pwd);
            hnn09_js_sex.SelectedValue = m.hnn09_js_sex.ToString();
            hnn09_js_sj.SelectedValue = m.hnn09_js_sj.ToString();
            hnn09_js_zc.SelectedValue = m.hnn09_js_zc;
            hnn09_js_zw.SelectedValue = m.hnn09_js_zw;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (js_id.Value!="")
            {
                JS_Model m = new JS_Model();
                m.hnn09_js_id = Convert.ToInt32(js_id.Value);
                m.hnn09_js_name = hnn09_js_name.Text.Trim();
                m.hnn09_js_no = hnn09_js_no.Text.Trim();
                //m.hnn09_js_pwd = ((JS_Model)Session["User"]).hnn09_js_pwd;
                m.hnn09_js_sex = Convert.ToInt32(hnn09_js_sex.SelectedValue);
                m.hnn09_js_sj = Convert.ToInt32(hnn09_js_sj.SelectedValue);
                m.hnn09_js_zc = hnn09_js_zc.SelectedValue;
                m.hnn09_js_zw = hnn09_js_zw.SelectedValue;
                JS_BLL da = new JS_BLL();
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
                JS_Model m = new JS_Model();
                m.hnn09_js_no = hnn09_js_no.Text.Trim();
                m.hnn09_js_name = hnn09_js_name.Text.Trim();
                m.hnn09_js_pwd = new DESEncrypt().Encrypt("123456");
                m.hnn09_js_sex = Convert.ToInt32(hnn09_js_sex.SelectedValue);
                m.hnn09_js_zw = hnn09_js_zw.SelectedValue;
                m.hnn09_js_zc = hnn09_js_zc.SelectedValue;
                m.hnn09_js_sj = Convert.ToInt32(hnn09_js_sj.SelectedValue);
                JS_BLL bll = new JS_BLL();
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