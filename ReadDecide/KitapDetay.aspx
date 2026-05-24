<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KitapDetay.aspx.cs" Inherits="ReadDecide.KitapDetay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kitap Detay | Read & Decide</title>
    <link href="YoneticiPanel/css/anaStil.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="siteUst">
            <div class="siteLogo">Read&Decide</div>

            <div class="siteMenu">

                <a href="Default.aspx">Ana Sayfa</a>

                <asp:Label ID="lbl_kullanici" runat="server"></asp:Label>

                <asp:Panel ID="pnl_cikisYap" runat="server">

                    <asp:LinkButton
                        ID="lnk_cikis"
                        runat="server"
                        OnClick="lnk_cikis_Click">

            Çıkış Yap

                    </asp:LinkButton>

                </asp:Panel>

                <asp:Panel ID="pnl_girisYap" runat="server">

                    <a href="YoneticiPanel/yoneticiGiris.aspx">Giriş Yap
                    </a>

                </asp:Panel>

            </div>
        </div>

        <div class="siteAltBaslik">
            Read reviews. Decide better.
        </div>

        <div class="detayAlan">

            <asp:Image ID="img_kapak" runat="server" CssClass="detayKapak" />

            <div class="detayBilgi">
                <h1>
                    <asp:Label ID="lbl_baslik" runat="server"></asp:Label>
                </h1>
                <p>
                    <strong>Yazar:</strong>
                    <asp:Label ID="lbl_yazar" runat="server"></asp:Label>
                </p>
                <p>
                    <strong>Kategori:</strong>
                    <asp:Label ID="lbl_kategori" runat="server"></asp:Label>
                </p>
                <p>
                    <asp:Label ID="lbl_aciklama" runat="server"></asp:Label>
                </p>
            </div>
        </div>
        <div class="yorumAlan">
            <h2>Yorumlar</h2>
            <asp:ListView ID="lv_yorumlar" runat="server">
                <ItemTemplate>
                    <div class="yorumKart">
                        <div class="yorumUst">
                            <strong><%# Eval("UserName") %></strong>
                            <span><%# Eval("CreatedAt", "{0:dd.MM.yyyy}") %></span>
                        </div>

                        <p><%# Eval("Text") %></p>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="yorumYazPanel">
            <asp:Panel ID="pnl_yorumYap" runat="server">
                <h2>Yorum Yap</h2>
                <asp:Panel ID="pnl_yorumForm" runat="server">
                    <asp:TextBox
                        ID="txt_yorum"
                        runat="server"
                        TextMode="MultiLine"
                        CssClass="yorumTextbox">
                    </asp:TextBox>
                    <asp:Button
                        ID="btn_yorumGonder"
                        runat="server"
                        Text="Yorumu Gönder"
                        CssClass="yorumButon" OnClick="btn_yorumGonder_Click1" />
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnl_girisUyari" runat="server">
                <asp:Label ID="lbl_girisUyari" runat="server"
                    Text="Yorum yapmak için giriş yapın."></asp:Label>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
