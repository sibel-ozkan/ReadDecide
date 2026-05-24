using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide
{
    public partial class uyeOl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_uyeOl_Click1(object sender, EventArgs e)
        {
            VeriTabaniİslemleri db = new VeriTabaniİslemleri();

            User uye = new User();

            uye.DisplayName = tb_adsoyad.Text;
            uye.Email = tb_mail.Text;
            uye.Password = tb_sifre.Text;
            uye.UserName = tb_kullaniciAdi.Text;

            bool sonuc = db.UyeEkle(uye);

            if (sonuc)
            {
                Response.Redirect("GirisYap.aspx");
            }
        }
    }
}