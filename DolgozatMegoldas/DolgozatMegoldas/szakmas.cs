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
    public partial class szakmas : Form
    {
        public szakmas()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        { int y=0;
            string szakma = listBox1.SelectedItem.ToString();
            X.parancs.CommandText = "select emberek.id,nem, nev, szulido from szakmak inner join szakmaja on szakmak.id=szakmaja.szakmaid inner join emberek on szakmaja.emberid=emberek.id where szakma='"+szakma+"'";
            X.eredmeny = X.parancs.ExecuteReader();
            int oszlopok = X.eredmeny.FieldCount;
            while (X.eredmeny.Read()) {
                string s = "";
                for (int i = 0; i < oszlopok; i++)
                {
                    s += X.eredmeny[i].ToString()+";";
                }
                sor sor = new sor(s);
                sor.Location = new Point(0, y);
                y += sor.Height;
                panel1.Controls.Add(sor);
            
            }
            X.eredmeny.Close();
        }

        private void szakmas_Load(object sender, EventArgs e)
        {
            X.parancs.CommandText = "select szakma from szakmak ";
            X.eredmeny = X.parancs.ExecuteReader();
            while (X.eredmeny.Read())
            {
                listBox1.Items.Add(X.eredmeny[0].ToString());
            }
            X.eredmeny.Close();
        }
    }
}
