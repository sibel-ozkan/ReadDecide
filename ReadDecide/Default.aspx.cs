using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide
{
    public partial class Default : System.Web.UI.Page
    {
        VeriTabaniİslemleri db = new VeriTabaniİslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KitaplariGetir();
            }

        }
        void KitaplariGetir() // URL’de kategori yoksa tüm kitapları getiriyor.varsa sadece o kategoriye ait kitaplar
        {
            string kategori = Request.QueryString["kategori"];

            if (string.IsNullOrEmpty(kategori))
            {
                lv_kitaplar.DataSource = db.AnaSayfaKitapListele();
            }
            else
            {
                lv_kitaplar.DataSource = db.KategoriyeGoreKitapGetir(kategori);
            }

            lv_kitaplar.DataBind();
        }
    }
}