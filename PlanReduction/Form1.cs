using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanReduction
{
    public partial class Form1 : Form
    {
        List<Zakaz> zakazs;

        public Form1()
        {
            InitializeComponent();
            zakazs = FortranReader.GetFortranReader.ReadPlan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Zakaz zak in zakazs)
                if (zak.NumberOfZakaz == textBox1.Text)
                {
                    dataGridView1.DataSource = zak.Material;
                } 
        }
    }
}
