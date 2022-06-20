using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace sem2lab3
{
    class Soldier
    {

        public string soldiername { get; set; }
        public string soldier_profession { get; set; }
        public string soldier_weapon { get; set; }

        public Soldier()
        {
            this.soldiername = "unknown";
            this.soldier_profession = "unknown";
            this.soldier_weapon = "unknown";

        }
        public Soldier(string name, string prf, string weapon)
        {
            this.soldiername = name;
            this.soldier_profession = prf;
            this.soldier_weapon = weapon;

        }
        public void SetSoldier(ref string name, ref string prof, ref string weapon)
        {
            this.soldiername = name;
            this.soldier_profession = prof;
            this.soldier_weapon = weapon;
        }
        public void GetSoldierInfo()
        {
            Console.WriteLine($"Soldier name {this.soldiername}");
            Console.WriteLine($"Profession {this.soldier_profession}");
            Console.WriteLine($"Weapon  {this.soldier_weapon}\n");
        }
    }


    class Platoon
    {
        public string platoontype { get; set; }
        public int sold_count { get; set; }
        public Soldier[] sol;

        public void SetPlatoon(string path,string type)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader file = new StreamReader(fs);

            this.platoontype = type;
            this.sold_count = Convert.ToInt32(file.ReadLine());

            Soldier[] soldier = new Soldier[this.sold_count];
            for (int i=0; i<this.sold_count; i++)
            {
                soldier[i] = new Soldier();
                string line = file.ReadLine();
                soldier[i] = JsonConvert.DeserializeObject<Soldier>(line);
             
            }
            sol = soldier;
        }

        public void GetPlatoon()
        {
            Console.WriteLine($"Platoon type {this.platoontype}");
            for (int i = 0; i < this.sold_count; i++)
            {
                Console.WriteLine($"Soldier number {i + 1}");
                sol[i].GetSoldierInfo();
            }
        }
      
    }
}
