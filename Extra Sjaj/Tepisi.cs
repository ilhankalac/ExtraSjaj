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
    public partial class Tepisi : Form
    {
        public Tepisi()
        {
            InitializeComponent();
        }

        private void Tepisi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_TepisiBaza_2018DataSet1.Tepisi' table. You can move, or remove it, as needed.
            this.tepisiTableAdapter.Fill(this._TepisiBaza_2018DataSet1.Tepisi);

        }
    }
}
