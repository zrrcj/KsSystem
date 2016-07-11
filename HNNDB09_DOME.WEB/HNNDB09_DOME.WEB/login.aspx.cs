using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNNDB09_DOME.BLL;
using HNNDB09_DOME.MODEL;
using System.Text;
using HNNDB09_DOME.COMMON;

namespace BXDL
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginBtn_Click(object sender, EventArgs e)
        {
            SQL_DBHelp dp = new SQL_DBHelp();
            string jsno = js_no.Text.Trim();
            string jspwd = new DESEncrypt().Encrypt(password.Text.Trim());
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from hnn09_js where hnn09_js_no=@hnn09_js_no and hnn09_js_pwd=@hnn09_js_pwd");
            dp.Parames.Add(new DataSQLhelp("@hnn09_js_no", jsno));
            dp.Parames.Add(new DataSQLhelp("@hnn09_js_pwd", jspwd));
            JS_BLL da = new JS_BLL();
            JS_Model m = da.selects(sql.ToString(), dp);
            if (m != null)
            {
                Session["User"] = m;
                Response.Redirect("/index.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码或教师号有误请重新登陆！');location.href = '/login.aspx';</script>");
                // Response.Write("<script>alert('密码或教师号有误请重新登陆！');location.href = '/login.aspx';</script>");
            }
        }
    }
}