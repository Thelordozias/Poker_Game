Poker_Game (Elevens)

Deck.cs

Deck initialization with 52 cards and shuffle.
Added Draw() method and updated RemainingCards.
Added HasCards() to check whether the deck is empty.

GameController.cs

Automatic dealing of 9 cards at game start.
Validation of selections (sum equals 11 or JQK combination).
Removal of validated cards and replacement from the deck.
Win/loss checking 