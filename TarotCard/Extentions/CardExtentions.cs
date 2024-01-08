using System.Collections.Generic;
using System.Windows.Documents;
using TarotCard.Models;

namespace TarotCard.Extentions;

public static class CardExtentions
{
    public static List<ImageTarotCard> FromatImage(this OrginTarotCard orgin)
    {
        List<ImageTarotCard> cards = new();
        foreach (var item in orgin.Cards)
        {
            ImageTarotCard card = new ImageTarotCard();
            card.Card = item;
            card.ImageUrl = $"https://sacred-texts.com/tarot/pkt/img/{item.NameShort}.jpg";
            cards.Add(card);
        }
        return cards;
    }
}
