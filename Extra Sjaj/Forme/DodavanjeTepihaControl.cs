using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ExtraSjaj.Modeli;

namespace ExtraSjaj.Forme
{
    public partial class DodavanjeTepihaControl : UserControl
    {
   
        public DodavanjeTepihaControl()
        {
            InitializeComponent();
        }

      


        void sakrijObjekteNaKontroli()
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            btnDodajTepih.Visible = false;
            btnNaplati.Visible = false;
            comboBox1.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            label7.Visible = false;
            textBox3.Visible = false;
        }
        void otkrijObjekteNaKontroli()
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            btnDodajTepih.Visible = true;
            btnNaplati.Visible = true;
            comboBox1.Visible = true;
            label4.Visible = true;
            label3.Visible = true;
            label7.Visible = true;
            textBox3.Visible = true;
        }
        void resetujObjekte()
        {
            listBox1.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }

    }
}
