// GameController.cs
using System.Collections.Generic;

public class GameController
{
    public bool WinLoss { get; private set; }
    public Deck Deck { get; private set; }
    public List<Card> Table { get; private set; }

    public GameController()
    {
        WinLoss = false;
        Deck = new Deck();
        Table = new List<Card>();
    }

    public void SubmitSelection(List<Card> selectedCards)
    {
        
    }

    public bool ValidateSelection(List<Card> selectedCards)
    {
        
        return false; 
    }

    public void CheckEndState()
    {
        
    }
}