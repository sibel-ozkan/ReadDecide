<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/masterPage.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="ReadDecide.YoneticiPanel.KategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Kategoriler</h3>
        </div>

        <div class="formTabloIcerik">

            <%-- ListView database’den gelen kategori verilerini tablo gibi göstermek için kullanılıyor. --%>
            <asp:ListView ID="lv_kategoriler" runat="server" OnItemCommand="lv_kategoriler_ItemCommand">

                <%-- LayoutTemplate tablonun genel iskeleti. başlık satırları burada yazıldı. --%>
                <LayoutTemplate>
                    <table class="tablo" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>Kategori Adı</th>
                            <th>Ekleme Tarihi</th>
                            <th>Aktif Kategori</th>
                            <th>Seçenekler</th>
                        </tr>

                        <%-- Veritabanından gelen satırlar bu alana yerleşiyor. --%>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>

                <%-- ItemTemplate normal satır görüntsü. --%>
                <ItemTemplate>
                    <tr>
                        <%-- Eval, veritabanından gelen ilgili alanı ekrana yazdırdık. --%>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("CreatedAt") %></td>
                        <td><%# Eval("IsActive") %></td>

                        <td>
                            <%-- LinkButton tıklanınca code-behind tarafında ItemCommand olayını çalıştırır. --%>
                            <%-- CommandName hangi işlemin yapılacağını belirtir. --%>
                            <%-- CommandArgument işlem yapılacak kategorinin ID bilgisini taşır. --%>
                            <asp:LinkButton ID="lbtn_durum"
                                runat="server"
                                CssClass="tablebutton durum"
                                CommandName="durum"
                                CommandArgument='<%# Eval("CategoryId") %>'>
                                Durum Değiştir
                            </asp:LinkButton>

                            <%-- Bu link kategori düzenleme sayfasına CategoryId bilgisini querystring ile gönderdik. --%>
                            <a href='KategoriDuzenle.aspx?kategoriid=<%# Eval("CategoryId") %>' class="tablebutton duzenle">Düzenle
                            </a>

                            <asp:LinkButton ID="lbtn_sil"
                                runat="server"
                                CssClass="tablebutton sil"
                                CommandName="sil"
                                CommandArgument='<%# Eval("CategoryId") %>'>
                                Sil
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>

                <%-- AlternatingItemTemplate, bir sonraki satırın farklı görünmesi için kullandı. --%>
                <AlternatingItemTemplate>
                    <tr class="alt">
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("CreatedAt", "{0:dd.MM.yyyy HH:mm}") %></td>
                        <td><%# Eval("IsActive") %></td>

                        <td>
                            <asp:LinkButton ID="lbtn_durum"
                                runat="server"
                                CssClass="tablebutton durum"
                                CommandName="durum"
                                CommandArgument='<%# Eval("CategoryId") %>'>
                                Durum Değiştir
                            </asp:LinkButton>

                            <a href='KategoriDuzenle.aspx?kategoriid=<%# Eval("CategoryId") %>' class="tablebutton duzenle">Düzenle
                            </a>

                            <asp:LinkButton ID="lbtn_sil"
                                runat="server"
                                CssClass="tablebutton sil"
                                CommandName="sil"
                                CommandArgument='<%# Eval("CategoryId") %>'>
                                Sil
                            </asp:LinkButton>
                        </td>
                    </tr>
                </AlternatingItemTemplate>

            </asp:ListView>

        </div>
    </div>

</asp:Content>
