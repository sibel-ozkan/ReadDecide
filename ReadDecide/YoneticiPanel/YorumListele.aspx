<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/masterPage.Master" AutoEventWireup="true" CodeBehind="YorumListele.aspx.cs" Inherits="ReadDecide.YoneticiPanel.YorumListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Yorumlar</h3>
        </div>

        <div class="formTabloIcerik">

            <asp:ListView ID="lv_yorumlar" runat="server">
                <LayoutTemplate>
                    <table class="tablo" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>Kullanıcı</th>
                            <th>Kitap</th>
                            <th>Yorum</th>
                            <th>Tarih</th>
                            <th>Onay</th>
                            <th>Aktif</th>
                            <th>İşlem</th>
                        </tr>

                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("UserName") %></td>
                        <td><%# Eval("BookTitle") %></td>
                        <td><%# Eval("Text") %></td>
                        <td><%# Eval("CreatedAt", "{0:dd.MM.yyyy HH:mm}") %></td>
                        <td><%# Eval("IsApproved") %></td>
                        <td><%# Eval("IsActive") %></td>
                        <td>
                            <asp:Button
                                ID="btn_yorumDurumDegistir"
                                runat="server"
                                Text="Durum Değiştir"
                                CssClass="button"
                                CommandArgument='<%# Eval("CommentId") %>'
                                OnClick="btn_yorumDurumDegistir_Click" />
                        </td>
                    </tr>
                </ItemTemplate>

                <AlternatingItemTemplate>
                    <tr class="alt">
                        <td><%# Eval("UserName") %></td>
                        <td><%# Eval("BookTitle") %></td>
                        <td><%# Eval("Text") %></td>
                        <td><%# Eval("CreatedAt", "{0:dd.MM.yyyy HH:mm}") %></td>
                        <td><%# Eval("IsApproved") %></td>
                        <td><%# Eval("IsActive") %></td>
                        <td>
                            <asp:Button
                                ID="btn_yorumDurumDegistir"
                                runat="server"
                                Text="Durum Değiştir"
                                CssClass="button"
                                CommandArgument='<%# Eval("CommentId") %>'
                                OnClick="btn_yorumDurumDegistir_Click" />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:ListView>

        </div>
    </div>
</asp:Content>
