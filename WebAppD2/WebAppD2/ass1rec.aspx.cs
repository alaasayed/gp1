using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppD2
{
    public partial class ass1rec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = PreviousPage.age1;
        }
    }
}