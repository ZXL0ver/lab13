using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Observe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IronItemsObserver observer = new IronItemsObserver();
            player.Attach(observer);
            Item item1 = new Item { name = "Iron scrap", x = 5, y = 5 };
            player.AddItem(item1,richTextBox2);
            Item item2 = new Item { name = "Gold egg", x = 10, y = 10 };
            player.AddItem(item2, richTextBox2);
            Item item3 = new Item { name = "Iron bar", x = 50, y = 40 };
            player.AddItem(item3, richTextBox2);
        }
        Magnet player = new Magnet(10);
        private void button1_Click(object sender, EventArgs e)
        {           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.goX(5,richTextBox1);
            player.NotifyObservers(richTextBox2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            player.goX(-5, richTextBox1);
            player.NotifyObservers(richTextBox2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            player.goY(5, richTextBox1);
            player.NotifyObservers(richTextBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.goY(-5, richTextBox1);
            player.NotifyObservers(richTextBox2);
        }
    }
}
