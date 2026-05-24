<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReadDecide.Default" MasterPageFile="~/site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="heroBaslik">
        <h1>Kitap seçmeden önce yorumları incele</h1>
    </div>

   <div class="kategoriFiltre">

    <a href="Default.aspx">Tüm Kitaplar</a>
    <a href="Default.aspx?kategori=Roman">Roman</a>
    <a href="Default.aspx?kategori=Psikoloji">Psikoloji</a>
    <a href="Default.aspx?kategori=Kisisel Gelisim">Kisisel Gelisim</a>
    <a href="Default.aspx?kategori=Bilim Kurgu">Bilim Kurgu</a>
    <a href="Default.aspx?kategori=Fantastik">Fantastik</a>
    <a href="Default.aspx?kategori=Polisiye">Polisiye</a>
    <a href="Default.aspx?kategori=Klasikler">Klasikler</a>
    <a href="Default.aspx?kategori=Korku">Korku</a>

</div>
    <div class="kitaplarAlan">

        <asp:ListView ID="lv_kitaplar" runat="server">
            <ItemTemplate>

                <div class="kitapKart">
                    <img src='<%# Eval("CoverImageUrl") %>' />

                    <h3><%# Eval("Title") %></h3>
                    <p><%# Eval("Author") %></p>
                    <p><%# Eval("CategoryName") %></p>
                    <p><%# Eval("Description") %></p>

                    <a href='KitapDetay.aspx?bookid=<%# Eval("BookId") %>'>Detay
                    </a>
                </div>

            </ItemTemplate>
        </asp:ListView>

    </div>

</asp:Content>
