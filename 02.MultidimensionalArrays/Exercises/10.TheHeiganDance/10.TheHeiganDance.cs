using System;

namespace _10.TheHeiganDance
{
    public class Player
    {
        public int[] Position { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
        public bool IsHitByCloud { get; set; }
    }
    public class Startup
    {

        public static void Main()
        {
            var player = new Player()
            {
                Position = new int[2] { 7, 7 },
                Health = 18500,
                Damage = double.Parse(Console.ReadLine()),
                IsHitByCloud = false
            };

            double heiganHealth = 3000000;
            string spell = "";
            while (true)
            {
                if (player.IsHitByCloud)
                {
                    player.Health -= 3500;
                    player.IsHitByCloud = false;
                }

                heiganHealth -= player.Damage;

                if (GameIsOver(player, heiganHealth, spell))
                {
                    break;
                }

                string[] bossAttack = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                spell = bossAttack[0];
                int hitRow = int.Parse(bossAttack[1]);
                int hitCol = int.Parse(bossAttack[2]);

                if (IsCellReached(player.Position[0], player.Position[1], hitRow, hitCol) &&
                    IsPlayerDamaged(player, hitRow, hitCol))
                {
                    if (spell == "Cloud")
                    {
                        player.Health -= 3500;
                        player.IsHitByCloud = true;
                    }
                    else if (spell == "Eruption")
                    {
                        player.Health -= 6000;
                    }
                }

                if (GameIsOver(player, heiganHealth, spell))
                {
                    break;
                }
            }
        }

        private static bool GameIsOver(Player player, double bossHeiganBlood, string spell)
        {
            if (player.Health <= 0 || bossHeiganBlood <= 0)
            {
                if (spell == "Cloud")
                {
                    spell = "Plague Cloud";
                }

                if (bossHeiganBlood > 0)
                {
                    Console.WriteLine($"Heigan: {bossHeiganBlood:F2}");
                }
                else
                {
                    Console.WriteLine($"Heigan: Defeated!");
                }

                if (player.Health > 0)
                {
                    Console.WriteLine($"Player: {player.Health}");
                }
                else
                {
                    Console.WriteLine($"Player: Killed by {spell}");
                }

                Console.WriteLine($"Final position: {player.Position[0]}, {player.Position[1]}");

                return true;
            }

            return false;
        }

        private static bool IsPlayerDamaged(Player player, int hitRow, int hitCol)
        {
            if (player.Position[0] > 0 &&
                !IsCellReached(player.Position[0] - 1, player.Position[1], hitRow, hitCol))
            {
                player.Position[0]--;
                return false;
            }

            if (player.Position[1] + 1 < 15 &&
                !IsCellReached(player.Position[0], player.Position[1] + 1, hitRow, hitCol))
            {
                player.Position[1]++;
                return false;
            }

            if (player.Position[0] + 1 < 15 &&
                !IsCellReached(player.Position[0] + 1, player.Position[1], hitRow, hitCol))
            {
                player.Position[0]++;
                return false;
            }

            if (player.Position[1] > 0 &&
                !IsCellReached(player.Position[0], player.Position[1] - 1, hitRow, hitCol)) 
            {
                player.Position[1]--;
                return false;
            }

            return true;
        }

        private static bool IsCellReached(int cellRow, int cellCol, int hitRow, int hitCol)
        {
            return (cellRow >= hitRow - 1) && (cellRow <= hitRow + 1) && (cellCol >= hitCol - 1) && (cellCol <= hitCol + 1);
        }
    }
}
