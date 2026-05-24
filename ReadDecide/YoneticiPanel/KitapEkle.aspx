<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/masterPage.Master" AutoEventWireup="true" CodeBehind="KitapEkle.aspx.cs" Inherits="ReadDecide.YoneticiPanel.KitapEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Kitap Ekle</h3>
        </div>

        <div class="formIcerik">

            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <asp:Label ID="lbl_basarili" runat="server" Text="Kitap başarıyla eklendi."></asp:Label>
            </asp:Panel>

            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>

            <div class="satir">
                <label>Kategori Adı</label>
                <asp:TextBox ID="tb_kategoriId" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>

            <div class="satir">
                <label>Kitap Adı</label>
                <asp:TextBox ID="tb_baslik" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>

            <div class="satir">
                <label>Yazar</label>
                <asp:TextBox ID="tb_yazar" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>

            <div class="satir">
                <label>Kapak Görseli</label>
                <asp:TextBox ID="tb_kapak" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>

            <div class="satir">
                <label>Açıklama</label>
                <asp:TextBox ID="tb_aciklama" runat="server" CssClass="metinKutu buyukAciklama " TextMode="MultiLine" Rows="8"></asp:TextBox>
            </div>

            <div class="satir">
                <asp:CheckBox ID="cb_aktif" runat="server" Text="Aktif Kitap" Checked="true" />
            </div>

            <div class="satir">
                <asp:Button ID="btn_ekle" runat="server" Text="Kitap Ekle" CssClass="button" OnClick="btn_ekle_Click" />
            </div>
        </div>
    </div>
</asp:Content>
