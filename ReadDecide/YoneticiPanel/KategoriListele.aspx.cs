using System;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide.YoneticiPanel
{
    public partial class KategoriListele : System.Web.UI.Page
    {
        VeriTabaniİslemleri db = new VeriTabaniİslemleri();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KategorileriGetir();
            }
        }

        void KategorileriGetir()
        {
            lv_kategoriler.DataSource = db.KategoriListele();
            lv_kategoriler.DataBind();
        }

        protected void lv_kategoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "durum")
            {
                db.KategoriDurumDegistir(id);
                KategorileriGetir();
            }

            if (e.CommandName == "sil")
            {
                db.KategoriSil(id);
                KategorileriGetir();
            }
        }
    }
}