using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VeriErisimKatmani;

namespace VeriErisimKatmani
{
    public class VeriTabaniİslemleri
    {
        SqlConnection baglanti;
        SqlCommand komut;

        public VeriTabaniİslemleri()
        {
            baglanti = new SqlConnection(baglantiYolu.BaglantiYolu);
            komut = baglanti.CreateCommand();
        }

        #region Yinetici Metotları

        public Admin AdminGiris(string Email, string Password)
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Users WHERE Email=@e AND Password=@p AND RoleId=1 AND IsActive=1";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@e", Email);
                komut.Parameters.AddWithValue("@p", Password);

                baglanti.Open();

                int sayi = Convert.ToInt32(komut.ExecuteScalar());

                if (sayi > 0)
                {
                    komut.CommandText = "SELECT U.UserId, U.DisplayName, U.Email, U.Password, U.UserName, U.RoleId, U.CreatedAt, U.IsActive FROM Users AS U WHERE U.Email=@e AND U.Password=@p AND U.RoleId=1 AND U.IsActive=1";
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@e", Email);
                    komut.Parameters.AddWithValue("@p", Password);

                    SqlDataReader okuyucu = komut.ExecuteReader();

                    Admin a = new Admin();

                    while (okuyucu.Read())
                    {
                        a.UserId = okuyucu.GetInt32(0);
                        a.DisplayName = okuyucu.GetString(1);
                        a.Email = okuyucu.GetString(2);
                        a.Password = okuyucu.GetString(3);
                        a.UserName = okuyucu.GetString(4);
                        a.RoleId = okuyucu.GetInt32(5);
                        a.CreatedAt = okuyucu.GetDateTime(6);
                        a.IsActive = okuyucu.GetBoolean(7);
                    }

                    return a;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool KategoriGuncelle(Category cat)
        {
            try
            {
                komut.CommandText = "UPDATE Categories SET Name=@name, IsActive=@active WHERE CategoryId=@id";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@name", cat.Name);
                komut.Parameters.AddWithValue("@active", cat.IsActive);
                komut.Parameters.AddWithValue("@id", cat.CategoryId);

                baglanti.Open();

                int sonuc = komut.ExecuteNonQuery();

                return sonuc > 0; // eğer etkilenen satır sayısı büyükse true döndür burası. -yardım aldık-
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public Category KategoriGetir(int id)
        {
            try
            {
                komut.CommandText = "SELECT CategoryId, Name, Slug, CreatedAt, IsActive FROM Categories WHERE CategoryId=@id";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);

                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();

                Category cat = new Category();

                while (okuyucu.Read())
                {
                    cat.CategoryId = okuyucu.GetInt32(0);
                    cat.Name = okuyucu.GetString(1);
                    cat.Slug = okuyucu.GetString(2);
                    cat.CreatedAt = okuyucu.GetDateTime(3);
                    cat.IsActive = okuyucu.GetBoolean(4);
                }

                return cat;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Category> KategoriListele()
        {
            List<Category> kategoriler = new List<Category>();

            try
            {
                komut.CommandText = "SELECT CategoryId, Name, CreatedAt, IsActive FROM Categories ORDER BY CategoryId";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Category cat = new Category();
                    cat.CategoryId = okuyucu.GetInt32(0);
                    cat.Name = okuyucu.GetString(1);
                    cat.CreatedAt = okuyucu.GetDateTime(2);
                    cat.IsActive = okuyucu.GetBoolean(3);
                    kategoriler.Add(cat);
                }

                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool KategoriEkle(Category cat)
        {
            try
            {
                komut.CommandText = "INSERT INTO Categories (Name, Slug, CreatedAt, IsActive) VALUES (@name, @slug, @createdAt, @active)";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@name", cat.Name);
                komut.Parameters.AddWithValue("@slug", cat.Slug);
                komut.Parameters.AddWithValue("@createdAt", DateTime.Now);
                komut.Parameters.AddWithValue("@active", cat.IsActive);

                baglanti.Open();

                int sonuc = komut.ExecuteNonQuery();

                return sonuc > 0;  // eğer etkilenen satır sayısı büyükse true döndür burası. -yardım aldık-

            }
            catch
            { return false; }
            finally
            { baglanti.Close(); }
        }

        public bool KategoriDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "UPDATE Categories SET IsActive = CASE WHEN IsActive = 1 THEN 0 ELSE 1 END WHERE CategoryId=@id";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);

                baglanti.Open();

                int sonuc = komut.ExecuteNonQuery();

                return sonuc > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool KategoriSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Categories WHERE CategoryId=@id";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);

                baglanti.Open();

                int sonuc = komut.ExecuteNonQuery();

                return sonuc > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool KitapEkle(Book kitap)
        {
            try
            {
                komut.CommandText = @"INSERT INTO Books (CategoryId, Title, Author, Slug, CoverImageUrl, Description, CreatedAt, IsActive) VALUES
                                     (@categoryId, @title, @author, @slug, @coverImageUrl, @description, @createdAt, @isActive)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@categoryId", kitap.CategoryId);
                komut.Parameters.AddWithValue("@title", kitap.Title);
                komut.Parameters.AddWithValue("@author", kitap.Author);
                komut.Parameters.AddWithValue("@slug", kitap.Slug);
                komut.Parameters.AddWithValue("@coverImageUrl", kitap.CoverImageUrl);
                komut.Parameters.AddWithValue("@description", kitap.Description);
                komut.Parameters.AddWithValue("@createdAt", DateTime.Now);
                komut.Parameters.AddWithValue("@isActive", kitap.IsActive);

                baglanti.Open();

                int sonuc = komut.ExecuteNonQuery();

                return sonuc > 0;

            }
            catch { return false; }
            finally { baglanti.Close(); }
        }

        public int KategoriIdGetir(string kategoriAdi)
        {
            try
            {
                komut.CommandText = "SELECT CategoryId FROM Categories WHERE LOWER(Name) = LOWER(@name)"; // trim baş son boşluk temizleme lower yazı küçük büyük fark kaldırdı.

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@name", kategoriAdi.Trim());

                baglanti.Open();

                object sonuc = komut.ExecuteScalar();

                if (sonuc != null)
                {
                    return Convert.ToInt32(sonuc);
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Book> KitapListele()
        {
            List<Book> kitaplar = new List<Book>();

            try
            {
                komut.CommandText = @"SELECT Books.BookId, Books.Title, Books.Author, Books.CreatedAt, Books.IsActive, Categories.Name AS CategoryName FROM Books INNER JOIN Categories ON Books.CategoryId = Categories.CategoryId";

                komut.Parameters.Clear();

                baglanti.Open();

                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    Book kitap = new Book();

                    kitap.BookId = Convert.ToInt32(reader["BookId"]);
                    kitap.Title = reader["Title"].ToString();
                    kitap.Author = reader["Author"].ToString();
                    kitap.CategoryName = reader["CategoryName"].ToString();
                    kitap.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                    kitap.IsActive = Convert.ToBoolean(reader["IsActive"]);

                    kitaplar.Add(kitap);
                }
            }
            catch
            {

            }
            finally
            {
                baglanti.Close();
            }

            return kitaplar;

        }

        public List<User> UyeListele()
        {
            List<User> uyeler = new List<User>();

            try
            {
                komut.CommandText = @"SELECT Users.UserId, Users.DisplayName, Users.Email, Users.UserName, Users.RoleId, Roles.RoleName, Users.CreatedAt, Users.IsActive FROM Users INNER JOIN Roles ON Users.RoleId = Roles.RoleId";

                komut.Parameters.Clear();

                baglanti.Open();

                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    User uye = new User();

                    uye.UserId = Convert.ToInt32(reader["UserId"]);
                    uye.DisplayName = reader["DisplayName"].ToString();
                    uye.Email = reader["Email"].ToString();
                    uye.UserName = reader["UserName"].ToString();
                    uye.RoleId = Convert.ToInt32(reader["RoleId"]);
                    uye.RoleName = reader["RoleName"].ToString();
                    uye.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                    uye.IsActive = Convert.ToBoolean(reader["IsActive"]);

                    uyeler.Add(uye);
                }
            }
            finally
            {
                baglanti.Close();
            }

            return uyeler;
        }

        public List<Comments> YorumListele()
        {
            List<Comments> yorumlar = new List<Comments>();

            try
            {
                komut.CommandText = @"SELECT  Comments.CommentId, Comments.Text, Comments.CreatedAt, Comments.IsApproved, Comments.IsActive, Books.Title AS BookTitle, Users.UserName FROM Comments INNER JOIN Books ON Comments.BookId = Books.BookId INNER JOIN Users ON Comments.UserId = Users.UserId";

                komut.Parameters.Clear();

                baglanti.Open();

                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    Comments yorum = new Comments();

                    yorum.CommentId = Convert.ToInt32(reader["CommentId"]);
                    yorum.Text = reader["Text"].ToString();
                    yorum.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                    yorum.IsApproved = Convert.ToBoolean(reader["IsApproved"]);
                    yorum.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    yorum.BookTitle = reader["BookTitle"].ToString();
                    yorum.UserName = reader["UserName"].ToString();

                    yorumlar.Add(yorum);
                }
            }
            finally
            {
                baglanti.Close();
            }

            return yorumlar;
        }

        public int ToplamKategoriSayisi()
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Categories";
                komut.Parameters.Clear();

                baglanti.Open();

                int sayi = Convert.ToInt32(komut.ExecuteScalar());

                return sayi;
            }
            catch
            {
                return 0;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public int ToplamKitapSayisi()
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Books";
                komut.Parameters.Clear();

                baglanti.Open();

                int sayi = Convert.ToInt32(komut.ExecuteScalar());

                return sayi;
            }
            catch
            {
                return 0;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public int ToplamUyeSayisi()
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Users";
                komut.Parameters.Clear();

                baglanti.Open();

                int sayi = Convert.ToInt32(komut.ExecuteScalar());

                return sayi;
            }
            catch
            {
                return 0;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public int ToplamYorumSayisi()
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Comments";
                komut.Parameters.Clear();

                baglanti.Open();

                int sayi = Convert.ToInt32(komut.ExecuteScalar());

                return sayi;
            }
            catch
            {
                return 0;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Comments> SonYorumlariGetir()
        {
            List<Comments> yorumlar = new List<Comments>();

            try
            {
                komut.CommandText = @"SELECT TOP 5
                              Comments.CommentId,
                              Comments.Text,
                              Comments.CreatedAt,
                              Comments.IsApproved,
                              Comments.IsActive,
                              Books.Title AS BookTitle,
                              Users.UserName
                              FROM Comments
                              INNER JOIN Books
                              ON Comments.BookId = Books.BookId
                              INNER JOIN Users
                              ON Comments.UserId = Users.UserId
                              ORDER BY Comments.CreatedAt DESC";

                komut.Parameters.Clear();

                baglanti.Open();

                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    Comments yorum = new Comments();

                    yorum.CommentId = Convert.ToInt32(reader["CommentId"]);
                    yorum.Text = reader["Text"].ToString();
                    yorum.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                    yorum.IsApproved = Convert.ToBoolean(reader["IsApproved"]);
                    yorum.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    yorum.BookTitle = reader["BookTitle"].ToString();
                    yorum.UserName = reader["UserName"].ToString();

                    yorumlar.Add(yorum);
                }
            }
            catch
            {

            }
            finally
            {
                baglanti.Close();
            }

            return yorumlar;
        }

        public List<Book> SonKitaplariGetir()
        {
            List<Book> kitaplar = new List<Book>();

            try
            {
                komut.CommandText = @"SELECT TOP 5 *
                              FROM Books
                              ORDER BY CreatedAt DESC";

                komut.Parameters.Clear();

                baglanti.Open();

                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    Book kitap = new Book();

                    kitap.BookId = Convert.ToInt32(reader["BookId"]);
                    kitap.Title = reader["Title"].ToString();
                    kitap.Author = reader["Author"].ToString();
                    kitap.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);

                    kitaplar.Add(kitap);
                }
            }
            catch
            {

            }
            finally
            {
                baglanti.Close();
            }

            return kitaplar;
        }

        public List<User> SonUyeleriGetir()
        {
            List<User> uyeler = new List<User>();

            try
            {
                komut.CommandText = @"SELECT TOP 5 *
                              FROM Users
                              ORDER BY CreatedAt DESC";

                komut.Parameters.Clear();

                baglanti.Open();

                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    User uye = new User();

                    uye.UserId = Convert.ToInt32(reader["UserId"]);
                    uye.DisplayName = reader["DisplayName"].ToString();
                    uye.Email = reader["Email"].ToString();
                    uye.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);

                    uyeler.Add(uye);
                }
            }
            catch
            {

            }
            finally
            {
                baglanti.Close();
            }

