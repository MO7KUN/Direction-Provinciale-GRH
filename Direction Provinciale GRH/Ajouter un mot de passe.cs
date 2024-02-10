using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Direction_Provinciale_GRH
{
    public partial class Ajouter_un_mot_de_passe : Form
    {
        public Ajouter_un_mot_de_passe()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
        }
        

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox1.Text.Length == 0)
                {
                    MessageBox.Show("ajouter un mot de passe");
                }
                else
                {
                    Globale.connect();
                    string query = "UPDATE compte SET password = @pass WHERE username =@user";
                    MySqlCommand command = new MySqlCommand(query, Globale.connection);
                    command.Parameters.AddWithValue("@user", Globale.getusername());
                    command.Parameters.AddWithValue("@pass", guna2TextBox1.Text);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Affectués avec succée");
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Failed to insert data!");
                    }

                    Globale.connection.Close();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ajouter_un_mot_de_passe_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = "Ajouter un mot de passe pour " + Globale.getusername();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
