using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide
{
    public partial class GirisYap : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click1(object sender, EventArgs e)
        {
            VeriTabaniİslemleri db = new VeriTabaniİslemleri();

            User kullanici = db.KullaniciGiris(
                tb_mail.Text,
                tb_sifre.Text
            );

            if (kullanici != null)
            {
                Session["Kullanici"] = kullanici;

                Response.Redirect("Default.aspx");
            }
            else
            {
                pnl_mesaj.Visible = true;

                lbl_mesaj.Text = "Mail veya şifre hatalı.";
            }
        }
    }
}