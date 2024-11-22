using HtmlAgilityPack;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace WebApplication7
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string keywords = Request.QueryString["keywords"];

                if (!string.IsNullOrEmpty(keywords))
                {
                    List<Tuple<string, string, string>> publicationInfos = GetPublicationInfos(keywords);
                    Session["PublicationInfos"] = publicationInfos; // Makale bilgilerini sakla
                    Response.Redirect("PublicationList.aspx"); // Yeni sayfaya yönlendir
                }
            }
        }

        private List<Tuple<string, string, string>> GetPublicationInfos(string keywords)
        {
            List<Tuple<string, string, string>> publicationInfos = new List<Tuple<string, string, string>>();

            try
            {
                // Google Akademik URL'sini oluştur
                string url = $"https://scholar.google.com/scholar?q={WebUtility.UrlEncode(keywords)}";

                // HTML belgesini indir
                WebClient webClient = new WebClient();
                string html = webClient.DownloadString(url);

                // HTML belgesini işle
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                // İlk 3 sayfa için döngü yap
                for (int page = 0; page < 3; page++)
                {
                    // PDF olanları seç
                    var nodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='gs_ri']");

                    if (nodes != null)
                    {
                        foreach (var node in nodes)
                        {
                            string ad = node.SelectSingleNode(".//h3[@class='gs_rt']//a")?.InnerText;
                            string link = node.SelectSingleNode(".//h3[@class='gs_rt']//a")?.GetAttributeValue("href", "");
                            string bilgiler = node.SelectSingleNode(".//div[@class='gs_a']")?.InnerText;

                            ad = System.Web.HttpUtility.HtmlDecode(ad);
                            link = System.Web.HttpUtility.HtmlDecode(link);
                            bilgiler = System.Web.HttpUtility.HtmlDecode(bilgiler);

                            publicationInfos.Add(new Tuple<string, string, string>(ad, link, bilgiler));
                        }
                    }
                    // Sonraki sayfaya geç
                    var nextPageNode = htmlDocument.DocumentNode.SelectSingleNode("//table[@id='gs_n']//a[@aria-label='Next']");
                    if (nextPageNode != null)
                    {
                        string nextPageUrl = nextPageNode.GetAttributeValue("href", "");
                        string nextPageHtml = webClient.DownloadString($"https://scholar.google.com{nextPageUrl}");
                        htmlDocument.LoadHtml(nextPageHtml);
                    }
                    else
                    {
                        break; // Son sayfaya ulaştık, döngüden çık
                    }
                }
            }
            catch (Exception ex)
            {
                publicationInfos.Add(new Tuple<string, string, string>($"Hata: {ex.Message}", "", ""));
            }

            return publicationInfos;
        }

        

    }
}



