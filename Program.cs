using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        GameController game = new GameController();
        game.StartGame();

        while (!game.Win && !game.Lose)
        {
            Console.WriteLine("The cards on the table are:");
            Console.WriteLine(game.Table.ToString());

            Console.WriteLine("Enter 2 indices :");
            Console.Write("> ");
            string input = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(input)) continue;

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<int> indices = new List<int>();
            foreach (string p in parts)
            {
                if (int.TryParse(p, out int idx))
                    indices.Add(idx);
            }

            List<Card> selected = new List<Card>();
            foreach (int idx in indices)
            {
                List<Card> tableCards = game.Table.GetCards();
                if (idx < 0 || idx >= tableCards.Count)
                {
                    selected.Clear();
                    break;
                }
                selected.Add(tableCards[idx]);
            }

            if (selected.Count == 0)
            {
                Console.WriteLine("Invalid indices.");
                continue;
            }

            game.SubmitSelection(selected);
        }

        Console.WriteLine("Game Over.");
    }
}