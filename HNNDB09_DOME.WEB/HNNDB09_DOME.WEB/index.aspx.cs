using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNNDB09_DOME.MODEL;
using HNNDB09_DOME.BLL;

namespace HNNDB09_DOME.WEB
{
    public partial class index : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (((JS_Model)Session["User"]).hnn09_js_no=="admin")
                {
                    qx("11111");
                    qx11.Visible = true;
                    tw6.Visible = false;
                }
                else
                {
                    Base_BLL bll = new Base_BLL();
                    QX_Model M = new QX_Model();
                    M = bll.List(((JS_Model)Session["User"]).hnn09_js_id.ToString());
                    qx(M.HNN09_QX_QX); 
                }
               
            }
            
               
            
           
        }
        public void qx(string str )
        {
            //if (((JS_Model)Session["User"]).hnn09_js_no=="admin")
            //{
               qx1.Visible = false;
               qx11.Visible = false;
            //    xtsz.Visible = true;
            //}
            //else
            //{
                
            //    qx1.Visible = false;
            //    xtsz.Visible = false;
            //}
            if (str[0] == '1')
            {
                js1.Visible = true;
            }
            else
            {
                js1.Visible = false ;
            }
            if (str[1] == '1')
            {
                bj2.Visible = true;
            }
            else
            {
                bj2.Visible = false ;
            }
            if (str[2] == '1')
            {
                xk3.Visible = true;
            }
            else
            {
                xk3.Visible = false ;
            }
            if (str[3] == '1')
            {
               xs4.Visible = true;
            }
            else
            {
                xs4.Visible = false ;
            }
            if (str[4] == '1')
            {
               wt5.Visible = true;
            }
            else
            {
                wt5.Visible = false ;
            }
           
        }
        protected void zx_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Session["User"] = null;
            Response.Redirect("/login.aspx");
        }
    }
}