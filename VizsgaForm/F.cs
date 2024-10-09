using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizsgaForm
{
    public partial class F : Form
    {
        public F()
        {
            InitializeComponent();
            init();
            dataGridView1.DataSource = AutoList;
        }

        public class Auto
        {
            public string Marka { get; set; }
            public string Modell { get; set; }
            public string Rendszam { get; set; }
            public int Loero { get; set; }

            public Auto(string marka, string model, string rendszam, int loero) { Marka = marka; Modell = model; Rendszam = rendszam; Loero = loero; }
        }
        List<Auto> AutoList { get; set; } = new List<Auto>();

        public void init()
        {
            AutoList.Add(new Auto("Toyota", "Supra", "ABC123", 350));
            AutoList.Add(new Auto("Dacia", "Supra", "ABC1293", 350));
            AutoList.Add(new Auto("Opel", "Supra", "ABC1823", 350));
            AutoList.Add(new Auto("VW", "Supra", "ABC1623", 350));
        }









        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("nem adtál meg semmit");
                return; 
            }
            AutoList.Add(new Auto("VW", "Supra", textBox1.Text, 350));
            dataGridView1.DataSource = null;

            dataGridView1.DataSource=AutoList;
        }
    }
}
