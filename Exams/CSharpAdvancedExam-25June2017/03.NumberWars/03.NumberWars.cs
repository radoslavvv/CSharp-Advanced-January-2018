using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Wars
{
    //const int maxCounter = 
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> firstPlayerCards = new Queue<string>(Console.ReadLine().Split());
            Queue<string> secondPlayerCards = new Queue<string>(Console.ReadLine().Split());

            int turnsCount = 0;
            bool gameIsOver = false;

            while (turnsCount < 1_000_000 && firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
            {
                turnsCount++;
                string firstCard = firstPlayerCards.Dequeue();
                string secondCard = secondPlayerCards.Dequeue();

                if (GetInt(firstCard) > GetInt(secondCard))
                {
                    firstPlayerCards.Enqueue(firstCard);
                    firstPlayerCards.Enqueue(secondCard);
                }
                else if (GetInt(secondCard) > GetInt(firstCard))
                {
                    secondPlayerCards.Enqueue(secondCard);
                    secondPlayerCards.Enqueue(firstCard);
                }
                else
                {
                    List<string> cards = new List<string> { firstCard, secondCard };

                    while (!gameIsOver)
                    {
                        if (firstPlayerCards.Count >= 3 && secondPlayerCards.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;
                            for (int i = 0; i < 3; i++)
                            {
                                string firstPlayerCard = firstPlayerCards.Dequeue();
                                string secondPlayerCard = secondPlayerCards.Dequeue();

                                firstSum += GetChar(firstPlayerCard);
                                secondSum += GetChar(secondPlayerCard);
                                
                                cards.Add(firstPlayerCard);
                                cards.Add(secondPlayerCard);


                            }

                            if (firstSum > secondSum)
                            {
                                AddCardsToWinner(cards, firstPlayerCards);
                                break;
                            }
                            else if (secondSum > firstSum)
                            {
                                AddCardsToWinner(cards, secondPlayerCards);
                                break;
                            }
                        }
                        else
                        {
                            gameIsOver = true;
                        }
                    }
                }

            }
            string result = "";
            if (firstPlayerCards.Count == secondPlayerCards.Count )
            {
                result = "Draw";
            }else if (firstPlayerCards.Count > secondPlayerCards.Count)
            {
                result = "First player wins";
            }
            else
            {
                result = "Second player wins";
            }

            Console.WriteLine($"{result} after {turnsCount} turns");
        }

        private static void AddCardsToWinner(List<string> cards, Queue<string> playerCards)
        {
            foreach (var card in cards.OrderByDescending(GetInt).ThenByDescending(GetChar))
            {
                playerCards.Enqueue(card);
            }
        }
        private static int GetInt(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        private static char GetChar(string card)
        {
            return card[card.Length - 1];
        }
    }
}
