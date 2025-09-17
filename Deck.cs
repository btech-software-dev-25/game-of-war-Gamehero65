using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;

namespace GameOfWar
{
    public class Deck
    {
        public static string[] RankNames =
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10",
            "Jack", "Queen", "King", "Ace"
        };

        public static string[] Suits =
        {
            "Hearts", "Diamonds", "Clubs", "Spades"
        };


        // Create a public int property Count that returns the Count value from the private collection _cards
        public int Count
        {
            get { return _deck.Count; }
        }

        // Create a private field _cards that is a List<Card>
        private List<Card> _cards = new List<Card>();

        /* used for shuffling process */
        private List<Card> _deck = new List<Card>();

        // Create a public constructor that takes two parameter: a List<card> called cards and a boolean value called isEmptyDeck
        // If cards is not null and has elements in it, assign it to _cards and be done
        // If cards is null or empty:
        //     _cards should be initialized as an empty List<Card>
        //     InitializeDeck() should be called if and only if isEmptyDeck is false
        public Deck(List<Card> cards, bool isEmptyDeck)
        {
            if (cards.Count != 0)
            {
                _cards.AddRange(cards);
            }
            else if (!isEmptyDeck)
            {
                InitializeDeck();
            }
        }

        // Create a private void method called InitializeDeck() which does the following:
        // Use RankNames and Suits in nested loops to generate all 52 combinations of rank and suit and add them to _cards
        private void InitializeDeck()
        {
            for (int rank = 0; rank < RankNames.Length; rank++)
            {
                foreach (string suit in Suits)
                {
                    _cards.Add(new Card (suit, rank));
                }
            }
        }

        // Create a public void method called Shuffle() which shuffles (rearranges) the cards in _deck
        public void Shuffle()
        {
            Random random = new Random();
            
            for (int i = 51; i >= 0; i--)
            {
                int randomCard = random.Next(_cards.Count);
                _deck.Add(_cards[randomCard]);
                _cards.RemoveAt(randomCard);
            }
        }

        // Create a public method CardAtIndex which takes an int parameter for the index of a card and
        // returns the card at the index specified, or throws IndexOutOfRangeException if index is too large or too small
        public Card CardAtIndex(int i)
        {
            return _deck[i];
        }

        // Create a public method PullCardAtIndex which does exactly the same thing as CardAtIndex
        // with the additional feature that it _removes_ the card from the deck
        public Card PullCardAtIndex(int option)
        {
            Card tempCard = _deck[option];
            _deck.RemoveAt(option);
            return tempCard;
        }

        // Create a public method PullAllCards that returns a list of all of the cards in the deck
        // and removes them all from the deck, leaving it empty
        public List<Card> PullAllCards()
        {
            List<Card> tempDeck = new List<Card>(_deck);
            _deck.Clear();
            return tempDeck;
        }

        // Create a public method PushCard that accepts a Card as a parameter and adds it to _deck
        public void PushCard(Card card)
        {
            _deck.Add(card);
        }

        // Create a public method PushCards that accepts a List<Card> as a parameter and adds the list to _cards
        // Be sure to use AddRange and not Add
        public void PushCards(List<Card> card)
        {
            _deck.AddRange(card);
        }

        // Create a public method Deal that accepts an integer representing the number of cards to deal
        // and then removes that many cards from the deck, returning them as a List<Card>
        // Be sure to check the size of _deck against the number of cards requested so you don't go out
        // of bounds
        public List<Card> Deal(int dealCards)
        {
            List<Card> cards = new List<Card>();

            for (int i = 0; i < dealCards; i++)
            {
                cards.Add(_deck[0]);
                _deck.RemoveAt(0);
            }
            return cards;
        }
    }
}