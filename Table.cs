using System;
using System.Collections.Generic;

public class Table
{
    private List<Card> cardsOnTable;

    public Table()
    {
        cardsOnTable = new List<Card>();
    }

    public void Add(Card card)
    {
        if (card != null)
            cardsOnTable.Add(card);
    }

    public void remove(Card card)
    {
        cardsOnTable.Remove(card);
    }

    public void replace(Card oldCard, Card newCard)
    {
        int index = cardsOnTable.IndexOf(oldCard);
        if (index != -1)
        {
            cardsOnTable[index] = newCard;
        }
    }

    public List<Card> GetCards()
    {
        return cardsOnTable;
    }

    public override string ToString()
    {
        if (cardsOnTable.Count == 0) return "(empty table)";

        const int cols = 5;
        const int innerWidth = 10;
        string top    = "┌" + new string('─', innerWidth) + "┐";
        string bottom = "└" + new string('─', innerWidth) + "┘";
        string result = "";

        for (int rowStart = 0; rowStart < cardsOnTable.Count; rowStart += cols)
        {
            int rowEnd = Math.Min(rowStart + cols, cardsOnTable.Count);

        
            string[][] lines = new string[rowEnd - rowStart][];
            for (int i = rowStart; i < rowEnd; i++)
            {
                string[] parts = cardsOnTable[i].ToString().Split(" of ");
                string name = parts[0];
                string suit = parts[1];
                lines[i - rowStart] = new string[]
                {
                    top,
                    "│" + $"[{i}]".PadRight(innerWidth) + "│",
                    "│" + name.PadRight(innerWidth) + "│",
                    "│" + suit.PadRight(innerWidth) + "│",
                    bottom
                };
            }

        
            for (int line = 0; line < 5; line++)
            {
                for (int c = 0; c < lines.Length; c++)
                {
                    result += lines[c][line];
                    if (c < lines.Length - 1) result += " ";
                }
                result += "\n";
            }
            result += "\n";
        }
        return result;
    }
}