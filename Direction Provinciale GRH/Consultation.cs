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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Direction_Provinciale_GRH
{
    public partial class Consultation : Form
    {
        public Consultation()
        {
            InitializeComponent();
        }

        

        private void Consultation_Load(object sender, EventArgs e)
        {
            try
            {
                guna2HtmlLabel1.Text = "salut " + Globale.getusername() + " c'est le " + DateTime.Now.ToString("dd/MM/yyyy");
                string role = Globale.getrole();
                Globale.connect();
                string query = "";

                if (role == "consulteur")
                {
                    guna2TextBox3.Enabled = false;
                    guna2TextBox5.Enabled = false;
                    query = "SELECT PPR, Nom_Latin FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement";
                }
                else
                {
                    query = "SELECT PPR, CIN, Nom_Latin, NomLatin FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement";
                }




                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                MySqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string role = Globale.getrole();
                Globale.connect();
                string query = "";

                if (role == "consulteur")
                {
                    query = "SELECT PPR, Nom_Latin FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and P.PPR LIKE @ppr";
                }
                else
                {
                    query = "SELECT PPR, CIN, Nom_Latin, NomLatin FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and P.PPR LIKE @ppr";
                }
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@ppr", "%" + guna2TextBox2.Text + "%");
                MySqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string role = Globale.getrole();
                Globale.connect();
                string query = "";

                if (role == "consulteur")
                {
                    query = "SELECT PPR, Nom_Latin FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and P.CIN LIKE @cin";
                }
                else
                {
                    query = "SELECT PPR, CIN, Nom_Latin, NomLatin FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and P.CIN LIKE @cin";
                }
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@cin", "%" + guna2TextBox3.Text + "%");
                MySqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string role = Globale.getrole();
                Globale.connect();
                string query = "";

                if (role == "consulteur")
                {
                    query = "SELECT PPR, Nom_Latin FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and P.Nom_Latin LIKE @prenom";
                }
                else
                {
                    query = "SELECT PPR, CIN, Nom_Latin, NomLatin FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and P.Nom_Latin LIKE @prenom";
                }
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@prenom", "%" + guna2TextBox1.Text + "%");
                MySqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string role = Globale.getrole();
                Globale.connect();
                string query = "";

                if (role == "consulteur")
                {
                    query = "SELECT PPR, Nom_Latin FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and P.Nom_Latin LIKE @nom";
                }
                else
                {
                    query = "SELECT PPR, CIN, Nom_Latin, NomLatin FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and P.Nom_Latin LIKE @nom";
                }
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@nom", "%" + guna2TextBox4.Text + "%");
                MySqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string role = Globale.getrole();
                Globale.connect();
                string query = "";

                if (role == "consulteur")
                {
                    query = "SELECT PPR, Nom_Latin FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and E.NomLatin LIKE @nom";
                }
                else
                {
                    query = "SELECT PPR, CIN, Nom_Latin, NomLatin FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and E.NomLatin LIKE @nom";
                }
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@nom", "%" + guna2TextBox5.Text + "%");
                MySqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();
            guna2TextBox5.Clear();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            this.Close();
            Form2.Show();
        }
    }
}
