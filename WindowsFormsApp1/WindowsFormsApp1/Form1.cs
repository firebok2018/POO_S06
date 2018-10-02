using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Archivo Binario|/.bin";

            if (sv.ShowDialog()==DialogResult.OK)
            {
                FileStream f = new FileStream(sv.FileName, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(f,txtBinaria.Text);
                f.Close();
            }
        }

        private void btnDezealixzar_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Archivo Binario|*.bin";
            if (op.ShowDialog()==DialogResult.OK)
            {
                FileStream f = new FileStream(op.FileName, FileMode.Open);
                BinaryFormatter bin =new BinaryFormatter();
                txtBinaria.Text = bin.Deserialize(f).ToString();
                f.Close();
            }
        }
    }
}
