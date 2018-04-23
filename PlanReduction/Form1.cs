using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

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
            if (zak!=null)            
            {
                textBox2.DataBindings.Clear();
                textBox2.DataBindings.Add("Text", zak, "NomForm");
                textBox3.DataBindings.Clear();
                textBox3.DataBindings.Add("Text", zak, "CherchInstr");
                textBox4.DataBindings.Clear();
                textBox4.DataBindings.Add("Text", zak, "CherchDet");
                textBox5.DataBindings.Clear();
                textBox5.DataBindings.Add("Text", zak, "Naim");
                textBox6.DataBindings.Clear();
                textBox6.DataBindings.Add("Text", zak, "NomIzd");
                textBox7.DataBindings.Clear();
                textBox7.DataBindings.Add("Text", zak, "CehZak");
                textBox8.DataBindings.Clear();
                textBox8.DataBindings.Add("Text", zak, "CehIzgot");
                textBox9.DataBindings.Clear();
                textBox9.DataBindings.Add("Text", zak, "KolVZayavke");
                textBox10.DataBindings.Clear();
                textBox10.DataBindings.Add("Text", zak, "Prior");
                textBox11.DataBindings.Clear();
                textBox11.DataBindings.Add("Text", zak, "NormTrud");
                textBox12.DataBindings.Clear();
                textBox12.DataBindings.Add("Text", zak, "LD");
                textBox13.DataBindings.Clear();
                textBox13.DataBindings.Add("Text", zak, "RashetEdin");
                textBox14.DataBindings.Clear();
                textBox14.DataBindings.Add("Text", zak, "OtnosSrokVipusk");
                textBox15.DataBindings.Clear();
                textBox15.DataBindings.Add("Text", zak, "DateInZayavke");
                textBox16.DataBindings.Clear();
                textBox16.DataBindings.Add("Text", zak, "MS");
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
                label2.Text = "Заказов в портфеле: " + (zakazs.Count-1);
                label3.Text = "";
                foreach (Zakaz zk in zakazs) listBox1.Items.Add(zk.NumberOfZakaz);
            }
            else
            {
                listBox1.Items.Clear();
                zakazs = FortranReader.GetFortranReader.ReadPlan();
                label2.Text = "Заказов в плане: " + zakazs.Count;
                label3.Text = FortranReader.GetFortranReader.NN + " - " + FortranReader.GetFortranReader.NK;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Портфель") FortranReader.GetFortranReader.SavePortfel(zakazs);
            else FortranReader.GetFortranReader.SavePlan(zakazs);
        }
    }
}
