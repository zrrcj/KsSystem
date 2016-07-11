using HNNDB09_DOME.BLL;
using HNNDB09_DOME.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNNDB09_DOME.WEB
{
    public partial class sevepwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            JS_Model m =(JS_Model)Session ["User"];
            m.hnn09_js_pwd =new HNNDB09_DOME.COMMON.DESEncrypt().Encrypt( pwd.Text.Trim());
            if (new Base_BLL().update(m))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script>window.parent.qgma('修改成功！');</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script>window.parent.qgma('修改失败！');</script>");
            }
        }
    }
}