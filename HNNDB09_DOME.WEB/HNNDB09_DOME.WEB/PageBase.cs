using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNNDB09_DOME.WEB
{
    public class PageBase : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Session["User"] == null)
            {
                Response.Redirect("/login.aspx");
                return;
            }
            
        }

    }
}