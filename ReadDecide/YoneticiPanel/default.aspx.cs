using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide.YoneticiPanel
{
    public partial class _default : System.Web.UI.Page
    {
        VeriTabaniİslemleri db = new VeriTabaniİslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_toplamKitap.Text = db.ToplamKitapSayisi().ToString();

                lbl_toplamKategori.Text = db.ToplamKategoriSayisi().ToString();

                lbl_toplamUye.Text = db.ToplamUyeSayisi().ToString();

                lbl_toplamYorum.Text = db.ToplamYorumSayisi().ToString();

                lv_sonYorumlar.DataSource = db.SonYorumlariGetir();
                lv_sonYorumlar.DataBind();

                lv_sonKitaplar.DataSource = db.SonKitaplariGetir();
                lv_sonKitaplar.DataBind();

                lv_sonUyeler.DataSource = db.SonUyeleriGetir();
                lv_sonUyeler.DataBind();
            }
        }
    }
}