using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraSjaj
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_TepisiBaza_2018DataSet1.Musterijas' table. You can move, or remove it, as needed.
            this.musterijasTableAdapter1.Fill(this._TepisiBaza_2018DataSet1.Musterijas);
            // TODO: This line of code loads data into the '_TepisiBaza_2018DataSet.Musterijas' table. You can move, or remove it, as needed.
            this.musterijasTableAdapter1.Fill(this._TepisiBaza_2018DataSet1.Musterijas);

        }
    }
}
