using System;
using System.Collections.Generic;

public class GameController
{
    public bool Win { get; private set; }
    public bool Lose { get; private set; }

    public Deck Deck { get; private set; }
    public Table Table { get; private set; }

    private MoveValidator validator;

    public GameController()
    {
        Deck = new Deck();
        Table = new Table();
        validator = new MoveValidator();
        Win = false;
        Lose = false;
    }

    public void StartGame()
    {
        Deck.Shuffle();

        
        while (!Deck.isEmpty() && Table.GetCards().Count < 9)
        {
            Card? card = Deck.Draw();
            if (card != null)
            {
                Table.Add(card);
            }
        }

        CheckEndState();
    }

    public void SubmitSelection(List<Card> selectedCards)
    {
        if (!ValidateSelection(selectedCards))
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

    
        foreach (Card c in selectedCards)
        {
            Table.remove(c);
        }

    
        while (!Deck.isEmpty() && Table.GetCards().Count < 9)
        {
            Card? card = Deck.Draw();
            if (card != null)
            {
                Table.Add(card);
            }
        }

        CheckEndState();
    }

    public bool ValidateSelection(List<Card> selectedCards)
    {
        return validator.IsValidSelection(selectedCards);
    }

    public void CheckEndState()
    {
    
        if (Deck.isEmpty() && Table.GetCards().Count == 0)
        {
            Win = true;
            Lose = false;
            Console.WriteLine("You win!");
            return;
        }


        if (!validator.HasLegalMoves(Table.GetCards()))
        {
            Lose = true;
            Win = false;
            Console.WriteLine("No more legal moves. You lose.");
        }
    }
}