using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppD2
{
    public partial class ass2cooki : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void b1_Click(object sender, EventArgs e)
        {
            string qs= "username=" + t1.Text + "&skill=" + t2.Text;
            Response.Redirect("ReceiveQuery.aspx?" + HttpUtility.UrlEncode(qs));

            
        }
    }
}