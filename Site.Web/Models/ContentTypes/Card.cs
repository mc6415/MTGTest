using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Search;
using Newtonsoft.Json;

namespace Site.Web.Models.ContentTypes
{
    public class Card
    {
        [JsonProperty("name")]
        [IsSearchable]
        [IsSortable]
        public string Name { get; set; }

        [JsonProperty("manaCost")]
        [IsSortable]
        public string ManaCost { get; set; }

        [JsonProperty("cmc")]
        [IsFacetable]
        [IsSortable]
        [IsFilterable]
        public int CMC { get; set; }

        [JsonProperty("colors")]
        [IsFacetable]
        [IsFilterable]
        public string[] Colors { get; set; }

        [JsonProperty("type")]
        [IsSearchable]
        public string Type { get; set; }

        [JsonProperty("types")]
        [IsFacetable]
        [IsFilterable]
        public string[] Types { get; set; }

        [JsonProperty("subtypes")]
        [IsFacetable]
        [IsFilterable]
        public string[] SubTypes { get; set; }

        [JsonProperty("rarity")]
        [IsFacetable]
        [IsSortable]
        [IsFilterable]
        public string Rarity { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("flavor")]
        public string Flavor { get; set; }

        [JsonProperty("artist")]
        [IsFacetable]
        [IsFilterable]
        [IsSortable]
        public string Artist { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("power")]
        [IsFacetable]
        [IsFilterable]
        [IsSortable]
        public string Power { get; set; }

        [JsonProperty("toughness")]
        [IsFacetable]
        [IsFilterable]
        [IsSortable]
        public string Toughness { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }

        [JsonProperty("multiverseid")]
        public int MultiverseId { get; set; }

        [JsonProperty("id")]
        [Key]
        public string Id { get; set; }
    }
}