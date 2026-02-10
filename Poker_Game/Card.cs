using System;
using System.Collections.Generic;

public class Card
{
    private int value;
    private string suit;

    public static string[] Suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    public static int[] Values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }; // 11=Jack, 12=Queen, 13=King, 14=Ace

    public Card(int value, string suit)
    {
        this.value = value;
        this.suit = suit;
    }

    public int GetValue()
    {
        return value;
    }
    public string GetSuit()
    {
        return suit;
    }
    public override string ToString()
    {
        return $"{suit} of {value}";
    }
}