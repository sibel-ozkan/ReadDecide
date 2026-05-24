<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yoneticiGiris.aspx.cs" Inherits="ReadDecide.YoneticiPanel.yoneticiGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yönetici Girişi</title>
    <link href="css/GirisStil.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="AnaTasiyici">
            <div class="baslikTasiyici">
                <h1 class="baslik">Yönetici Girişi</h1>
                    <p class="altBaslik">Yönetim paneline erişmek için bilgilerinizi girin.</p>
             </div>

<div class="icerik">
            <asp:Panel ID="pnl_mesaj" runat="server" CssClass="mesajKutu" Visible="false">
             <asp:Label ID="lbl_mesaj" runat="server" Text="Geçici Mesaj"></asp:Label>
                 </asp:Panel>

    <div class="satir">
       <asp:TextBox ID="tb_mail" runat="server" TextMode="Email" CssClass="MetinKutu" placeholder="Mail Adresiniz" Text="admin@readdecide.com"></asp:TextBox>
    </div>

    <div class="satir">
        <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" CssClass="MetinKutu" placeholder="Şifreniz"></asp:TextBox>
    </div>

    <div class="satir sag">
        <a href="#" class="sifreunuttum">Şifremi Unuttum</a>
    </div>

    <div class="satir">
        <asp:Button ID="btn_giris" runat="server" CssClass="girisbutton" Text="Giriş Yap" OnClick="btn_giris_Click" />
    </div>
</div>
        </div>
    </form>
</body>
</html>
