using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Out.Write("Frist Start");
            Roll.start();
            IO.load();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Roll.gensList();
            String outs = Roll.alloutput();
            textBox1.Text = outs;
            Console.Out.Write(outs);
            IO.write(outs);
        }
    }
}
