<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uyeOl.aspx.cs" Inherits="ReadDecide.uyeOl" MasterPageFile="~/site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="yorumYazPanel" style="max-width: 500px; margin: 60px auto; padding: 40px;">

        <div style="width: 420px; margin: auto;">

            <div class="formBaslik">
                <h3>Üye Ol</h3>
            </div>

            <div class="satir">
                <label>Ad Soyad</label>
                <asp:TextBox ID="tb_adsoyad" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>

            <div class="satir">
                <label>Kullanıcı Adı</label>
                <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>

            <div class="satir">
                <label>E-posta</label>
                <asp:TextBox ID="tb_mail" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>

            <div class="satir">
                <label>Şifre</label>
                <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu" TextMode="Password"></asp:TextBox>
            </div>

            <div class="satir">
                <asp:Button ID="btn_uyeOl" runat="server" Text="Üye Ol"  CssClass="button" OnClick="btn_uyeOl_Click1" />
            </div>

        </div>

    </div>

</asp:Content>
