using HNNDB09_DOME.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNNDB09_DOME.WEB.PAGE.XK
{
    public partial class del : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            XK_BLL da = new XK_BLL();
            if (da.delete("hnn09_xk", "hnn09_xk_id", id))
            {
                Response.Write("true");
            }
            else
            {
                Response.Write("false");
            }
        }
    }
}