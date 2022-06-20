using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem2lab3
{
     class Door
    {
        private bool closed = true;
        public int doors { get; set; }

        public Door(int doors)
        {
            this.doors = doors;
        }
        public void GetDoorCount()
        {
            if (this.doors != 0)
            {
                Console.WriteLine($"There are {this.doors} doors in this house");
            }
            else
            {
                Console.WriteLine("No doors in the house");
            }
        }
        public void CloseDoor()
        {
            if (!closed)
            {
                Console.WriteLine("Door already is locked");
            }
            else
            {
                Console.WriteLine(" Door is locked");
                this.closed = false;
            }
        }
    }

     class Window : Door
    {
        public int windows { get; set; }
        public Window(int windows, int doors) : base(doors)
        {
            this.windows = windows;
        }
        public void GetWindowCount()
        {
            if (this.windows != 0)
            {
                Console.WriteLine($"There are {this.windows} windows in the house");
            }
            else
            {
                Console.WriteLine("No windows in the house");
            }
        }
    }
    class House : Window
    {
        public int house_number { get; set; }
        public House(int number, int doors, int windows) : base(doors, windows)
        {
            house_number = number;
        }
        public override string ToString()
        {
            return $"{house_number}:{windows}:{doors}";
        }
        
        public override int GetHashCode()
        {
            int hashcode = house_number.GetHashCode();
            hashcode += doors.GetHashCode();
            hashcode += windows.GetHashCode();
            Console.WriteLine($"HashCode = {hashcode}");
            return hashcode;

        }

        public override bool Equals(object obj)
        {
            if (obj == null)return false;
            House h = obj as House;
            if (h as House == null) return false;
        
        if(h.house_number== this.house_number && h.doors== this.doors && h.windows==this.windows)
            {
                Console.WriteLine("Object are equal");
                return true;
            } else
            {
                Console.WriteLine("Object are not equal");
                return false;
            }
        }  
    }
}
