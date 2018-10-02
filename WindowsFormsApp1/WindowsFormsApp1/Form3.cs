using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form

    {
        //List<Alumno> alumnos =new List<Alumno>();
        Aula al = new Aula();
        public Form3()
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
            sv.Filter = "Archivos Xml|*.xml";
            if (sv.ShowDialog()== DialogResult.OK)
            {
                FileStream f = new FileStream(sv.FileName, FileMode.Create);
                XmlSerializer xml = new XmlSerializer(typeof(Aula));
                xml.Serialize(f,al);
                f.Close();

            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Alumno alumn = new Alumno();
            alumn.dni = txtdni.Text;
            alumn.nombre = txtnombre.Text;
            alumn.apellido = txtApellido.Text;
            alumn.telefono = txttlefono.Text;
            alumn.fechanc = dtpFechaNac.Value;

            al.lisAlu.Add(alumn);

            dgvAlumnos.DataSource = null;
            dgvAlumnos.DataSource = al.lisAlu;
        }

        private void BtnDezerializar_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Archivos Xml|*.xml";

            if (op.ShowDialog()==DialogResult.OK)
            {
                FileStream f = new FileStream(op.FileName, FileMode.Open);
                XmlSerializer xml = new XmlSerializer(typeof(Aula));

                Aula liA = (Aula)xml.Deserialize(f);
                dgvAlumnos.DataSource = null;
                dgvAlumnos.DataSource=liA.lisAlu;
                
                f.Close();

            }

        }

        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdni.Text = dgvAlumnos.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = dgvAlumnos.CurrentRow.Cells[1].Value.ToString();
            txtApellido.Text = dgvAlumnos.CurrentRow.Cells[2].Value.ToString();
            txttlefono.Text = dgvAlumnos.CurrentRow.Cells[3].Value.ToString();
            dtpFechaNac.Value = (DateTime)dgvAlumnos.CurrentRow.Cells[4].Value;
        }
    }
}
