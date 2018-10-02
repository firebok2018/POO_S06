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
using System.Xml.Serialization;



namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtdni.Clear();
            txtnombre.Clear();
            txttlefono.Clear();
            dtpFechaNac.Value = DateTime.Today;
            txtdni.Focus();

        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Archivo Xml|*.xml";
            if (sv.ShowDialog()==DialogResult.OK)
            {
                Alumno reg = new Alumno();

                reg.dni = txtdni.Text;
                reg.apellido = txtApellido.Text;
                reg.nombre = txtnombre.Text;
                reg.telefono = txttlefono.Text;
                reg.fechanc = dtpFechaNac.Value;

                FileStream f = new FileStream(sv.FileName,FileMode.Create);
                XmlSerializer xml = new XmlSerializer(typeof(Alumno));

                xml.Serialize(f,reg);
                f.Close();

            }
        }

        private void BtnDezerializar_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Archivo Xml|*.xml";
            if (op.ShowDialog()==DialogResult.OK)
            {
                FileStream f = new FileStream(op.FileName, FileMode.Open);
                XmlSerializer xml = new XmlSerializer(typeof(Alumno));

                Alumno nuevo = (Alumno)xml.Deserialize(f);
                txtdni.Text = nuevo.dni;
                txtnombre.Text = nuevo.nombre;
                txtApellido.Text = nuevo.apellido;
                txttlefono.Text = nuevo.telefono;
                dtpFechaNac.Value = nuevo.fechanc;
            }
        }
    }
}
