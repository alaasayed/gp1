using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppD2
{
    public partial class ass1 : System.Web.UI.Page
    {
        private string age0;

        public string age1 { get { return age0; } }
        protected void Page_Load(object sender, EventArgs e)
        {

            ddly.Items.Insert(0, "1990");

            for (int i=1; i<25;i++)
            ddly.Items.Insert(i, (1999+i).ToString());
            ddlm.Items.Insert(0, "1");

            for (int i = 1; i < 12; i++)
                ddlm.Items.Insert(i, (1+i).ToString());
            ddld.Items.Insert(0, "1");

            for (int i = 1; i < 30; i++)
                ddld.Items.Insert(i, (i+1).ToString());
        }

        protected void ddly_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime d2 = new DateTime(int.Parse(ddly.SelectedValue),int.Parse(ddlm.SelectedValue),int.Parse(ddld.SelectedValue));
            DateTime d1 = DateTime.Now;

            decimal ds = (decimal)(d1 - d2).TotalDays;
            decimal y1 = (decimal)ds / 365.25m;
            decimal m1 = ((decimal)ds - (y1 * 365.25m)) / 12m;
            decimal d11 = Math.Abs((decimal)ds - (m1 * 30m) - (y1 * 365.25m));
            age0 = "your age is" + (int)y1 + "  years  ," + (int)m1 + "  months  ," + d11 + "  days .";
        }
    }
}