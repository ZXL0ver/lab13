using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Observe
{
    interface IObserver
    {
        void Update(List<Item> items);
    }
    class Magnet
    {
        private List<Item> items;  
        private List<IObserver> observers;  
        public int radius;
        public int x, y;
        public Magnet(int radius)
        {
            this.items = new List<Item>();
            this.observers = new List<IObserver>();
            this.radius = radius;
            x=0; y=0;
        }
        public void goX(int q, RichTextBox w)
        {
            x += q;
            w.Text += this.x +" " +this.y + "\n";
        }
        public void goY(int q, RichTextBox w)
        {
            y += q;
            w.Text += this.x + " " + this.y + "\n";
        }
        public void AddItem(Item item, RichTextBox w)
        {
            this.items.Add(item);
           
        }
        public void Attach(IObserver observer)
        {
            this.observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            this.observers.Remove(observer);
        }
        public void NotifyObservers(RichTextBox w)
        {
            List<Item> ironItems = new List<Item>();
            foreach (Item item in this.items)
            {
                if (item.distanceToPlayer(this.x,this.y) <= this.radius)
                {
                    ironItems.Add(item);
                    w.Text += "somethtng get magnit \n";
                }
            }
            foreach (IObserver observer in this.observers)
            {
                observer.Update(ironItems);
            }
        }
    }
    class Item
    {
        public string name;  
        public int x, y;  
        public int distanceToPlayer(int playerx, int playery)
        {             
            int dx = this.x - playerx;
            int dy = this.y - playery;
            return (int) Math.Sqrt((dx * dx)+(dy * dy));
        }
    }
    class IronItemsObserver : IObserver
    {
        public void Update(List<Item> items)
        {
            Console.WriteLine("Iron items in range:");
            foreach (Item item in items)
            {
                Console.WriteLine("- " + item.name);
            }
        }
    }
}
