using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide.YoneticiPanel
{
    public partial class masterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] !=null)
            {
                Admin admn = (Admin)Session["admin"];
                lbl_kullanici.Text = admn.UserName;
            }
            else
            {
                Response.Redirect("yoneticiGiris.aspx");
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["admin"] = null;
            Response.Redirect("yoneticiGiris.aspx");
        }
    }
}