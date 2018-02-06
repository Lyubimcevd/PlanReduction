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
            label17.Text = "Заказов в плане: " + zakazs.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Zakaz zak in zakazs)
                if (zak.NumberOfZakaz == textBox1.Text)
                {
                    textBox2.Text = zak.NumberOfCherchInstr;
                    textBox3.Text = zak.NumberOfCherchDet;
                    textBox4.Text = zak.NaimInstr;
                    textBox5.Text = zak.KolVZayavke.ToString();
                    textBox6.Text = zak.Prior.ToString();
                    textBox7.Text = zak.RashetEdin.ToString();
                    textBox8.Text = zak.PredpDateVipuska.ToString();
                    textBox9.Text = zak.RealDateVipuska.ToString();
                    dataGridView1.DataSource = zak.Sostav;
                    dataGridView2.DataSource = zak.Primen;
                    dataGridView3.DataSource = zak.Material;
                    dataGridView4.DataSource = zak.Tehnol;
                    dataGridView5.DataSource = zak.TrudRasc;
                    dataGridView6.DataSource = zak.SmenOtch;
                    dataGridView7.DataSource = zak.NormaChas;
                } 
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(null, null);
        }
    }
}
