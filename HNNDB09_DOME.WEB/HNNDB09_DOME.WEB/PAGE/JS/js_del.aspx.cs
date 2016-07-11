using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNNDB09_DOME.BLL;

namespace HNNDB09_DOME.WEB
{
    public partial class js_del : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            JS_BLL da = new JS_BLL ();
            if (da.delete("hnn09_js", "hnn09_js_id", id))
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