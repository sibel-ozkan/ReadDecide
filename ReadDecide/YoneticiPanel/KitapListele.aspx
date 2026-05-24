<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/masterPage.Master" AutoEventWireup="true" CodeBehind="KitapListele.aspx.cs" Inherits="ReadDecide.YoneticiPanel.KitapListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Kitaplar</h3>
        </div>

        <div class="formTabloIcerik">

            <asp:ListView ID="lv_kitaplar" runat="server">
                <LayoutTemplate>
                    <table class="tablo" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>Kitap Adı</th>
                            <th>Yazar</th>
                            <th>Kategori</th>
                            <th>Eklenme Tarihi</th>
                            <th>Aktif</th>
                            <th>Seçenekler</th>
                        </tr>

                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Title") %></td>
                        <td><%# Eval("Author") %></td>
                        <td><%# Eval("CategoryName") %></td>
                        <td><%# Eval("CreatedAt", "{0:dd.MM.yyyy HH:mm}") %></td>
                        <td><%# Eval("IsActive") %></td>
                        <td>
                            <a href="#" class="tablebutton duzenle">Düzenle</a>
                            <a href="#" class="tablebutton sil">Sil</a>
                        </td>
                    </tr>
                </ItemTemplate>

                <AlternatingItemTemplate>
                    <tr class="alt">
                        <td><%# Eval("Title") %></td>
                        <td><%# Eval("Author") %></td>
                        <td><%# Eval("CategoryName") %></td>
                        <td><%# Eval("CreatedAt", "{0:dd.MM.yyyy HH:mm}") %></td>
                        <td><%# Eval("IsActive") %></td>
                        <td>
                            <a href="#" class="tablebutton duzenle">Düzenle</a>
                            <a href="#" class="tablebutton sil">Sil</a>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:ListView>

        </div>
    </div>
</asp:Content>
