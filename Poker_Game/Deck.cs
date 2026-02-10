using System;
using System.Collections.Generic;

public class Deck
{
    private List<Card> cards;
    public int RemainingCards { get; private set; }

    public Deck()
    {
        InitializeDeck();
        Shuffle();
    }

    private void InitializeDeck()
    {
        cards = new List<Card>();
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        foreach (var suit in suits)
        {
            foreach (var value in values)
            {
                cards.Add(new Card(suit, value));
            }
        }
        RemainingCards = cards.Count;
    }

    public void Shuffle()
    {
        Random rand = new Random();
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            var temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }
}