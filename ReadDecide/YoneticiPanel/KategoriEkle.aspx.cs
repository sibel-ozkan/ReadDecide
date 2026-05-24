using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide.YoneticiPanel
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        VeriTabaniİslemleri db = new VeriTabaniİslemleri();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_ekle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_isim.Text))
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Kategori adı boş bırakılamaz.";
            }
            else
            {
                Category cat = new Category();

                cat.Name = tb_isim.Text;
                cat.Slug = tb_isim.Text.ToLower().Replace(" ", "-");
                cat.IsActive = cb_aktif.Checked;

                if (db.KategoriEkle(cat))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;

                    tb_isim.Text = "";
                    cb_aktif.Checked = true;
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Kategori eklenirken bir hata oluştu.";
                }
            }
        }
    
    }
}