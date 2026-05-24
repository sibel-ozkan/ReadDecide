using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide.YoneticiPanel
{
    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        VeriTabaniİslemleri db = new VeriTabaniİslemleri();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["kategoriid"]);

                    Category cat = db.KategoriGetir(id);

                    if (cat != null)
                    {
                        tb_isim.Text = cat.Name;
                        cb_aktif.Checked = cat.IsActive;
                    }
                }
            }
            else
            {
                Response.Redirect("KategoriListele.aspx");
            }
        }

        protected void btn_duzenle_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(Request.QueryString["kategoriid"]);
            Category kat = new Category();
            kat.CategoryId = id;
            kat.Name = tb_isim.Text;
            kat.IsActive = cb_aktif.Checked;

            if (db.KategoriGuncelle(kat))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarisiz.Visible=true;
                pnl_basarili.Visible=false;
                lbl_mesaj.Text = " Kategori Güncellenirken bir hata oluştu.";
            }
        }
    }
}