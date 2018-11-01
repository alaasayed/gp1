using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppD2
{
    public partial class ReceiveQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            lbl1.Text ="==>"+ HttpUtility.UrlDecode(Request.QueryString["username"]);

            lbl2.Text = "==>" + HttpUtility.UrlDecode(Request.QueryString["skill"]);

        }
    }
}