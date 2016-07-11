using HNNDB09_DOME.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNNDB09_DOME.WEB.PAGE.CLSS
{
    public partial class del : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            CLSS_BLL da = new CLSS_BLL();
            if (da.delete("hnn09_clss", "hnn09_clss_id", id))
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