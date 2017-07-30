using HtmlAgilityPack;
using KenticoCloud.Delivery;

namespace Site.Web.Models.ContentTypes
{
    public class FeaturedDeck
    {
        #region Constructors

        public FeaturedDeck(ContentItem x)
        {
            IsActive = true;
            MagicMadhouseUrl = x.Elements.magic_madhouse_url.value;
            MultiverseId = x.Elements.multiverse_id.value;
            Title = x.Elements.title.value;
            CardPrice = GetCardPrice(MagicMadhouseUrl);
        }

        #endregion



        #region Properties

        public string CardPrice { get; set; }

        public bool IsActive { get; set; }

        public string MagicMadhouseUrl { get; set; }

        public int MultiverseId { get; set; }

        public string Title { get; set; }

        #endregion



        #region Methods

        public string GetCardPrice(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            var prices = doc.DocumentNode.SelectNodes("//span[@class='GBP']");
            var cardPrice = prices[2].InnerText;
            return cardPrice;
        }

        #endregion
    }
}