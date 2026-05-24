<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/masterPage.Master" AutoEventWireup="true" CodeBehind="UyeListele.aspx.cs" Inherits="ReadDecide.YoneticiPanel.UyeListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Üyeler</h3>
        </div>

        <div class="formTabloIcerik">

            <asp:ListView ID="lv_uyeler" runat="server">
                <LayoutTemplate>
                    <table class="tablo" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>Ad Soyad</th>
                            <th>E-posta</th>
                            <th>Kullanıcı Adı</th>
                            <th>Rol</th>
                            <th>Kayıt Tarihi</th>
                            <th>Aktif</th>
                            <th>İşlem</th>
                        </tr>

                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("DisplayName") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("UserName") %></td>
                        <td><%# Eval("RoleName") %></td>
                        <td><%# Eval("CreatedAt", "{0:dd.MM.yyyy HH:mm}") %></td>
                        <td><%# Eval("IsActive") %></td>
                        <td>
                            <asp:Button
                                ID="btn_durumDegistir"
                                runat="server"
                                Text="Durum Değiştir"
                                CssClass="button"
                                CommandArgument='<%# Eval("UserId") %>'
                                OnClick="btn_durumDegistir_Click" />
                        </td>
                    </tr>
                </ItemTemplate>

                <AlternatingItemTemplate>
                    <tr class="alt">
                        <td><%# Eval("DisplayName") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("UserName") %></td>
                        <td><%# Eval("RoleName") %></td>
                        <td><%# Eval("CreatedAt", "{0:dd.MM.yyyy HH:mm}") %></td>
                        <td><%# Eval("IsActive") %></td>
                        <td>
                            <asp:Button
                                ID="btn_durumDegistir"
                                runat="server"
                                Text="Durum Değiştir"
                                CssClass="button"
                                CommandArgument='<%# Eval("UserId") %>'
                                OnClick="btn_durumDegistir_Click" />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:ListView>

        </div>
    </div>
</asp:Content>
