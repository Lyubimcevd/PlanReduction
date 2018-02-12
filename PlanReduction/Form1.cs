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
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zakaz zak = zakazs.FirstOrDefault(x => x.NumberOfZakaz == textBox1.Text);
            if (zak != null)
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
            else MessageBox.Show("Такого заказа нет");
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Портфель")
            {
                listBox1.Items.Clear();
                zakazs = FortranReader.GetFortranReader.ReadPortfel();
                label17.Text = "Заказов в портфеле: " + zakazs.Count;
                foreach (Zakaz zk in zakazs) listBox1.Items.Add(zk.NumberOfZakaz);
            }
            else
            {
                listBox1.Items.Clear();
                zakazs = FortranReader.GetFortranReader.ReadPlan();
                label17.Text = "Заказов в плане: " + zakazs.Count;
                foreach (Zakaz zk in zakazs) listBox1.Items.Add(zk.NumberOfZakaz);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null&&e.Button == MouseButtons.Left)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
                button1_Click(null, null);
            }                    
        }
    }
}
