using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TarotCard.Models
{
    public class Card
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("name_short")]
        public string NameShort { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("value_int")]
        public int ValueInt { get; set; }

        [JsonPropertyName("suit")]
        public string Suit { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("meaning_up")]
        public string MeaningUp { get; set; }

        [JsonPropertyName("meaning_rev")]
        public string MeaningRev { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }
    }

    public class OrginTarotCard
    {
        [JsonPropertyName("nhits")]
        public int Nhits { get; set; }

        [JsonPropertyName("cards")]
        public List<Card> Cards { get; set; }
    }


}
