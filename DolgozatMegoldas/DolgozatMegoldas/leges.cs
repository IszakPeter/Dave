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
    public partial class leges : Form
    {
        public leges()
        {
            InitializeComponent();
        }

        private void leges_Load(object sender, EventArgs e)
        {
            List<string> vs = new List<string>();
            X.parancs.CommandText = "select szakmak.id,count(emberek.id)  from emberek inner join szakmaja on emberek.id=szakmaja.emberid inner join szakmak on szakmaja.szakmaid=szakmak.id group by szakmak.id";
            X.eredmeny = X.parancs.ExecuteReader();
            while (X.eredmeny.Read())
            {
                vs.Add(X.eredmeny[1].ToString());
            }
            X.eredmeny.Close();
            trackBar1.Minimum = int.Parse(vs[0].ToString());
            trackBar1.Maximum = int.Parse(vs[vs.Count-1].ToString());

            //MessageBox.Show(trackBar1.Minimum + " " + trackBar1.Maximum);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "";
            X.parancs.CommandText = "select szakmak.szakma, count(emberek.id)  from emberek inner join szakmaja on emberek.id=szakmaja.emberid inner join szakmak on szakmaja.szakmaid=szakmak.id where count(emberek.id)=" + trackBar1.Value.ToString()+" group by emberek.id";
            X.eredmeny = X.parancs.ExecuteReader();
            while (X.eredmeny.Read())
            {
                label1.Text += X.eredmeny[0].ToString()+"\r\n";
            }
        }
    }
}
