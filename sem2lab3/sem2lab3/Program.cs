using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem2lab3
{
    class Program
    {
      
        static void SortBySoldierCount(ref Platoon []pl, ref int count)
        {
            var sorted = pl.OrderBy(p => p.sold_count);
            foreach (var p in sorted)
            {
                Console.WriteLine($"Platoon type: {p.platoontype}\n Soldiers: {p.sold_count}\n");
            }
                
        }

        static void GetGunInfo(ref Platoon pl, string gun_type)
        {
            Console.WriteLine($"Soldiers who use {gun_type} in {pl.platoontype} platoon");
            for (int i = 0; i < pl.sold_count; i++)
            {
                if (pl.sol[i].soldier_weapon == gun_type)
                {
                    Console.WriteLine(pl.sol[i].soldiername);
                }
            }

        }
        static void SortBySoldierProfession(ref Platoon pl)
        {
            var SortedSoldier = pl.sol.OrderBy(p => p.soldier_profession);

            foreach (var p in SortedSoldier)
            {
                Console.WriteLine($"Soldier name: {p.soldiername}; Profession {p.soldier_profession}");
            }
        }
        static void Main(string[] args)
        {
           // task 1
            House house1 = new House(45, 6, 5);
            house1.CloseDoor();
            house1.GetDoorCount();

            House house2 = new House(45, 6, 5);

            house1.GetHashCode();
            house2.GetHashCode();

            house2.Equals(house1);
            // Console.WriteLine(lol.ToString());

            // task2
            int p_count = 2;
            Platoon[] vzvod = new Platoon[p_count];
            string path = "lab3_1.json";
            string path2 = "lab3_2.json";

            for (int i = 0; i < p_count; i++)
            {
                vzvod[i] = new Platoon();
            }       

            vzvod[0].SetPlatoon(path,"tank");
            vzvod[1].SetPlatoon(path2, "intelligence");
           
            for (int i = 0; i < p_count; i++)
            {
                vzvod[1].GetPlatoon();
            }
          
            for (int i = 0; i < p_count; i++)
            {
                GetGunInfo(ref vzvod[i], "AK47");        // gun sort
            }
            Console.WriteLine(" ");
            Console.WriteLine("Sort by soldier count");
            SortBySoldierCount(ref vzvod, ref p_count);     // count sort
          
            Console.WriteLine(" ");
            Console.WriteLine("Sort by soldier profession");    // profession sort
            SortBySoldierProfession(ref vzvod[1]);
        }
    }
}
