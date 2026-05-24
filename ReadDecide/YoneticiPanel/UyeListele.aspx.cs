using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide.YoneticiPanel
{
    public partial class UyeListele : System.Web.UI.Page
    {
        VeriTabaniİslemleri db =new VeriTabaniİslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UyeleriGetir();
            }
        }
        void UyeleriGetir()
        {
            lv_uyeler.DataSource = db.UyeListele();
            lv_uyeler.DataBind();
        }
        protected void btn_durumDegistir_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int userId = Convert.ToInt32(btn.CommandArgument);

            bool sonuc = db.UyeDurumDegistir(userId);

            if (sonuc)
            {
                UyeleriGetir();
            }
        }
    }
}