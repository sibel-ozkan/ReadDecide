using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide
{
    public partial class KitapDetay : System.Web.UI.Page
    {
        VeriTabaniİslemleri db = new VeriTabaniİslemleri();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KitapGetir();
                YorumlariGetir();

                if (Session["User"] != null)
                {
                    pnl_yorumYap.Visible = true;
                    lbl_girisUyari.Visible = false;
                }
                else
                {
                    pnl_yorumYap.Visible = false;
                    lbl_girisUyari.Visible = true;
                }
                if (Session["User"] != null)
                {
                    Admin admin = (Admin)Session["User"];
                    lbl_kullanici.Text = "Hoş geldin, " + admin.UserName;
                }
            }
            if (Session["User"] != null)
            {
                pnl_cikisYap.Visible = true;
                pnl_girisYap.Visible = false;

                Admin admin = (Admin)Session["User"];

                lbl_kullanici.Text = "Hoş geldin, " + admin.UserName;
            }
            else
            {
                pnl_cikisYap.Visible = false;
                pnl_girisYap.Visible = true;

                lbl_kullanici.Text = "";
            }
        }

        void KitapGetir() // url den bookid aldık, database e uğradık- o kitabı buldu- labela koy sayfada göster.
        {
            int bookId = Convert.ToInt32(Request.QueryString["bookid"]);

            Book kitap = db.KitapDetayGetir(bookId);

            if (kitap != null)
            {
                lbl_baslik.Text = kitap.Title;
                lbl_yazar.Text = kitap.Author;
                lbl_kategori.Text = kitap.CategoryName;
                lbl_aciklama.Text = kitap.Description;

                img_kapak.ImageUrl = "Images/images.png";
            }
        }

        void YorumlariGetir()
        {
            int bookId = Convert.ToInt32(Request.QueryString["bookid"]);

            lv_yorumlar.DataSource = db.KitabaAitYorumlariGetir(bookId);
            lv_yorumlar.DataBind();
        }

        protected void btn_yorumGonder_Click1(object sender, EventArgs e)
        {
            Comments yorum = new Comments();

            yorum.BookId = Convert.ToInt32(Request.QueryString["bookid"]);
            Admin admin = (Admin)Session["Admin"];
            yorum.UserId = admin.UserId;
            yorum.Text = txt_yorum.Text;

            bool sonuc = db.YorumEkle(yorum);

            if (sonuc)
            {
                Response.Redirect("KitapDetay.aspx?bookid=" + yorum.BookId);
            }
        }
        protected void lnk_cikis_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;

            Response.Redirect("Default.aspx");
        }
    }
}