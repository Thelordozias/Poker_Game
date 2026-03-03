using System;
using System.Collections.Generic;

public class Deck
{
    private List<Card> cards;
    public int RemainingCards { get; private set; }

    public Deck()
    {
        cards = new List<Card>();
        InitializeDeck();
    }

    private void InitializeDeck()
    {
        cards.Clear();
        foreach (string suit in Card.Suits)
        {
            foreach (int value in Card.Values)
            {
                cards.Add(new Card(value, suit));
            }
        }
        RemainingCards = cards.Count;
    }

    public void Shuffle()
    {
        Random rng = new Random();
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card? Draw()
    {
        if (isEmpty()) return null;

        Card top = cards[0];
        cards.RemoveAt(0);
        RemainingCards = cards.Count;
        return top;
    }

    public bool isEmpty()
    {
        return cards.Count == 0;
    }
}