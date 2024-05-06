using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodosconJSONC_
{
    public partial class Form1 : Form
    {
        BaseDatos<Persona> baseDatos = new BaseDatos<Persona>("Personas.json");
        void Mostrar(List<Persona> baseDatos)
        {
            listBox1.Items.Clear();
            foreach (Persona persona in baseDatos)
            {
                listBox1.Items.Add(persona.Nombre + " " + persona.Apellido);
            }
        }
        public Form1()
        {
            InitializeComponent();
            
            baseDatos.Leer();
            Mostrar(baseDatos.lista);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            string nombre = textBox2.Text;
            string apellido = textBox3.Text;
            Persona persona = new Persona(id, nombre, apellido);
            
            baseDatos.Insertar(persona);
            Mostrar(baseDatos.lista);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Leer
            
            baseDatos.Leer();
            Mostrar(baseDatos.lista);
        }
    }
}
