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
    public partial class kuttyaneves : Form
    {
        public kuttyaneves()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
string kutyanev= listBox1.SelectedItem.ToString();
            dataGridView1.DataSource = X.DataFill("select kutyafaj, kutyaja.nem, emberek.nev from kutyak inner join kutyaja on kutyak.id=kutyaja.kutyafajtaid   inner join emberek on kutyaja.emberid=emberek.id where kutyaja.nev='" + kutyanev+"'");
            // fajta, nem, gazda neve 
        }

        private void kuttyaneves_Load(object sender, EventArgs e)
        {
            X.parancs.CommandText = "select  nev  from kutyaja group by nev";
            X.eredmeny = X.parancs.ExecuteReader();
            while (X.eredmeny.Read())
            {
                listBox1.Items.Add(X.eredmeny[0].ToString());
            }
            X.eredmeny.Close();
        }
    }
}
