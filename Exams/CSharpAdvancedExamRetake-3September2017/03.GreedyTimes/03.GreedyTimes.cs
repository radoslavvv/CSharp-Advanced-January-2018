using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class Program
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, long> gold = new Dictionary<string, long>();
            Dictionary<string, long> gems = new Dictionary<string, long>();
            Dictionary<string, long> cash = new Dictionary<string, long>();

            long goldTotalQuantity = 0;
            long gemsTotalQuantity = 0;
            long cashTotalQuantity = 0;

            for (int i = 0; i < input.Length; i += 2)
            {
                string itemName = input[i];
                long itemQuantity = long.Parse(input[i + 1]);

                string itemType = "";
                if (itemName.Length == 3)
                {
                    itemType = "cash";
                }
                else if (itemName.ToLower().EndsWith("gem"))
                {
                    itemType = "gem";
                }
                else if (itemName.ToLower() == "gold")
                {
                    itemType = "gold";
                }
                else
                {
                    continue;
                }

                if (itemType == "gold")
                {
                    if (!(goldTotalQuantity + itemQuantity >= gemsTotalQuantity) || goldTotalQuantity + itemQuantity + gemsTotalQuantity + cashTotalQuantity > bagCapacity)
                    {
                        continue;
                    }
                    else
                    {
                        goldTotalQuantity = AddItem(gold, goldTotalQuantity, itemName, itemQuantity);
                    }
                }
                else if (itemType == "gem")
                {
                    if (!(gemsTotalQuantity + itemQuantity >= cashTotalQuantity && gemsTotalQuantity + itemQuantity <= goldTotalQuantity) || goldTotalQuantity + itemQuantity + gemsTotalQuantity + cashTotalQuantity > bagCapacity)
                    {
                        continue;
                    }
                    else
                    {
                        gemsTotalQuantity = AddItem(gems, gemsTotalQuantity, itemName, itemQuantity);
                    }
                }
                else if (itemType == "cash")
                {
                    if (cashTotalQuantity + itemQuantity > gemsTotalQuantity || goldTotalQuantity + itemQuantity + gemsTotalQuantity + cashTotalQuantity > bagCapacity)
                    {
                        continue;
                    }
                    else
                    {
                        cashTotalQuantity = AddItem(cash, cashTotalQuantity, itemName, itemQuantity);
                    }
                }
            }
            Dictionary<string, long> allItems = new Dictionary<string, long>()
            {
                {"Gold", goldTotalQuantity },
                {"Gem", gemsTotalQuantity },
                {"Cash", cashTotalQuantity }
            };

            foreach (var itemType in allItems.OrderByDescending(i=>i.Value))
            {
               
                if (itemType.Key == "Gold")
                {
                    if (gold.Count > 0)
                    {
                        Console.WriteLine($"<{itemType.Key}> ${itemType.Value}");
                        Print(gold);
                    }
                }
                else if (itemType.Key == "Gem")
                {
                    if (gems.Count > 0)
                    {
                        Console.WriteLine($"<{itemType.Key}> ${itemType.Value}");
                        Print(gems);
                    }
                }
                else if (itemType.Key == "Cash")
                {
                    if (cash.Count > 0)
                    {
                        Console.WriteLine($"<{itemType.Key}> ${itemType.Value}");
                        Print(cash);
                    }
                }
            }
        }

        private static long AddItem(Dictionary<string, long> bag, long itemTotalQuantity, string itemName, long itemQuantity)
        {
            if (!bag.ContainsKey(itemName))
            {
                bag.Add(itemName, 0);
            }
            bag[itemName] += itemQuantity;

            itemTotalQuantity += itemQuantity;
            return itemTotalQuantity;
        }

        private static void Print(Dictionary<string, long> gold)
        {
            foreach (var item in gold.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
            {
                Console.WriteLine($"##{item.Key} - {item.Value}");
            }
        }
    }
}
