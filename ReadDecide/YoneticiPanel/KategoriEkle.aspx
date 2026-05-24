<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/masterPage.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="ReadDecide.YoneticiPanel.KategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Kategori Ekle</h3>
        </div>

        <div class="formIcerik">

            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <asp:Label ID="lbl_basarili" runat="server" Text="Kategori başarıyla eklendi."></asp:Label>
            </asp:Panel>

            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>

            <div class="satir">
                <label>Kategori Adı</label>
                <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>

            <div class="satir">
                <asp:CheckBox ID="cb_aktif" runat="server" Text="Aktif Kategori" Checked="true" />
            </div>

            <div class="satir">
                <asp:Button ID="btn_ekle" runat="server" Text="Kategori Ekle" CssClass="button" OnClick="btn_ekle_Click" />
            </div>

        </div>
    </div>

</asp:Content>