using System.Collections.Generic;
using System.Linq;

public class MoveValidator
{
    
    public bool IsValidSelection(List<Card> selectedCards)
    {
        if (selectedCards == null) return false;

        if (selectedCards.Count == 2)
        {
            return selectedCards[0].GetValue() + selectedCards[1].GetValue() == 11;
        }

        if (selectedCards.Count == 3)
        {
            List<int> vals = selectedCards.Select(c => c.GetValue()).ToList();
            return vals.Contains(11) && vals.Contains(12) && vals.Contains(13);
        }

        return false;
    }

    public bool HasLegalMoves(List<Card> tableCards)
    {
        if (tableCards == null) return false;

    
        for (int i = 0; i < tableCards.Count; i++)
        {
            for (int j = i + 1; j < tableCards.Count; j++)
            {
                if (tableCards[i].GetValue() + tableCards[j].GetValue() == 11)
                    return true;
            }
        }


        bool hasJ = tableCards.Any(c => c.GetValue() == 11);
        bool hasQ = tableCards.Any(c => c.GetValue() == 12);
        bool hasK = tableCards.Any(c => c.GetValue() == 13);

        return hasJ && hasQ && hasK;
    }
}