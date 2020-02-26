using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DolgozatMegoldas
{
    public partial class sor : UserControl
    {
        // férfi neve kék nö piros
        static bool sorok = false;
        string[] adatok;
        int id;
        public sor( string s)
        {
            InitializeComponent();
            adatok = s.Split(';');
            id = int.Parse(adatok[0]);
            
        }

        private void sor_Load(object sender, EventArgs e)
        {
            X.parancs_s.CommandText = "select szakma from szakmak inner join szakmaja on szakmak.id=szakmaja.szakmaid inner join emberek on szakmaja.emberid=emberek.id where emberek.id="+id;
            X.eredmeny_s = X.parancs_s.ExecuteReader();
            string sa="";
            while (X.eredmeny_s.Read())
            {
                sa += X.eredmeny[0].ToString()+"\r\n";
            }
            X.eredmeny_s.Close();
            this.BackColor = (sorok? Color.Silver:Color.Azure);
            sorok = !sorok;
            label1.Text = adatok[2];
            label1.ForeColor = (adatok[1] =="f" ? Color.Blue : Color.Red);
            label2.Text = "születési datum: " + adatok[3];
            label3.Text = "szakmái:\r\n"+sa;
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                X.parancs.CommandText = "select mukaviszony from emberek inner join szakmaja on emberek.id=szakmaja.emberis inner join szakmak on szakmaja.szakmaid=szakmak.id where emberek.id=" + id;
                string ki = X.parancs.ExecuteScalar().ToString();
                switch (ki)
                {

                    case "-1": ki = "munkanélküli"; break;
                    case "0": ki = "nem a szakmájában dolgozik";break;
                }
                MessageBox.Show(ki);    
            }
        }
    }
}
