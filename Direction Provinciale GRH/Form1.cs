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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Direction_Provinciale_GRH
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Globale.connect();
                Globale.setusername(guna2TextBox1.Text);
                String password = guna2TextBox2.Text;

                string query = "SELECT role, password FROM compte WHERE username = @username AND password = @password";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@username", Globale.getusername());
                command.Parameters.AddWithValue("@password", password);
                MySqlDataReader reader = command.ExecuteReader();

                


                if (reader.Read())
                {
                    Globale.setrole(reader.GetString("role"));
                    
                    Form2 Form2 = new Form2();
                    
                    Form2.Show();
                    if (reader.GetString("password").Length == 0)
                    {
                        Ajouter_un_mot_de_passe pswd = new Ajouter_un_mot_de_passe();
                        pswd.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
                Globale.connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
        }

       
    }
}
