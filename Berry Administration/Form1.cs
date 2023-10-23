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
    public partial class Form1 : Form
    {
        static string cadena_conexion = "Server=localhost;user=erikg;password=erikgiovani123;database=berry_db;";
        static MySqlConnection conexion = new MySqlConnection(cadena_conexion);
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Usuario")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Usuario";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Contraseña")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
                if (textBox2.Text != "Contraseña")
                {
                    textBox2.UseSystemPasswordChar = true;
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Contraseña";
                textBox2.ForeColor = Color.White;

                if ( textBox2.Text == "Contraseña")
                {
                    textBox2.UseSystemPasswordChar = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Verifica si se estan insertando datos
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    login();
                }
                else
                {
                    MessageBox.Show("Ingresa una contraseña");
                }
            }
            else
            {
             
                MessageBox.Show("Ingresa un usuario");
              
            }
        }

        private void login()
        {
            try
            {
                conexion.Open();

                string consulta = "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario AND contraseña = @contraseña";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@usuario", textBox1.Text);
                comando.Parameters.AddWithValue("@contraseña", textBox2.Text);

                int count = Convert.ToInt32(comando.ExecuteScalar());

                string opcion = comboBox1.SelectedItem.ToString();
                if (opcion == "Recopilador")
                {
                    if (count > 0)
                    {
                        this.Hide();
                        Form2 form2 = new Form2();
                        form2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta");
                    }
                }
                else
                {
                    if (opcion == "Administrador")
                    {
                        if (count > 0)
                        {
                            this.Hide();
                            Form3 form3 = new Form3();
                            form3.Show();
                        }
                        else
                        {
                            MessageBox.Show("Contraseña incorrecta");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccciona un usuario");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Contraseña incorrecta");
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
