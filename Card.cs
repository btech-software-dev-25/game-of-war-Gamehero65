using System.Reflection.Metadata;

namespace GameOfWar
{
    public class Card
    {

        // Create a string property Suit with a private setter
        internal string Suit = "";

        // Create an int property Rank with a private setter - values should range from 0 for a face value of 2 to 12 for an Ace
        private int Rank;

        // Create a public constructor that takes suit and rank as arguments and assigns them to Suit and Rank
        public Card(string suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }

        // Overload the > operator to compare two cards by rank
        public static bool operator >(Card PlayerCard, Card ComputerCard) => PlayerCard.Rank > ComputerCard.Rank;

        // Overload the < operator to compare two cards by rank
        public static bool operator <(Card PlayerCard, Card ComputerCard) => PlayerCard.Rank < ComputerCard.Rank;

        // Create a public string method RankString that returns a string representation of this card's rank, 2-10 and Jack, Queen, King, Ace
        public string RankString()
        {
            string RankString = "";
            switch (this.Rank)
            {
                case 12:
                    RankString = "Ace";
                    break;
                case 11:
                    RankString = "King";
                    break;
                case 10:
                    RankString = "Queen";
                    break;
                case 9:
                    RankString = "Jack";
                    break;
                default:
                    RankString = this.Rank.ToString();
                    break;
            }
            return RankString;
        }
    }
}