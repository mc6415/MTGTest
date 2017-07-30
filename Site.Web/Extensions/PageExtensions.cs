namespace Site.Web.Extensions
{
    public static class PageExtensions
    {
        public static string GetCardImageUrl(int multiverseId)
        {
            return $"http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid={multiverseId}&type=card";
        }
    }
}