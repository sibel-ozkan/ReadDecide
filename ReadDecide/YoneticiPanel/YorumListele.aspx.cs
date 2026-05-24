using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide.YoneticiPanel
{
    public partial class YorumListele : System.Web.UI.Page
    {
        VeriTabaniİslemleri db = new VeriTabaniİslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                YorumlariGetir();
            }
        }

        void YorumlariGetir()
        {
            lv_yorumlar.DataSource = db.YorumListele();
            lv_yorumlar.DataBind();
        }
        protected void btn_yorumDurumDegistir_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int commentId = Convert.ToInt32(btn.CommandArgument);

            bool sonuc = db.YorumDurumDegistir(commentId);

            if (sonuc)
            {
                YorumlariGetir();
            }
        }
    }
}