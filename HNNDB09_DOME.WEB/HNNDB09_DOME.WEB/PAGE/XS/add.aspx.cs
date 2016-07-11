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

namespace HNNDB09_DOME.WEB.PAGE.XS
{
    public partial class add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 15; i < 30; i++)
                {
                    hnn09_xs_age.Items.Add(new ListItem(i.ToString() + " 岁", i.ToString()));
                }
                string pkid = Request.QueryString["id"];
                xs_id.Value = pkid;
                if (!string.IsNullOrEmpty(pkid))
                {
                    load();
                    //执行修改加载数据操作
                    LoadFormData(pkid);
                    
                }
                else
                {
                    load();
                }
               
            }
        }
        public void load()
        {   
            SQL_DBHelp dp = new SQL_DBHelp();
            JS_BLL bll1 = new JS_BLL();
             //dp.Parames.Add(new DataSQLhelp("@HNN09_JS_ID", id));
            DataTable m = bll1.list("V_BJ","", dp);
            if (m != null)
            {
               if (m.Rows.Count > 0)
               {
                   km.Items.Clear();
                   foreach (DataRow dr in m.Rows)
                   {
                       km.Items.Add(new ListItem(dr["HNN09_CLSS_NAME"].ToString(), dr["HNN09_CLSS_ID"].ToString()));
                   }
                   //km.Items.Add(new ListItem("不限", "0"));
               }
            }
           
            //DataTable dt1 = bll1.list(" V_XK", "", dp);
            //if (dt1 != null)
            //{
            //    if (dt1.Rows.Count > 0)
            //    {
            //        km.Items.Clear();
            //        foreach (DataRow dr in dt1.Rows)
            //        {
            //            km.Items.Add(new ListItem(dr["HNN09_XK_NAME"].ToString(), dr["HNN09_XK_ID"].ToString()));
            //        }
            //        //km.Items.Add(new ListItem("不限", "0"));
            //    }
            //}
        }
        public void LoadFormData(string id)
        {
            XS_BLL da = new XS_BLL();
            XS_Model m = da.updata("hnn09_xs", id);
            if (m == null)
            {
                //new MsgHelper().ShowAlert(this, "请求修改信息出错！");
                return;
            }
            hnn09_xs_name.Text = m.hnn09_xs_name;
            hnn09_xs_no.Text = m.hnn09_xs_no;
            //hnn09_xs_pwd.Text = new DESEncrypt().Decrypt(m.hnn09_xs_pwd);
            hnn09_xs_sex.SelectedValue = m.hnn09_xs_sex.ToString();
            hnn09_xs_age.SelectedValue = m.hnn09_xs_age.ToString();
            hnn09_xs_phone.Text = m.hnn09_xs_phone;
            km.SelectedValue = m.hnn09_xs_clsid.ToString();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (xs_id.Value != "")
            {
                XS_Model m = new XS_Model();
                m.hnn09_xs_id = Convert.ToInt32(xs_id.Value);
                m.hnn09_xs_name = hnn09_xs_name.Text.Trim();
                m.hnn09_xs_no = hnn09_xs_no.Text.Trim();
                //m.hnn09_xs_pwd = new DESEncrypt().Encrypt(hnn09_xs_pwd.Text.Trim());
                m.hnn09_xs_sex = Convert.ToInt32(hnn09_xs_sex.SelectedValue);
                m.hnn09_xs_age = Convert.ToInt32(hnn09_xs_age.SelectedValue);
                m.hnn09_xs_phone = hnn09_xs_phone.Text.Trim();
                m.hnn09_xs_clsid = Convert.ToInt32(km.SelectedValue);
               
                XS_BLL da = new XS_BLL();
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
                XS_Model m = new XS_Model();
                m.hnn09_xs_no = hnn09_xs_no.Text.Trim();
                m.hnn09_xs_name = hnn09_xs_name.Text.Trim();
                m.hnn09_xs_pwd = new DESEncrypt().Encrypt("123456");
                m.hnn09_xs_sex = Convert.ToInt32(hnn09_xs_sex.SelectedValue);
                m.hnn09_xs_age =Convert .ToInt32( hnn09_xs_age.SelectedValue);
                m.hnn09_xs_phone = hnn09_xs_phone.Text.Trim();
                m.hnn09_xs_clsid = Convert.ToInt32(km.SelectedValue);
                XS_BLL bll = new XS_BLL();
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