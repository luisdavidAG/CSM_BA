using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Berry_Administration
{
    public partial class Form7 : Form
    {
        static string cadena_conexion = "Server=localhost;user=erikg;password=erikgiovani123;database=berry_db;";
        static MySqlConnection conexion = new MySqlConnection(cadena_conexion);

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Verificar si se insertan datos
            if (comboBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    if (textBox3.Text != "")
                    {
                        if (comboBox1.Text != "")
                        {
                            if (comboBox2.Text != "")
                            {
                                asignar_trabajo();
                            }
                            else
                            {
                                MessageBox.Show("Selecciona una ocupación");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Selecciona un dia");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingresa un apellido");
                    }
                }
                else
                {
                    MessageBox.Show("Ingresa un nombre");
                }
            }
            else
            {
                MessageBox.Show("Ingresa un id");
            }
        }

        private void asignar_trabajo()
        {
            try
            {
                conexion.Open();
                string sentencia = "INSERT INTO asignación (nombre, apellido, dia, ocupacion) VALUES (@nombre, @apellido, @dia, @ocupacion)";
                MySqlCommand comando = new MySqlCommand(sentencia, conexion);
                //comando = new MySqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@nombre", textBox2.Text);
                comando.Parameters.AddWithValue("@apellido", textBox3.Text);
                comando.Parameters.AddWithValue("@dia", comboBox1.Text);
                comando.Parameters.AddWithValue("@ocupacion", comboBox2.Text);
                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Guardado con éxito");
            }
            catch(Exception e)
            {
                MessageBox.Show("La asignación falló" + e);
            }
        }
    }
}

