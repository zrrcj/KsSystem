using HNNDB09_DOME.COMMON;
using HNNDB09_DOME.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNNDB09_DOME.MODEL;
using System.Data;

namespace HNNDB09_DOME.WEB.PAGE.JS
{
   
   
    public partial class js_tw : System.Web.UI.Page
    {
        //private int xsid;
        //private int wtid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadKmandBj();
            }
            
        }
        private void LoadKmandBj()
        {
            SQL_DBHelp dp = new SQL_DBHelp();
            JS_BLL bll = new JS_BLL();
            if (Session["User"]!=null)
            {
                int jsid = ((JS_Model)Session["User"]).hnn09_js_id;
                dp.Parames.Clear();
                dp.Parames.Add(new DataSQLhelp("@hnn09_js_id", jsid));
                DataTable dt = bll.list(" V_TWBJ", " AND HNN09_BJRJ_JSID=@hnn09_js_id", dp);
                dp.Parames.Clear();
                dp.Parames.Add(new DataSQLhelp("@hnn09_js_id", jsid));
                JS_BLL bll1 = new JS_BLL();
                DataTable dt1 = bll1.list(" V_TWXK", " AND HNN09_RJXK_JSID=@hnn09_js_id", dp);
                dp.CloseResource();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        bj.Items.Clear();
                        foreach (DataRow dr in dt.Rows)
                        {
                            bj.Items.Add(new ListItem(dr["HNN09_CLSS_NAME"].ToString(), dr["HNN09_CLSS_ID"].ToString()));
                        }
                    }
                }
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
            else
            {
                Response.Redirect("/login.aspx");
            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string sql = "";
            string xsname="";
            string xsno = "";
            WT_BLL da = new WT_BLL();
            if (km.SelectedValue.Equals("0"))
            {
                
            }
            else
            {
                sql = " and HNN09_WT_XKID=" + km.SelectedValue;   
            }
            WT_Model m = da.select(sql);
            XS_BLL xs = new XS_BLL();
            SQL_DBHelp dp = new SQL_DBHelp();
            dp.Parames.Clear();
            dp.Parames.Add(new DataSQLhelp("@HNN09_XS_CLSID", bj.SelectedValue));
            DataTable dt= xs.select(dp);
            if (dt!=null)
            {
                if (dt.Rows.Count>0)
                {
                    foreach (DataRow  dr in dt.Rows)
                    {
                        xsid.Value = dt.Rows[0]["HNN09_XS_ID"].ToString();
                        xsname = dt.Rows[0]["HNN09_XS_NAME"].ToString();
                        xsno = dt.Rows[0]["HNN09_XS_NO"].ToString();
                    }
                    
                }
                
            }
            if ( xsname == "")
            {
                name.Text = "当前班级没有学生";
            }
            else
            {
                name.Text ="请"+xsno+"号同学 【"+ xsname+"】 回答：";
                if (m != null)
                {
                    wt.Text = m.HNN09_WT_WT;
                    DA.Text = m.HNN09_WT_DA;
                    wtid.Value = m.HNN09_WT_ID.ToString();
                }
                else
                {
                    wt.Text = "当前科目下没有添加问题";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //string a = TextBox1.Text;
            CJ_Model m = new CJ_Model();
            m.HNN09_CJ_CJ =Convert.ToInt32(TextBox2.Text.Trim());
            if (wtid.Value!=""&&xsid.Value!="")
            {
                m.HNN09_CJ_WTID =Convert.ToInt32( wtid.Value);
                m.HNN09_CJ_XSID = Convert.ToInt32(xsid.Value);
                CJ_BLL bll = new CJ_BLL();
                if (bll.add(m))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script> $.messager.alert('消息', '录入成功！');</script>");
                    TextBox2.Text = "";
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script>$.messager.alert('消息', '录入失败！');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script> $.messager.alert('消息', '没有提问学生！');</script>");
            }
           

        }

    }
}