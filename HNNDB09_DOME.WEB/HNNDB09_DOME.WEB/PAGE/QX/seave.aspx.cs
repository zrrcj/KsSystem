using HNNDB09_DOME.BLL;
using HNNDB09_DOME.COMMON;
using HNNDB09_DOME.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNNDB09_DOME.WEB.PAGE.QX
{
    public partial class seave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string b = Request["id"];
                Base_BLL bll = new Base_BLL();
                QX_Model m = new QX_Model();
                m = bll.List(b);
                int i = 0;
                    foreach (ListItem li in CheckBoxList1.Items)
                    {
                        if (m.HNN09_QX_QX[i] == '1')
                        {
                            li.Selected = true;
                            i++;
                        }
                        else
                        {
                            li.Selected = false;
                            i++;
                        }
                    }
                

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string a = "";
            foreach (ListItem li in CheckBoxList1.Items)
            {

                if (li.Selected)
                {
                    a += "1";
                }
                else
                {
                    a += "0";
                }
            }
            Base_BLL bll = new Base_BLL();
            string b = Request["id"];
            QX_Model m=new QX_Model ();
            m = bll.List(b);
            m.HNN09_QX_QX = a;
            if (bll.update(m))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script>window.parent.qd('修改成功！');</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", " <script>window.parent.qd('修改失败！');</script>");
            }
           // Response.Write(a);
        }
    }
}