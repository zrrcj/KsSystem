using HNNDB09_DOME.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNNDB09_DOME.WEB.PAGE.WT
{
    public partial class del : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            WT_BLL da = new WT_BLL();
            if (da.delete("hnn09_wt", "hnn09_wt_id", id))
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