            return uyeler;
        }

        public bool UyeDurumDegistir(int userId)
        {
            try
            {
                komut.CommandText = @"UPDATE Users
                              SET IsActive = CASE 
                                  WHEN IsActive = 1 THEN 0
                                  ELSE 1
                              END
                              WHERE UserId = @userId";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@userId", userId);

                baglanti.Open();

                int sonuc = komut.ExecuteNonQuery();

                return sonuc > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool YorumDurumDegistir(int commentId)
        {
            try
            {
                komut.CommandText = @"UPDATE Comments
                              SET IsActive = CASE 
                                  WHEN IsActive = 1 THEN 0
                                  ELSE 1
                              END
                              WHERE CommentId = @commentId";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@commentId", commentId);

                baglanti.Open();

                int sonuc = komut.ExecuteNonQuery();

                return sonuc > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion

        #region Kullanıcı  Metottlari

        public List<Book> AnaSayfaKitapListele()
        {
            List<Book> kitaplar = new List<Book>();

            try
            {
                komut.CommandText = @"SELECT 
                              Books.BookId,
                              Books.Title,
                              Books.Author,
                              Books.Description,
                              Books.CoverImageUrl,
                              Books.CreatedAt,
                              Books.IsActive,
                              Categories.Name AS CategoryName
                              FROM Books
                              INNER JOIN Categories
                              ON Books.CategoryId = Categories.CategoryId
                              WHERE Books.IsActive = 1
                              ORDER BY Books.CreatedAt DESC";

                komut.Parameters.Clear();

                baglanti.Open();

                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    Book kitap = new Book();

                    kitap.BookId = Convert.ToInt32(reader["BookId"]);
                    kitap.Title = reader["Title"].ToString();
                    kitap.Author = reader["Author"].ToString();
                    kitap.Description = reader["Description"].ToString();
                    kitap.CoverImageUrl = "Images/images.png";
                    kitap.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                    kitap.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    kitap.CategoryName = reader["CategoryName"].ToString();

                    kitaplar.Add(kitap);
                }
            }
            catch
            {

            }
            finally
            {
                baglanti.Close();
            }

            return kitaplar;
        } // aktif kitapları kategori adıyla birlikte getir. ana sayfa için hazırladık

        public Book KitapDetayGetir(int bookId)
        {
            try
            {
                komut.CommandText = @"SELECT 
                              Books.BookId,
                              Books.Title,
                              Books.Author,
                              Books.Description,
                              Books.CoverImageUrl,
                              Categories.Name AS CategoryName
                              FROM Books
                              INNER JOIN Categories
                              ON Books.CategoryId = Categories.CategoryId
                              WHERE Books.BookId = @bookId";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@bookId", bookId);

                baglanti.Open();

                SqlDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {
                    Book kitap = new Book();

                    kitap.BookId = Convert.ToInt32(reader["BookId"]);
                    kitap.Title = reader["Title"].ToString();
                    kitap.Author = reader["Author"].ToString();
                    kitap.Description = reader["Description"].ToString();
                    kitap.CoverImageUrl = reader["CoverImageUrl"].ToString();
                    kitap.CategoryName = reader["CategoryName"].ToString();

                    return kitap;
                }

                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Comments> KitabaAitYorumlariGetir(int bookId) // database den seçili kitaba ait yorumlar için.
        {
            List<Comments> yorumlar = new List<Comments>();

            try
            {
                komut.CommandText = @"SELECT 
                              Comments.CommentId,
                              Comments.Text,
                              Comments.CreatedAt,
                              Comments.IsApproved,
                              Comments.IsActive,
                              Users.UserName
                              FROM Comments
                              INNER JOIN Users
                              ON Comments.UserId = Users.UserId
                              WHERE Comments.BookId = @bookId
                              AND Comments.IsActive = 1
                              AND Comments.IsApproved = 1
                              ORDER BY Comments.CreatedAt DESC";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@bookId", bookId);

                baglanti.Open();

                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    Comments yorum = new Comments();

                    yorum.CommentId = Convert.ToInt32(reader["CommentId"]);
                    yorum.Text = reader["Text"].ToString();
                    yorum.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                    yorum.IsApproved = Convert.ToBoolean(reader["IsApproved"]);
                    yorum.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    yorum.UserName = reader["UserName"].ToString();

                    yorumlar.Add(yorum);
                }
            }
            catch
            {

            }
            finally
            {
                baglanti.Close();
            }

            return yorumlar;
        }

        public bool YorumEkle(Comments yorum)
        {
            try
            {
                komut.CommandText = @"INSERT INTO Comments  (BookId, UserId, Text, CreatedAt, IsApproved, IsActive)  VALUES (@bookId, @userId, @text, @createdAt, @isApproved, @isActive)";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@bookId", yorum.BookId);
                komut.Parameters.AddWithValue("@userId", yorum.UserId);
                komut.Parameters.AddWithValue("@text", yorum.Text);
                komut.Parameters.AddWithValue("@createdAt", DateTime.Now);
                komut.Parameters.AddWithValue("@isApproved", true);
                komut.Parameters.AddWithValue("@isActive", true);

                baglanti.Open();

                int sonuc = komut.ExecuteNonQuery();

                return sonuc > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public User KullaniciGiris(string email, string password)
        {
            try
            {
                komut.CommandText = @"SELECT 
                              UserId,
                              DisplayName,
                              Email,
                              UserName,
                              RoleId,
                              CreatedAt,
                              IsActive
                              FROM Users
                              WHERE Email=@mail AND Password=@sifre AND RoleId=2 AND IsActive=1";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@mail", email);
                komut.Parameters.AddWithValue("@sifre", password);

                baglanti.Open();

                SqlDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {
                    User kullanici = new User();

                    kullanici.UserId = Convert.ToInt32(reader["UserId"]);
                    kullanici.DisplayName = reader["DisplayName"].ToString();
                    kullanici.Email = reader["Email"].ToString();
                    kullanici.UserName = reader["UserName"].ToString();
                    kullanici.RoleId = Convert.ToInt32(reader["RoleId"]);
                    kullanici.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                    kullanici.IsActive = Convert.ToBoolean(reader["IsActive"]);

                    return kullanici;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool UyeEkle(User uye)
        {
            try
            {
                komut.CommandText = @"INSERT INTO Users
                              (DisplayName, Email, Password, UserName, RoleId, CreatedAt, IsActive)
                              VALUES
                              (@displayName, @email, @password, @userName, @roleId, @createdAt, @isActive)";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@displayName", uye.DisplayName);
                komut.Parameters.AddWithValue("@email", uye.Email);
                komut.Parameters.AddWithValue("@password", uye.Password);
                komut.Parameters.AddWithValue("@userName", uye.UserName);
                komut.Parameters.AddWithValue("@roleId", 2);
                komut.Parameters.AddWithValue("@createdAt", DateTime.Now);
                komut.Parameters.AddWithValue("@isActive", false);

                baglanti.Open();

                int sonuc = komut.ExecuteNonQuery();

                return sonuc > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Book> KategoriyeGoreKitapGetir(string kategoriAdi)
        {
            List<Book> kitaplar = new List<Book>();

            try
            {
                komut.CommandText = @"SELECT
                              Books.BookId,
                              Books.Title,
                              Books.Author,
                              Books.Description,
                              Books.CoverImageUrl,
                              Books.CreatedAt,
                              Books.IsActive,
                              Categories.Name AS CategoryName
                              FROM Books
                              INNER JOIN Categories
                              ON Books.CategoryId = Categories.CategoryId
                              WHERE Categories.Name = @kategoriAdi
                              AND Books.IsActive = 1";

                komut.Parameters.Clear();

                komut.Parameters.AddWithValue("@kategoriAdi", kategoriAdi);

                baglanti.Open();

                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    Book kitap = new Book();

                    kitap.BookId = Convert.ToInt32(reader["BookId"]);
                    kitap.Title = reader["Title"].ToString();
                    kitap.Author = reader["Author"].ToString();
                    kitap.Description = reader["Description"].ToString();

                    kitap.CoverImageUrl = "Images/images.png";

                    kitap.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                    kitap.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    kitap.CategoryName = reader["CategoryName"].ToString();

                    kitaplar.Add(kitap);
                }
            }
            catch
            {

            }
            finally
            {
                baglanti.Close();
            }

            return kitaplar;
        }
        #endregion
    }
}

