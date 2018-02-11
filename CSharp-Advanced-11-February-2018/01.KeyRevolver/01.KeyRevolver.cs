using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int bulletPrice = int.Parse(Console.ReadLine());
        int gunBarrelSize = int.Parse(Console.ReadLine());

        List<int> bullets = Console.ReadLine().Split().Select(int.Parse).ToList();

        List<int> locks = Console.ReadLine().Split().Select(int.Parse).ToList();

        int intelligenceValue = int.Parse(Console.ReadLine());

        int totalBulletsCount = 0;
        int reload = gunBarrelSize;
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            int currentBullet = bullets[i];
            int currentLock = locks[0];
            totalBulletsCount++;

            if (currentBullet <= currentLock)
            {
                Console.WriteLine($"Bang!");
                locks.RemoveAt(0);
            }
            else
            {
                Console.WriteLine($"Ping!");
            }
            bullets.RemoveAt(i);
            reload--;
            if (reload == 0 && bullets.Count > 0)
            {
                Console.WriteLine($"Reloading!");
                reload = gunBarrelSize;
            }

            if (bullets.Count == 0 || locks.Count == 0)
            {
                break;
            }
        }
        if (bullets.Count == 0 && locks.Count == 0)
        {
            Console.WriteLine(
                $"{bullets.Count} bullets left. Earned ${intelligenceValue - (totalBulletsCount * bulletPrice)}");
        }
        else if (locks.Count == 0 && bullets.Count > 0)
        {
            Console.WriteLine(
                $"{bullets.Count} bullets left. Earned ${intelligenceValue - (totalBulletsCount * bulletPrice)}");
        }
        else if (bullets.Count == 0 && locks.Count > 0)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}

