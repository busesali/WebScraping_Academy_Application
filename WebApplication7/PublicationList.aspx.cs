using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication7
{
    public partial class PublicationList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Tuple<string, string, string>> publicationInfos = (List<Tuple<string, string, string>>)Session["PublicationInfos"];

                if (publicationInfos != null)
                {
                    PublicationRepeater.DataSource = publicationInfos;
                    PublicationRepeater.DataBind();

                    // MongoDB'ye yayın bilgilerini kaydet
                    SavePublicationsToMongoDB(publicationInfos);
                }
                else
                {
                    Response.Redirect("WebForm1.aspx"); // Ana sayfaya yönlendir
                }
            }

            // Bind DropDownList
            if (ddlSortBy.Items.Count == 0)
            {
                ddlSortBy.Items.Add(new ListItem("Sort by closest date", "closest"));
                ddlSortBy.Items.Add(new ListItem("Sort by furthest date", "furthest"));
            }
        }

        private void SavePublicationsToMongoDB(List<Tuple<string, string, string>> publicationInfos)
        {
            // MongoDB bağlantı bilgileri
            string connectionString = "mongodb://localhost:27017";
            string databaseName = "akademik_yayinlar";
            string collectionName = "yayinlar";

            // MongoDB istemcisini oluştur
            var client = new MongoDB.Driver.MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<MongoDB.Bson.BsonDocument>(collectionName);

            // Her bir yayın için Bson belge oluştur ve MongoDB'ye ekle
            foreach (var info in publicationInfos)
            {
                string yazar = GetAuthorFromInfo(info.Item3); // Yazarı al
                int date = GetDateFromInfo(info.Item3);
                string yayintur = GetInfoBetweenDashAndComma(info.Item3);
                var publicationDocument = new MongoDB.Bson.BsonDocument
                {
                    { "Makale Adi", info.Item1 },
                    { "Url", info.Item2 },
                    { "Yazar", yazar }, // Yazarı MongoDB'ye ekle
                    { "Tarih", date }, // Yazarı MongoDB'ye ekle
                    {"Yayin Turu", yayintur }
                };

                collection.InsertOne(publicationDocument);
            }
        }

        private string GetAuthorFromInfo(string info)
        {
            int index = info.IndexOf("-");
            if (index >= 0)
            {
                return info.Substring(0, index).Trim();
            }
            else
            {
                return info.Trim(); // "-" karakteri yoksa sadece info'yu döndür
            }
        }

        private int GetDateFromInfo(string info)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\b\d{4}\b");
            System.Text.RegularExpressions.Match match = regex.Match(info);

            if (match.Success)
            {
                if (int.TryParse(match.Value, out int year))
                {
                    return year;
                }
            }

            return -1; // 4 haneli sayı bulunamazsa -1 döndür
        }

        private string GetInfoBetweenDashAndComma(string info)
        {
            int dashIndex = info.IndexOf("-");
            int commaIndex = info.IndexOf(",", dashIndex); // İlk "-" sonrası olan "," işaretini bul
            if (dashIndex >= 0 && commaIndex >= 0)
            {
                return info.Substring(dashIndex + 1, commaIndex - dashIndex - 1).Trim();
            }
            else
            {
                return info;
            }
        }


        protected void ddlSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Tuple<string, string, string>> publicationInfos = (List<Tuple<string, string, string>>)Session["PublicationInfos"];

            if (publicationInfos != null)
            {
                string sortBy = ddlSortBy.SelectedValue;

                if (sortBy == "closest")
                {
                    publicationInfos = publicationInfos.OrderByDescending(p => GetDateFromInfo(p.Item3)).ToList();
                }
                else if (sortBy == "furthest")
                {
                    publicationInfos = publicationInfos.OrderBy(p => GetDateFromInfo(p.Item3)).ToList();
                }

                PublicationRepeater.DataSource = publicationInfos;
                PublicationRepeater.DataBind();
            }
        }
    }
}
