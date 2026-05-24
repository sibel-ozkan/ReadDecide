<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/masterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ReadDecide.YoneticiPanel._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Yönetici Paneli</h2>
    <label>Hoş geldin Admin</label>

    <div class="istatistikKutulari">

        <div class="istatistikKutu">
            <div class="istatistikIkon">📚</div>
            <div>
                <h2>
                    <asp:Label ID="lbl_toplamKitap" runat="server"></asp:Label>
                </h2>
                <p>Toplam Kitap</p>
            </div>
        </div>

        <div class="istatistikKutu">
            <div class="istatistikIkon">📂</div>
            <div>
                <h2>
                    <asp:Label ID="lbl_toplamKategori" runat="server"></asp:Label>
                </h2>
                <p>Toplam Kategori</p>
            </div>
        </div>

        <div class="istatistikKutu">
            <div class="istatistikIkon">👤</div>
            <div>
                <h2>
                    <asp:Label ID="lbl_toplamUye" runat="server"></asp:Label>
                </h2>
                <p>Toplam Üye</p>
            </div>
        </div>

        <div class="istatistikKutu">
            <div class="istatistikIkon">💬</div>
            <div>
                <h2>
                    <asp:Label ID="lbl_toplamYorum" runat="server"></asp:Label>
                </h2>
                <p>Toplam Yorum</p>
            </div>
        </div>

    </div>
    <div class="dashboardGrid">

        <div class="dashboardPanel">

            <h3>Son Eklenen Kitaplar</h3>

            <asp:ListView ID="lv_sonKitaplar" runat="server">

                <LayoutTemplate>
                    <table class="yorumTablo">
                        <tr>
                            <th>Kitap Adı</th>
                            <th>Yazar</th>
                            <th>Eklenme Tarihi</th>
                        </tr>

                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Title") %></td>
                        <td><%# Eval("Author") %></td>
                        <td><%# Eval("CreatedAt", "{0:dd.MM.yyyy}") %></td>
                    </tr>
                </ItemTemplate>

            </asp:ListView>

        </div>
        <div class="dashboardPanel">

            <h3>Son Üyeler</h3>

            <asp:ListView ID="lv_sonUyeler" runat="server">

                <LayoutTemplate>
                    <table class="yorumTablo">
                        <tr>
                            <th>Ad Soyad</th>
                            <th>E-posta</th>
                            <th>Kayıt Tarihi</th>
                        </tr>

                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("DisplayName") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("CreatedAt", "{0:dd.MM.yyyy}") %></td>
                    </tr>
                </ItemTemplate>

            </asp:ListView>

        </div>
    </div>

    <div class="sonYorumlarPanel">

        <h3>Son Yorumlar</h3>

        <asp:ListView ID="lv_sonYorumlar" runat="server">
            <LayoutTemplate>
                <table class="yorumTablo">
                    <tr>
                        <th>Kullanıcı</th>
                        <th>Kitap</th>
                        <th>Yorum</th>
                        <th>Tarih</th>
                        <th>İşlemler</th>
                    </tr>

                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("UserName") %></td>
                    <td><%# Eval("BookTitle") %></td>
                    <td class="yorumMetni">
                        <%# Eval("Text") %></td>
                    <td><%# Eval("CreatedAt", "{0:dd.MM.yyyy}") %></td>
                    <td>
                        <a href="YorumListele.aspx" class="tablebutton duzenle">Görüntüle</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

    </div>

</asp:Content>
