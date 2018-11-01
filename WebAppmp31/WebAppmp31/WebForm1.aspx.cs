using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppmp31
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btn1_Click(object sender, EventArgs e)
        {
            aud1.Attributes["src"] = "r113.mp3";
            
        }

        protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            aud1.Attributes["src"] = ddl1.SelectedValue;
        }
    }
}