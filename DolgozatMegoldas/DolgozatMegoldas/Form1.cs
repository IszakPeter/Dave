using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DolgozatMegoldas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            X.Kapcsolodas("emberek.db");
            label1.Text = "Iszak Péter \r\nElmélet: 1. 3. 5. \r\nGyakorlat: 2. 4. 6 ";
        }

        private void elsoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new otable().ShowDialog();
        }

        private void masodikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new kuttyaneves().ShowDialog();
        }

        private void harmadikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // hiba az sql parancsban
            X.parancs.CommandText = "select kutyafaj, sum(fajtiszta), count(fajtiszta)-sum(fajtiszta) from  kutyak inner join kutyaja on kutyak.id=kutyaja.kutyafajtaid where sum(fajtiszta)>(count(fajtiszta)-sum(fajtiszta))";
            X.eredmeny = X.parancs.ExecuteReader();
          
            string szov="";
            while (X.eredmeny.Read())
            {
                szov += X.eredmeny[0].ToString() + "\r\n";
            }
            X.eredmeny.Close();
            MessageBox.Show(szov);
        }

        private void negyedikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new szakmas().ShowDialog();
        }
        private void hatodikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new leges().ShowDialog();
        }

        private void otodikToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
