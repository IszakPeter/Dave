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
    public partial class otable : Form
    {
        public otable()
        {
            InitializeComponent();
        }

        private void otable_Load(object sender, EventArgs e)
        {
             
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = X.DataFill("select * from " + listBox1.SelectedItem);
        }
    }
}
