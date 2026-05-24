<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GirisYap.aspx.cs" Inherits="ReadDecide.GirisYap" MasterPageFile="~/site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="yorumYazPanel" style="max-width:500px; margin:60px auto; padding:40px;">

        <div style="width:420px; margin:auto;">

            <div class="formBaslik">
                <h3>Giriş Yap</h3>
            </div>

            <div class="satir">
                <label>E-posta</label>

                <asp:TextBox 
                    ID="tb_mail" 
                    runat="server"
                    CssClass="metinKutu">
                </asp:TextBox>
            </div>

            <div class="satir">
                <label>Şifre</label>

                <asp:TextBox 
                    ID="tb_sifre" 
                    runat="server"
                    TextMode="Password"
                    CssClass="metinKutu">
                </asp:TextBox>
            </div>

            <div class="satir">

                <asp:Button 
                    ID="btn_giris" 
                    runat="server"
                    Text="Giriş Yap"
                    CssClass="button"
                    OnClick="btn_giris_Click1" />

            </div>

            <asp:Panel ID="pnl_mesaj" runat="server" Visible="false">

                <div class="basarisizMesaj">

                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>

                </div>

            </asp:Panel>

        </div>

    </div>

</asp:Content>