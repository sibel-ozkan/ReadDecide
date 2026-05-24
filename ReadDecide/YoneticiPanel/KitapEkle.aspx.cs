using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide.YoneticiPanel
{
    public partial class KitapEkle : System.Web.UI.Page
    {
        VeriTabaniİslemleri db = new VeriTabaniİslemleri();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_ekle_Click(object sender, EventArgs e)
        {
            
            Book kitap = new Book();
            int kategoriId = db.KategoriIdGetir(tb_kategoriId.Text); // yazıldı kategoeri. sistem id yi bulacak kategorinin.bulamazsa kitap eklemeyecek kontrolü bu 

            if (kategoriId == 0)
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Bu isimde bir kategori bulunamadı.";
                return;
            }

            kitap.CategoryId = kategoriId;
            kitap.Title = tb_baslik.Text;
            kitap.Author =tb_yazar.Text;

            if (string.IsNullOrEmpty(tb_kapak.Text))
            {
                kitap.CoverImageUrl = "Images/images.png";
            }
            else
            {
                kitap.CoverImageUrl = tb_kapak.Text;
            }

            kitap.Description = tb_aciklama.Text;
            kitap.Slug = tb_baslik.Text.ToLower().Replace(" ", "-");
            kitap.IsActive = cb_aktif.Checked;

            if(db.KitapEkle(kitap))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible=false;

                lbl_mesaj.Text = "Kitap eklenirken Hata oluştu.";
            }

        }
    }
}