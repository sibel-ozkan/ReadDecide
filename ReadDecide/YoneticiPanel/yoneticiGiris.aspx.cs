using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide.YoneticiPanel
{
    public partial class yoneticiGiris : System.Web.UI.Page
    {
        VeriTabaniİslemleri db = new VeriTabaniİslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            bool durum = true;
            string mesaj = " ";
            if(string.IsNullOrEmpty(tb_mail.Text))
            {
                mesaj = "mail adresi";
                durum = false;
            }
            if(string.IsNullOrEmpty(tb_sifre.Text))
            {
                mesaj = " şifre";
                durum = false;
            }
            if(!durum)
            {
                pnl_mesaj.Visible = true;
                lbl_mesaj.Text = mesaj + " boş bırakılamaz ";
            }
            else
            {
                Admin adm = db.AdminGiris(tb_mail.Text, tb_sifre.Text);
                if (adm != null )
                {
                    if (adm.IsActive)
                    {
                        Session["Admin"] = adm;
                        Response.Redirect("default.aspx");
                    }
                    else
                    {
                        pnl_mesaj.Visible = true;
                        lbl_mesaj.Text = " Hesabınız askıya alındı.";
                    }
                }
                else
                {
                    pnl_mesaj.Visible = true;
                    lbl_mesaj.Text = "Kullanıcı Bulunamadı.Mail ve Şifrenizi Kontrol edin";
                }
            }
        }
    }
}