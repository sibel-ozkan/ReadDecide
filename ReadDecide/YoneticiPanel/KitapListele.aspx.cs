using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace ReadDecide.YoneticiPanel
{
    public partial class KitapListele : System.Web.UI.Page
    {
        VeriTabaniİslemleri db = new VeriTabaniİslemleri();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KitaplariGetir();
            }
        }

        void KitaplariGetir()   /*tekrar kullanmak için bi metot düzenlemek mantıklı gibi.*/
        {
            lv_kitaplar.DataSource = db.KitapListele();
            lv_kitaplar.DataBind();
        }
    }
}